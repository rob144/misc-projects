<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPhotos.aspx.cs" Inherits="PGAspNet.AddPhotos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Photo Gallery</title>
        <link rel="stylesheet" type="text/css" href="res/css/Site.css"/> 
        <link href="res/lightbox/css/lightbox.css" rel="stylesheet" />
        <script src="res/lightbox/js/jquery-1.10.2.min.js"></script>
        <script src="res/lightbox/js/lightbox-2.6.min.js"></script>
    </head>
    <body>

        <script type="text/javascript">
            $(document).ready(function () {
                $("#upload-iframe").load(function () {
                    alert("iFrame response: " + $('#upload-iframe').contents().find('body').html());
                    // Do something with response text.
                });
            });
        </script>

        <div id="pageOuter">

            <h1><a id="siteTitle" href="Default.aspx">Photo Gallery</a></h1>
            
            <div>
               <iframe id="upload-iframe" name='upload-iframe' src="ReceiveUpload.aspx"></iframe>
               <form id="frmAddPhoto" enctype="multipart/form-data" action="ReceiveUpload.aspx" method="post" target="upload-iframe">
                   <p>Filename: <input type="file" name="uploadFile"></p>
                   <p><input type="submit" name="submit" value="Upload File"></p>
               </form>
            </div>

        </div>

    </body>
</html>

