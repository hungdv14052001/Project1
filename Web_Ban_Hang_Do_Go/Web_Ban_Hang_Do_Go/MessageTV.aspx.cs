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
    public partial class MessageTV : System.Web.UI.Page
    {
        string str = @"Data Source=DESKTOP-FA5AISU\SQLEXPRESS;Initial Catalog=WebBanHangDoGo;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataTable tbl = new DataTable();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            loadMess();
        }
        public void loadMess()
        {
            string more;
            if (Session["id"].ToString().Length == 0)
            {
                more = "0";
            }
            else
            {
                more = Session["id"].ToString();
            }
            comm = conn.CreateCommand();
            comm.CommandText = "SELECT * FROM ( SELECT TOP 8 * FROM tblMessage ORDER BY tblMessage.IdMes DESC ) tblMessage WHERE tblMessage.MaTV= "+more+" ORDER BY tblMessage.IdMes ASC";
            adp.SelectCommand = comm;
            ds.Clear();
            adp.Fill(ds);
            DLMess.DataSource = ds;
            DLMess.DataBind();
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
                comm.CommandText = "insert into tblMessage(MessContent, isAd, MaTV) values('"+MessCon+"', 'false', "+more+")";
                comm.ExecuteNonQuery();
                txtMess.Text = "";
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}