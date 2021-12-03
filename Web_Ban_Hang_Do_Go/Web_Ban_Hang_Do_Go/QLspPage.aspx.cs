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
    public partial class QLspPage : System.Web.UI.Page
    {
        static int CurrentPage;
        string str = @"Data Source=DESKTOP-FA5AISU\SQLEXPRESS;Initial Catalog=WebBanHangDoGo;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        PagedDataSource pds = new PagedDataSource();
        protected void Page_Load(object sender, EventArgs e)
        {
            KT();
            conn = new SqlConnection(str);
            conn.Open();
            loadData();
        }
        void KT()
        {
            if ((Boolean)Session["admin"] == false)
            {
                Response.Redirect("HomePage.aspx");
            }
        }
        public void loadData()
        {
           
            comm = conn.CreateCommand();
            comm.CommandText = "select * from tblSanPham";
            adp.SelectCommand = comm;
            ds.Clear();
            adp.Fill(dt);
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 9;
            pds.CurrentPageIndex = CurrentPage;
            bntNext.Enabled = !pds.IsLastPage;
            bntPrev.Enabled = !pds.IsFirstPage;
            DLSanPham.DataSource = pds;
            DLSanPham.DataBind();
        }

        protected void bntPrev_Click(object sender, EventArgs e)
        {
            CurrentPage-=1;
            loadData();
        }

        protected void bntNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            loadData();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string MaSP = txtMaSP.Text;
            string TenSP = txtTenSP.Text;
            string LoaiDM = txtLoaiDM.Text;
            string LoaiSP = txtLoaiSP.Text;
            string ChatLieu = txtChatLieu.Text;
            int Gia;
            try
            {
                Gia = int.Parse(txtGia.Text);
            }
            catch(Exception exp)
            {
                lbThongBao.Text = "Giá Tiền Phải Là Số!";
                return;
            }
            string Mota = txtMoTa.Value.ToString();
            string TSKT = txtTSKT.Text;
            if (MaSP.Length == 0|| TenSP.Length == 0 || LoaiDM.Length == 0 || LoaiSP.Length == 0 || ChatLieu.Length == 0 ||
                Mota.Length == 0 || TSKT.Length == 0 )
            {
                lbThongBao.Text = "Vui Lòng Nhập Đầy Đủ Thông Tin SP!";
                return;

            }
            string ImgUrl;
            if (ful.HasFile)
            {
                ImgUrl = "./imgUpload/" + ful.FileName;
                ful.SaveAs(Server.MapPath("./imgUpload/" + ful.FileName));
                lbThongBao.Text = ImgUrl;
            }
            else
            {
                lbThongBao.Text = "Vui Lòng Chọn File Hình Ảnh";
                return;
            }
            
            try
            {
                comm = conn.CreateCommand();
                comm.CommandText = "insert into tblSanPham(MaSP, TenSP, LoaiDM, LoaiSP, ChatLieu, Gia, AnhMH, Mota, TSKT, LuotXem) " +
                    "values(N'" + MaSP + "', N'" + TenSP + "', N'" + LoaiDM + "', N'" + LoaiSP + "', " +
                    "N'" + ChatLieu + "', " + Gia + ", N'" + ImgUrl + "', N'" + Mota + "', N'" + TSKT + "', 0)";
                comm.ExecuteNonQuery();
            }
            catch(Exception exp)
            {
                lbThongBao.Text = "Mã Sản Phẩm Đã Tồn Tại, Vui Lòng Tìm Mã Khác";
                return;
            }
            loadData();
            lbThongBao.Text = "Thêm Sản Phẩm Thành Công";
            CurrentPage = 0;
            resetText();
        }

        public void resetText()
        {
            txtMaSP.Text = "";
            txtMaSP.Enabled = true;
            txtTenSP.Text = "";
            txtLoaiDM.Text = "";
            txtLoaiDM.Enabled = true;
            txtLoaiSP.Text = "";
            txtLoaiSP.Enabled = true;
            txtChatLieu.Text = "";
            txtGia.Text = "";
            txtMoTa.Value = "";
            txtTSKT.Text = "";
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (!txtMaSP.Enabled)
            {
                comm = conn.CreateCommand();
                comm.CommandText = "update tblSanPham set TenSP= N'" + txtTenSP.Text + "', " +
                    "ChatLieu= N'" + txtChatLieu.Text + "', Gia=" + txtGia.Text + ", Mota= N'" + txtMoTa.Value.ToString() +"', TSKT= N'"+txtTSKT.Text+"'" +
                    " where MaSP= N'" + txtMaSP.Text + "'";
                comm.ExecuteNonQuery();
                resetText();
                loadData();
                lbThongBao.Text = "Update Sản Phẩm Thành Công";
            }
            else
            {
                lbThongBao.Text = "Vui Lòng Chọn Sản Phẩm Để Sửa!";
            }
        }
        protected void btnDoDL_Click(Object sender, EventArgs e)
        {
            LinkButton btnClick = (LinkButton)sender;
            string more = btnClick.CommandArgument.ToString();
            comm = conn.CreateCommand();
            comm.CommandText = "select * from tblSanPham";
            adp.SelectCommand = comm;
            dt.Clear();
            adp.Fill(dt);
            foreach(DataRow r in dt.Rows)
            {
                if (more.Equals(r["MaSP"].ToString()))
                {
                    txtMaSP.Text = r["MaSP"].ToString();
                    txtMaSP.Enabled = false;
                    txtTenSP.Text = r["TenSP"].ToString();
                    txtLoaiDM.Text = r["LoaiDM"].ToString();
                    txtLoaiDM.Enabled = false;
                    txtLoaiSP.Text = r["LoaiSP"].ToString();
                    txtLoaiSP.Enabled = false;
                    txtChatLieu.Text = r["ChatLieu"].ToString();
                    txtGia.Text = r["Gia"].ToString();
                    txtMoTa.Value = r["Mota"].ToString();
                    txtTSKT.Text = r["TSKT"].ToString();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            resetText();
            loadData();
            lbThongBao.Text = "";
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (!txtMaSP.Enabled)
            {
                comm = conn.CreateCommand();
                comm.CommandText = "Delete from tblSanPham where MaSP= N'" + txtMaSP.Text + "'";
                comm.ExecuteNonQuery();
                resetText();
                lbThongBao.Text = "Xóa Sản Phẩm Thành Công";
            }
            else
            {
                lbThongBao.Text = "Vui Lòng Chọn Sản Phẩm Để Xóa!";
            }
            loadData();
        }
    }
}