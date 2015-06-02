using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PGAspNet
{
    public partial class EditPhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int photoId = 0;
            int.TryParse(Request.QueryString["oid"], out photoId);

            if (photoId <= 0)
            {
                output.InnerHtml += "No object ID provided.";
            }
            else
            {
                RPhoto photo = RMySqlDbHelper.getPhoto(photoId);

                string strHtml = @"
                    <a href='res/photos/[file_ref]' rel='lightbox' title='[description]'>
                        <img class='photo' src='res/photos/[file_ref]' data-lightbox='image-[photoId]' />
                    </a>";
                strHtml = strHtml.Replace("[photoId]", "" + photo.ID);
                strHtml = strHtml.Replace("[file_ref]", "" + photo.FileRef);
                strHtml = strHtml.Replace("[description]", "" + photo.Description);
                output.InnerHtml += strHtml + "<a href='Default.aspx'>Cancel</a>&nbsp;&nbsp;";

            }
        }
    }
}