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
    public partial class QLDH : System.Web.UI.Page
    {
        string str = @"Data Source=DESKTOP-FA5AISU\SQLEXPRESS;Initial Catalog=WebBanHangDoGo;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();
        DataTable tbl = new DataTable();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            KT();
            conn = new SqlConnection(str);
            conn.Open();
        }
        void KT()
        {
            if ((Boolean)Session["admin"] == false)
            {
                Response.Redirect("HomePage.aspx");
            }
        }
        public void loadData(int type)
        {
            string sql="";
            if (type == 1)
            {
                sql = "select * from tblDonHang where TrangThai= 'True'";
            }
            else if (type == 2)
            {
                sql = "select * from tblDonHang where TrangThai= 'False'";
            }
            else if(type==0)
            {
                sql = "select * from tblDonHang";
            }
            comm = conn.CreateCommand();
            comm.CommandText = sql;
            ada.SelectCommand = comm;
            ds.Clear();
            ada.Fill(ds);
            DLDH.DataSource = ds;
            DLDH.DataBind();
        }

        
        protected void btnDoDL_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string more = btn.CommandArgument.ToString();
            comm = conn.CreateCommand();
            comm.CommandText = "Select tblSanPham.MaSP, tblSanPham.AnhMH, tblSanPham.TenSP, tblSanPham.Gia from tblSanPham, tblChiTietDH  where tblSanPham.MaSP = tblChiTietDH.MaSP and tblChiTietDH.MaDH= "+more;
            ada.SelectCommand = comm;
            ds.Clear();
            ada.Fill(ds);
            dlCTDH.DataSource = ds;
            dlCTDH.DataBind();
            comm = conn.CreateCommand();
            comm.CommandText = "select TongTien from tblDonHang where MaDH= " + more;
            ada.SelectCommand = comm;
            tbl.Clear();
            ada.Fill(tbl);
            foreach(DataRow r in tbl.Rows)
            {
                lbTongTien.Text = "Tổng Tiền: " + r["TongTien"].ToString() + "đ";
            }
            comm = conn.CreateCommand();
            comm.CommandText = "select * from tblThanhVien where tblThanhVien.MaTV= (Select tblDonHang.MaTV from  tblDonHang where tblDonHang.MaDH= "+more+")";
            ada.SelectCommand = comm;
            tbl.Clear();
            ada.Fill(tbl);
            foreach (DataRow r in tbl.Rows)
            {
                
                lbTen.Text = "Họ Tên: " + r["TenTV"].ToString();
                lbDiaChi.Text = "Địa Chỉ: " + r["DiaChi"].ToString();
                lbSDT.Text = "SDT: " + r["SDT"].ToString();
                lbEmail.Text = "Emai: " + r["Email"].ToString();
            }
            txtMaDH.Text = more;
            txtMaDH.Enabled = false;
        }
        protected void btnTatCa_Click(object sender, EventArgs e)
        {
            loadData(0);
        }

        protected void btnDa_Click(object sender, EventArgs e)
        {
            loadData(1);
        }

        protected void bntChua_Click(object sender, EventArgs e)
        {
            loadData(2);
        }

        protected void btnChapNhan_Click(object sender, EventArgs e)
        {
            lbThongBao.Text = "";
            if (txtMaDH.Text.Length == 0)
            {
                lbThongBao.Text = "Vui Lòng chọn đơn hàng";
                return;
            }
            comm = conn.CreateCommand();
            comm.CommandText = "Update tblDonHang set TrangThai='True' where MaDH=" + txtMaDH.Text;
            comm.ExecuteNonQuery();
            lbThongBao.Text = "Đơn Hàng Đã Được Chấp Nhận";
            loadData(0);
            lbTen.Text = "Họ Tên: ";
            lbDiaChi.Text = "Địa Chỉ: ";
            lbSDT.Text = "SDT: ";
            lbEmail.Text = "Emai: ";
            txtMaDH.Text = "";
        }

        protected void btnTuChoi_Click(object sender, EventArgs e)
        {
            lbThongBao.Text = "";
            if (txtMaDH.Text.Length == 0)
            {
                lbThongBao.Text = "Vui Lòng chọn đơn hàng";
                return;
            }
            comm = conn.CreateCommand();
            comm.CommandText = "Update tblDonHang set TrangThai='False' where MaDH=" + txtMaDH.Text;
            comm.ExecuteNonQuery();
            lbThongBao.Text = "Đơn Hàng Đã Được Từ Chối";
            loadData(0);
            lbTen.Text = "Họ Tên: ";
            lbDiaChi.Text = "Địa Chỉ: ";
            lbSDT.Text = "SDT: ";
            lbEmail.Text = "Emai: ";
            txtMaDH.Text = "";
        }
    }
}