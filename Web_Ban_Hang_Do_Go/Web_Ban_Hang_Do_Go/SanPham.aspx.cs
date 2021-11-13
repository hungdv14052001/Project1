using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Web_Ban_Hang_Do_Go
{
    public partial class SanPham : System.Web.UI.Page
    {
        string str = @"Data Source=DESKTOP-FA5AISU\SQLEXPRESS;Initial Catalog=WebBanHangDoGo;Integrated Security=True";
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();
        String id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["ID"].ToString();
            con = new SqlConnection(str);
            con.Open();
            loadTD();
            loadDataSP();
            con.Close();
        }
        public void loadDataSP()
        {
            string more;
            com = con.CreateCommand();
            if (id.Equals("PK"))
            {
                more = "Phòng Khách";
            }
            else if (id.Equals("PN"))
            {
                more = "Phòng Ngủ";
            }
            else if (id.Equals("PB"))
            {
                more = "Phòng Bếp";
            }
            else if (id.Equals("PT"))
            {
                more = "Phòng Thờ";
            }
            else
            {
                more = "Khác";
            }
            com.CommandText = "Select * from tblSanPham where LoaiDM= N'"+more+"'";
            ada.SelectCommand = com;
            DataSet ds = new DataSet();
            ada.Fill(ds);
            DLSP.DataSource = ds;
            DLSP.DataBind();
        }
        public void loadTD()
        {
            if (id.Equals("PK"))
            {
                lbTieuDe.Text = "Nội Thất Phòng Khách";
            }
            else if (id.Equals("PN"))
            {
                lbTieuDe.Text = "Nội Thất Phòng Ngủ";
            }
            else if (id.Equals("PB"))
            {
                lbTieuDe.Text = "Nội Thất Phòng Bếp";
            }
            else if (id.Equals("PT"))
            {
                lbTieuDe.Text = "Nội Thất Phòng Thờ";
            }
            else
            {
                lbTieuDe.Text = "Các Loại Đồ Gỗ Khác";
            }
        }
    }
}