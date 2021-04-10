using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectC.DAO;

namespace ProjectByWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string user = TextBoxUserName.Text;
            string pass = TextBoxPass.Text;
            if (!checkFormat(user,pass))
            {
                return;
            }
            Admin a = Admin.GetAdmin(user,pass);
            if (a!=null)
            {
                Session["Admin"] = a;
                Response.Redirect("Home.aspx");
            }
            else
            {
                LabelLogin.Text = "UserName hoac PassWord sai!!!";
            }
        }

        private bool checkFormat(string user, string pass)
        {
            if (user.Length==0||pass.Length==0)
            {
                LabelLogin.Text = "You must input data!!!";
                return false;
            }
            return true;
        }
    }
}