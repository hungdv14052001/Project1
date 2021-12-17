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
        public void loadMessBox(string more)
        {
            comm = conn.CreateCommand();
            comm.CommandText = "SELECT * FROM ( SELECT TOP 20 * FROM tblMessage ORDER BY tblMessage.IdMes DESC ) tblMessage WHERE tblMessage.MaTV= " + more + " ORDER BY tblMessage.IdMes ASC";
            adp.SelectCommand = comm;
            ds.Clear();
            adp.Fill(ds);
            DLMess.DataSource = ds;
            DLMess.DataBind();
        }
        protected void lbtnKH_Click(Object sender, EventArgs e)
        {
            LinkButton btnClick = (LinkButton)sender;
            string more = btnClick.CommandArgument.ToString();
            loadMessBox(more);
            Session["id"] = more;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string more;
            if (Session["id"].ToString().Length == 0)
            {
                return;
            }
            else
            {
                more = Session["id"].ToString();
            }
            if (txtMess.Text.Length == 0)
            {
                return;
            }
            else
            {
                string MessCon = txtMess.Text;
                comm = conn.CreateCommand();
                comm.CommandText = "insert into tblMessage(MessContent, isAd, MaTV) values(N'"+MessCon+"', 'True', "+more+")";
                comm.ExecuteNonQuery();
                txtMess.Text = "";
                loadMessBox(more);
            }
        }
    }
}