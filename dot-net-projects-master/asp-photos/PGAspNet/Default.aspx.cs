using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RExtMethods;

namespace PGAspNet
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ("" + Request.QueryString["action"] != "")
            {
                string strAction = Request.QueryString["action"];

                if(strAction == "editphoto")
                { 
                    containerPhotos.InnerHtml += "EDIT"; 
                    //TODO: Show the edit view
                    Response.Redirect("EditPhoto.aspx?oid=" + Request.QueryString.GetValue<int>("oid"));
                }
                else if(strAction == "downloadphoto")
                {
                    containerPhotos.InnerHtml += "DOWNLOAD";
                    //TODO: Start the download
                }
                else if (strAction == "deletephoto") 
                {
                    Response.Redirect("DeletePhoto.aspx?oid=" + Request.QueryString.GetValue<int>("oid"));
                }
                else if (strAction == "fill")
                {
                    RMySqlDbHelper.insertTestData();
                }

            };


            RDataResult d = RMySqlDbHelper.getPhotos();

            if (d.err.Trim() != "")
            {
                containerPhotos.InnerHtml += "ERROR: " + d.err;
            }else{
                for (int i = 0; i < d.dataTable.Rows.Count; i++)
                {
                    string cssClass = (i > 0 && (i + 1) % 4 == 0 ? "photoOuterRowEnd" : "photoOuter");
                    string strHtml = @"
                        <div class='[cssClass]'>
                         <div class='photoInner'>
                         <a href='res/photos/[file_ref]' rel='lightbox' title='[description]'>
                            <img class='photo' src='res/photos/[file_ref]' data-lightbox='image-[photoId]' />
                         </a>
                         <div class='photoControls'>
                            <a href='res/photos/[file_ref]' rel='lightbox' class='photoControl' title='[description]'>
                                <img class='photoControlIcon' src='res/ui/view.png' />
                            </a>
                            <a class='photoControl' title='edit photo' href='?action=editphoto&oid=[photoId]'>
                                <img class='photoControlIcon' src='res/ui/edit.png' />
                            </a>
                            <a class='photoControl' title='download photo' href='?action=downloadphoto&oid=[photoId]'>
                                <img class='photoControlIcon' src='res/ui/download.png' />
                            </a>
                            <a class='photoControl' title='delete photo' href='?action=deletephoto&oid=[photoId]'>
                                <img class='photoControlIcon' src='res/ui/delete.png' />
                            </a>
                         </div>
                        </div>
                        </div>
                    ";
                    strHtml = strHtml.Replace("[cssClass]", cssClass);
                    strHtml = strHtml.Replace("[photoId]", "" + d.dataTable.Rows[i]["id"]);
                    strHtml = strHtml.Replace("[file_ref]", "" + d.dataTable.Rows[i]["file_ref"]);
                    strHtml = strHtml.Replace("[description]", "" + d.dataTable.Rows[i]["description"]);
                    containerPhotos.InnerHtml += strHtml;    
                }
            }

        }
    }
}