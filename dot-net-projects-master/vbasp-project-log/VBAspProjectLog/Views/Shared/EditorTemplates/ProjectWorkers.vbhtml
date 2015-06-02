@ModelType IEnumerable(Of VBAspProjectLog.Worker)
@*Requires ViewBag.Workers*@

<div id="container-unassigned-personel">
    <div id="label-unassigned-personel">Unassigned</div>
    <select multiple id="select-project-personel" size="8">
        @For Each w As VBAspProjectLog.Worker In ViewBag.Workers
            If (Not Model Is Nothing) Then
                If (Not Model.Contains(w)) Then
                    @<option value="@w.WorkerID">@w.FullName()</option>  
                End If
            Else
                @<option value="@w.WorkerID">@w.FullName()</option>  
            End If
            
        Next 
    </select>
</div>
                    
<div id="container-add-remove-personel">
    <input type="button" id="personel-add" value=">"/>
    <input type="button" id="personel-remove" value="<"/>
</div>
                    
<div id="container-assigned-personel">
    <label id="label-assigned-personel">Assigned</label>
    <select multiple id="select-project-personel-added" size="8">
        @If (Not Model Is Nothing) Then
            @Try
                @For Each w In Model
                    @<option value="@w.WorkerID">@w.FullName()</option>
                Next
            Catch ex As NullReferenceException
                'No workers assigned to the project
            End Try
        End If
    </select>
    <input type="hidden" id="Workers" name="Workers" value="" />
</div>

<script type="text/javascript">
    $(document).ready(function () {
                            
        $("#personel-add").click(function () {
            switchSelectOption("select-project-personel",
                "select-project-personel-added");
        });

        $("#personel-remove").click(function () {
            switchSelectOption("select-project-personel-added",
                "select-project-personel");
        });

        function switchSelectOption(idSelectFrom, idSelectTo) {
                                
            var s1 = $('#' + idSelectFrom);
            var s2 = $('#' + idSelectTo);
            var val = s1.find(":selected").val();

            if (s2.find('[value="' + val + '"]').length <= 0) {
                s2.append($("<option></option>")
                    .attr("value", val)
                    .text(s1.find(":selected").text())
                );
            }

            s1.find(":selected").remove();
        };

        $("#submit").click(function () {
            var input = $("#Workers");
            input.val("");

            $('#select-project-personel-added').find('option').each(function (index) {
                if (index >= 1) input.val(input.val() + ",");
                input.val(input.val() + $(this).val());
            });

        });
    });
</script>