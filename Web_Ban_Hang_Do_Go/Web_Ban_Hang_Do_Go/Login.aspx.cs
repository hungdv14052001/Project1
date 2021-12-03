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
    public partial class Login : System.Web.UI.Page
    {
        string str = @"Data Source=DESKTOP-FA5AISU\SQLEXPRESS;Initial Catalog=WebBanHangDoGo;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataTable tbl = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string acc = txtAcc.Value.ToString();
            string pass = txtPass.Value.ToString();
            if (acc.Length == 0 || pass.Length == 0)
            {
                lbThongBao.Text = "Vui Lòng Nhập Đầy Đủ Thông Tin";
                return;
            }
            if(DangNhap(acc, pass))
            {
                Session["admin"] = true;
                lbThongBao.Text = "Đăng Nhập Thành Công!";
                Response.Redirect("TrangChuAdmin.aspx");
            }
            else
            {
                lbThongBao.Text = "Tài Khoản Hoặc Mật Khẩu Không Đúng";
            }
        }
        public bool DangNhap(string acc, string pass)
        {
            bool kq = false;
            comm = conn.CreateCommand();
            comm.CommandText = "select * from tblAdmin";
            adp.SelectCommand = comm;
            tbl.Clear();
            adp.Fill(tbl);
            foreach(DataRow r in tbl.Rows)
            {
                if(acc.Equals(r["Username"].ToString())&& pass.Equals(r["Password"].ToString()) )
                {
                    kq = true;
                    Session["MaAd"] = r["MaAd"].ToString();
                }
            }
            return kq;
        }
    }
}