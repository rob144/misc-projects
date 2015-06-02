@Imports VBAspProjectLog
@Code
    ViewData("Title") = "Projects Home"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Projects - Home</h2>

<div class="actionMenu">
    <div class="actionLink"><a href="/Project/Create">Create Project</a></div>
    <div class="actionLink"><a href="/Worker">Manage Personel</a></div>
</div>

@For Each p As Project In ViewBag.Projects
    @<div class="project">
        <div class="statusLightOuter">
        @If p.Status = ProjectStatus.Not_Started Then
                @<div class="statusLightRed"></div>
        ElseIf p.Status = ProjectStatus.Started Then
                @<div class="statusLightAmber"></div>
        ElseIf p.Status = ProjectStatus.Finished Then
                @<div class="statusLightGreen"></div>
        End If
        </div>
        <div class="projectInfo">
            <div class="projectTitle">@Html.Raw(p.Title)</div>
            <div class="projectDate">Created: <i>@Html.Raw(p.DateCreated)</i></div>
            <div class="projectStatus">
                Status: <i>@Html.Raw(Replace(System.Enum.GetName(GetType(ProjectStatus), p.Status),"_"," "))
                            @If p.Status = ProjectStatus.Finished Then @Html.Raw(" on ") @p.DateFinished End if </i>
            </div>
        </div>
        
        <div class="viewProject">
            <a href="/Project/Details/@p.ProjectID">
                <img alt="view" title="view project" src="/Content/viewicon16.png" />
            </a>
        </div>
        <div class="editProject">
            <a href="/Project/Edit/@p.ProjectID">
                <img alt="edit" title="edit project" src="/Content/editicon16.png" />
            </a>
        </div>
        <div class="deleteProject">
            <a href="/Project/Delete/@p.ProjectID">
                <img alt="delete" title="delete project" src="/Content/deleteicon16.png" />
            </a>
        </div>
    </div>           
Next