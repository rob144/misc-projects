<!DOCTYPE html>
<html>
    
    <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width" />
        <title>@ViewData("Title")</title>
        @Styles.Render("~/Content/css")
        @Scripts.Render("~/bundles/jquery")
        @RenderSection("scripts", required:=False)
    </head>

    <body>
        <div class="pageOuter">
            <a href="/Home/Index"><img alt="Project Log Logo" src="/Content/logo70.png" /></a>
            @Html.Partial("LoginControl")
            @RenderBody()
        </div>
    </body>

</html>
