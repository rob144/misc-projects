using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PGAspNet
{
    public partial class ReceiveUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpFileCollection uploadFile = Request.Files;
            string filePath = "";
            if (uploadFile.Count > 0)
            {
                HttpPostedFile postedFile = uploadFile[0];
                System.IO.Stream inStream = postedFile.InputStream;
                byte[] fileData = new byte[postedFile.ContentLength];
                inStream.Read(fileData, 0, postedFile.ContentLength);
                filePath = Server.MapPath("res/photos/uploads") + "\\" + postedFile.FileName;
                postedFile.SaveAs(filePath);
                uploadThumbnailContainer.InnerHtml = "<img class='uploadThumbnail' title='thumbnail' src='res/photos/uploads/" + postedFile.FileName + "' />";
            }        
        }
    }
}