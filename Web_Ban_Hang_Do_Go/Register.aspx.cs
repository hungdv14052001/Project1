using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Text;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;

namespace Web_Ban_Hang_Do_Go
{
    public partial class Register : System.Web.UI.Page
    {
        string str = @"Data Source=DESKTOP-FA5AISU\SQLEXPRESS;Initial Catalog=WebBanHangDoGo;Integrated Security=True";
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();
        DataTable tbl = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
        }
        public bool testEaN(string email, string num)
        {
            bool kq = true;
            com = con.CreateCommand();
            com.CommandText = "select * from tblThanhVien";
            ada.SelectCommand = com;
            tbl.Clear();
            ada.Fill(tbl);
            foreach(DataRow r in tbl.Rows)
            {
                if(email.Equals(r["Email"].ToString())|| num.Equals(r["SDT"].ToString()))
                {
                    kq = false;
                }
            }
            return kq;
        }
        public bool VerifyEmail(string emailVerify)
        {
            try
            {
                MailAddress m = new MailAddress(emailVerify);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string acc = txtAccount.Value.ToString();
            string pas = txtPassword.Value.ToString();
            string ema = txtEmail.Value.ToString();
            if (VerifyEmail(ema))
            {
                lbThongBao.Text = "Email tồn tại!";
            }
            else
            {
                lbThongBao.Text = "Email Không tồn tại!";
                return;
            }
            if (testEaN(ema, acc))
            {
                lbThongBao.Text = "email và số đt hợp lệ!";
            }
            else
            {
                lbThongBao.Text = "Email hoặc số điện thoại đã được dùng để đăng ký";
            }

        }
    }
}