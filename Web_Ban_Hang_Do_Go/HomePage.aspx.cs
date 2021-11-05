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
    public partial class HomePage : System.Web.UI.Page
    {
        string str = @"Data Source=DESKTOP-FA5AISU\SQLEXPRESS;Initial Catalog=WebBanHangDoGo;Integrated Security=True";
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            loadData();
        }

        public void loadData()
        {
            com = con.CreateCommand();
            string a = this.loadnb().ToString();
            com.CommandText = "select * from tblSanPham where LuotXem >= "+ a;
            ada.SelectCommand = com;
            DataSet ds = new DataSet();
            ada.Fill(ds);
            DLSPNB.DataSource = ds;
            DLSPNB.DataBind();
            
        }
        public int loadnb()
        {
            com = con.CreateCommand();
            com.CommandText = "select * from tblSanPham";
            ada.SelectCommand = com;
            DataTable tbl = new DataTable();
            ada.Fill(tbl);
            int[] a = new int[100];
            int i = 0;
            foreach (DataRow r in tbl.Rows)
            {
                a[i] = int.Parse(r["LuotXem"].ToString());
                i++;
            }
            for(int j= 0; j< i-1; j++)
            {
                for(int k= 0; k< i-j-1; k++)
                {
                    if (a[k] < a[k + 1])
                    {
                        int tem = a[k];
                        a[k] = a[k + 1];
                        a[k + 1] = tem;
                    }
                }
            }
            return a[5];
        }
    }
}