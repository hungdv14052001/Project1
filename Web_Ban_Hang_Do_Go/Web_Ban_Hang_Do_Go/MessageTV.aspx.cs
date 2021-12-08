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
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
        }
        
    }
}