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
    public partial class Detialsp : System.Web.UI.Page
    {

        string strc = @"Data Source=DESKTOP-FA5AISU\SQLEXPRESS;Initial Catalog=WebBanHangDoGo;Integrated Security=True";
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(strc);
            con.Open();
            string id = Request.QueryString["ID"].ToString();
            loadData(id);
            
        }
        void loadData(string id)
        {
            com = con.CreateCommand();
            com.CommandText = "select * from tblSanPham";
            ada.SelectCommand = com;
            DataTable tbl = new DataTable();
            ada.Fill(tbl);
            foreach(DataRow r in tbl.Rows)
            {
                if (id.Equals(r["MaSP"].ToString()))
                {
                    lbChatLieu.Text = r["ChatLieu"].ToString();
                    lbTen.Text= r["TenSP"].ToString();
                    lbTSKT.Text= r["TSKT"].ToString();
                    lbGia.Text= r["Gia"].ToString();
                    lbMota.Text= r["MoTa"].ToString();
                    imgsp.Attributes["src"] = r["AnhMH"].ToString();
                }
            }
        }

        protected void btnMuaHang_Click(object sender, EventArgs e)
        {
            if ((Boolean)Session["member"] == true)
            {
                string id = Request.QueryString["ID"].ToString();
                string s = Session["id"].ToString();
                com = con.CreateCommand();
                com.CommandText = "Insert into tblChiTietGH(MaGH, MaSP, SL) values("+s+", N'"+id+"', 1); " +
                    "update tblGioHang set TongTien += (select tblSanPham.Gia from tblSanPham where tblSanPham.MaSP = N'" + id + "') where MaGH = " + s + "; ";
                com.ExecuteNonQuery();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "TBThemVaoGH()", true);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "TBYeuCauLogin()", true);
            }
            

        }
    }
}