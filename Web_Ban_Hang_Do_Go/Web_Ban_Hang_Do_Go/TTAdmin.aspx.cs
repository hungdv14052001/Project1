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
    public partial class TTAdmin : System.Web.UI.Page
    {
        string str = @"Data Source=DESKTOP-FA5AISU\SQLEXPRESS;Initial Catalog=WebBanHangDoGo;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataTable tbl = new DataTable();
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
        void loadData()
        {
            comm = conn.CreateCommand();
            comm.CommandText = "Select * from tblAdmin";
            adp.SelectCommand = comm;
            tbl.Clear();
            adp.Fill(tbl);
            foreach(DataRow r in tbl.Rows)
            {
                if (Session["MaAd"].ToString().Equals(r["MaAd"].ToString()))
                {
                    lbTen.Text = r["TenAd"].ToString();
                    lbUsername.Text = r["Username"].ToString();
                }
            }
        }
    }
}