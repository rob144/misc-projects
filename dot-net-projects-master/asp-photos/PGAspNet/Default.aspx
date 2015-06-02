<%@ Page Title="Home Page" Language="C#" 
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PGAspNet._Default" %>

<html>

    <head>
        <title>Photo Gallery</title>
        <link rel="stylesheet" type="text/css" href="res/css/Site.css"> 
        <link href="res/lightbox/css/lightbox.css" rel="stylesheet" />
        <script src="res/lightbox/js/jquery-1.10.2.min.js"></script>
        <script src="res/lightbox/js/lightbox-2.6.min.js"></script>
    </head>

    <body>

        <div id="pageOuter">

            <h1>Photo Gallery</h1>
            <p>
                <a href="AddPhotos.aspx" >Add Photos</a>
            </p>

            <div id="containerPhotos" runat="server">
               
            </div>

        </div>

    </body>

</html>

