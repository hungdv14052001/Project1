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
    public partial class MesssageAd : System.Web.UI.Page
    {
        string str = @"Data Source=DESKTOP-FA5AISU\SQLEXPRESS;Initial Catalog=WebBanHangDoGo;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            KT();
            conn = new SqlConnection(str);
            conn.Open();
            loadKH();
        }
        void KT()
        {
            if ((Boolean)Session["admin"] == false)
            {
                Response.Redirect("HomePage.aspx");
            }
        }
        void loadKH()
        {
            comm = conn.CreateCommand();
            comm.CommandText = "select * from tblThanhVien";
            adp.SelectCommand = comm;
            ds.Clear();
            adp.Fill(ds);
            DLKhachHang.DataSource = ds;
            DLKhachHang.DataBind();
        }
    }
}