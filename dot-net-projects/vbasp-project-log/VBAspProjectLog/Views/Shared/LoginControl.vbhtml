<div class="loginControl">
    @Try
        If TempData("Username").ToString() & "" <> "" Then
            @:<div>Logged in as: @TempData("Username")</div>
            @<div>
                <form method="post" action="/Login">
                    <input type="hidden" name="action" value="logout" />
                    <input class="logoutAction" type="submit" value="Sign out" />
                </form>
             </div>
        End If
    Catch ex As Exception
        'No username set
    End Try
</div>
