using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectC.DAO;

namespace ProjectByWeb
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"]==null)
            {
                return;
            }
            Admin a = (Admin)Session["Admin"];
            LabelUserName.Text = a.MaGv1;
            if (!IsPostBack)
            {
                DropDownListClass.DataTextField = "TenLop";
                DropDownListClass.DataValueField = "MaLop";
                DropDownListClass.DataSource = Lop.getAllClass();
                DropDownListClass.DataBind();

                GridViewSinhVien.DataSource = SinhVien.getAllSinhVien();
                GridViewSinhVien.DataBind();

                DropDownListKhoa.DataTextField = "TenKhoa1";
                DropDownListKhoa.DataValueField = "MaKhoa1";
                DropDownListKhoa.DataSource = Khoa.GetKhoas();
                DropDownListKhoa.DataBind();
            }
        }

        protected void DropDownListClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenLop = (string)DropDownListClass.SelectedValue;

            GridViewSinhVien.DataSource = SinhVienAndPoint.getSinhVienAndPointByClassID(tenLop);
            GridViewSinhVien.DataBind();
        }

        protected void DropDownListKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}