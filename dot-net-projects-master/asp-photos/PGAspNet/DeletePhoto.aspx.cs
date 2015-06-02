using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RExtMethods;

namespace PGAspNet
{
    public partial class DeletePhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int photoId = 0;
            int confirm = 0;

            int.TryParse(Request.QueryString["oid"], out photoId);
            int.TryParse(Request.QueryString["confirm"], out confirm);

            if (photoId <= 0)
            {
                output.InnerHtml += "No object ID provided.";
            }
            else
            {
                RPhoto photo = RMySqlDbHelper.getPhoto(photoId);

                if (confirm != 1)
                {
                    string strHtml = @"
                        <a href='res/photos/[file_ref]' rel='lightbox' title='[description]'>
                            <img class='photo' src='res/photos/[file_ref]' data-lightbox='image-[photoId]' />
                        </a>";
                    strHtml = strHtml.Replace("[photoId]", "" + photo.ID);
                    strHtml = strHtml.Replace("[file_ref]", "" + photo.FileRef);
                    strHtml = strHtml.Replace("[description]", "" + photo.Description);
                    output.InnerHtml += "<p>Are you sure you want to delete this?<p>"
                        + strHtml
                        + "<a href='Default.aspx'>Cancel</a>&nbsp;&nbsp;"
                        + "<a href='?confirm=1&oid=" + photo.ID + "'>Delete</a>";
                }
                else
                {
                    try
                    {
                        output.InnerHtml += "DELETED " + RMySqlDbHelper.deletePhoto(photoId).intResult + "PHOTO.";
                        output.InnerHtml += "<p><a href='Default.aspx'>Back to Gallery<a></p>";
                    }
                    catch (Exception ex) { output.InnerHtml += "DELETE ERROR: "; }
                }

            }
            
        }

    }
}