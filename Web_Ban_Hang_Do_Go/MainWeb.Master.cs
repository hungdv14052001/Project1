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
    public partial class MainWeb : System.Web.UI.MasterPage
    {
        string str = @"Data Source=DESKTOP-FA5AISU\SQLEXPRESS;Initial Catalog=WebBanHangDoGo;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();
        DataTable tbl = new DataTable();
        DataSet ds = new DataSet();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            loadGH();
        }

        public void loadGH()
        {
            string more;
            if (Session["id"].ToString().Length==0)
            {
                more = "0";
            }
            else
            {
                more = Session["id"].ToString();
            }
            
            comm = conn.CreateCommand();
            comm.CommandText = "select tblChiTietGH.MaH, tblSanPham.AnhMH, tblSanPham.MaSP, tblSanPham.TenSP, tblSanPham.Gia, tblChiTietGH.SL, tblGioHang.TongTien from tblSanPham, tblGioHang, tblChiTietGH where tblChiTietGH.MaGH= tblGioHang.MaGH and tblChiTietGH.MaSP= tblSanPham.MaSP and tblGioHang.MaTV= "+more;
            ada.SelectCommand = comm;
            ds.Clear();
            ada.Fill(ds);
            DLGioHang.DataSource = ds;
            DLGioHang.DataBind();
            /*Lấy dữ liệu cho Tổng tiền giỏ hàng*/
            tbl.Clear();
            ada.Fill(tbl);
            foreach(DataRow r in tbl.Rows)
            {
                Total.Text = "Tổng Tiền: "+ r["TongTien"].ToString()+ " ₫";
            }
        }
        protected void btnXoaGH_Click(Object sender, EventArgs e)
        {
            LinkButton btnClick = (LinkButton)sender;
            string more = btnClick.CommandArgument.ToString();
            comm = conn.CreateCommand();
            comm.CommandText = "update tblGioHang " +
                "set TongTien -= " +
                "(Select tblSanPham.Gia from tblGioHang, tblSanPham, tblChiTietGH where tblSanPham.MaSP = tblChiTietGH.MaSP and tblGioHang.MaGH = tblChiTietGH.MaGH and tblChiTietGH.MaH = " + more+" ) " +
                "from tblGioHang, tblChiTietGH where tblGioHang.MaGH = tblChiTietGH.MaGH and tblChiTietGH.MaH = " + more + "; " +
                "delete from tblChiTietGH where tblChiTietGH.MaH = "+more+"; ";
            comm.ExecuteNonQuery();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ThongBaoXoa()", true);
            loadGH();
        }
        protected void Button5_Click(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string tk = txtAcc.Value.ToString();
            string mk = txtPass.Value.ToString();
            if (DangNhap(tk, mk))
            {
                Session["member"] = true;
                comm = conn.CreateCommand();
                comm.CommandText = "select * from tblThanhVien";
                ada.SelectCommand = comm;
                tbl.Clear();
                ada.Fill(tbl);
                foreach (DataRow r in tbl.Rows)
                {
                    if(tk.Equals(r["SDT"].ToString())|| tk.Equals(r["Email"].ToString()))
                    {
                        Session["id"] = r["MaTV"].ToString();
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ValidateMail()", true);
            }
            loadGH();
        }
        public bool DangNhap(string tk, string mk)
        {
            bool kq = false;
            comm = conn.CreateCommand();
            comm.CommandText = "select * from tblThanhVien";
            ada.SelectCommand = comm;
            tbl.Clear();
            ada.Fill(tbl);
            foreach( DataRow r in tbl.Rows)
            {
                if(tk.Equals(r["Email"].ToString()) || tk.Equals(r["SDT"].ToString()))
                {
                    if (mk.Equals(r["Password"].ToString()))
                    {
                        kq = true;
                    }
                    
                }
            }
            return kq;
        }
        protected void DangXuat(object sender, EventArgs e)
        {
            Session["member"] = false;
            Session["id"] = "";
            loadGH();
        }
    }
}