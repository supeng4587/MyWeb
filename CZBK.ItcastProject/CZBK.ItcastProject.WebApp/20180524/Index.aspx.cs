using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CZBK.ItcastProject.WebApp._20180524
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txt1.Value = "123";
            Button1.Attributes.Add("onclick", "alert('sssss')");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (this.FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(this.FileUpload1.FileName);
                string fileExt = Path.GetExtension(this.FileUpload1.FileName);
                if (fileExt == ".jpg")
                {
                    this.FileUpload1.SaveAs(Request.MapPath("/ImageUpload/" + fileName));
                }
            }
        }
    }
}