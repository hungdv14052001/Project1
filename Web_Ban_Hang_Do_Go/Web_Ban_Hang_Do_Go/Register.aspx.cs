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
using System.IO;
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
            if (!VerifyEmail(ema))
            {
                lbThongBao.Text = "Email không tồn tại!";
                return;
            }
            if (testEaN(ema, acc))
            {
                lbThongBao.Text = "Email và số đt hợp lệ!";
            }
            else
            {
                lbThongBao.Text = "Email hoặc số điện thoại đã được dùng để đăng ký";
                return;
            }
            com = con.CreateCommand();
            com.CommandText="insert into tblThanhVien(TenTV, SDT, Email, Password, DiaChi, NgayTao)" +
                " values(N'"+""+ "', N'" + acc + "', N'" + ema + "', N'" + pas + "', N'" + "" + "', '"+DateTime.Now.ToString("MM-dd-yyyy")+"'); " +
                "insert into tblGioHang(MaTV, TongTien) values((select MaTV from tblThanhVien where tblThanhVien.Email= N'"+ema+"'), 0);";
            com.ExecuteNonQuery();
            ThongBaoMK(ema, pas);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "RegisterSucess()", true);
            Response.Redirect("HomePage.aspx");
        }
        void ThongBaoMK(string email, string pass)
        {
            string tb = "Để chánh trường hợp mất tài khoản hoặc bị xâm phạm tại khoản, vui lòng không chia sẻ mật khẩu với ai. Mật Khẩu để đăng nhập trang web Đồ Gỗ Văn Hùng là: " 
                + pass + ".\nĐồ Gỗ Văn Hùng ";
            // tạo một tin nhắn và thêm những thông tin cần thiết như: ai gửi, người nhận, tên tiêu đề, và có đôi lời gì cần nhắn nhủ
            MailMessage mail = new MailMessage("DoGoVanHung1405@gmail.com", email, "Thông Báo Mật Khẩu", tb); //
            mail.IsBodyHtml = true;
            //gửi tin nhắn
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Host = "smtp.gmail.com";
            //ta không dùng cái mặc định đâu, mà sẽ dùng cái của riêng mình
            client.UseDefaultCredentials = false;
            client.Port = 587; //vì sử dụng Gmail nên mình dùng port 587
                               // thêm vào credential vì SMTP server cần nó để biết được email + password của email đó mà bạn đang dùng
            client.Credentials = new System.Net.NetworkCredential("DoGoVanHung1405@gmail.com", "hung14052001");
            client.EnableSsl = true; //vì ta cần thiết lập kết nối SSL với SMTP server nên cần gán nó bằng true
            client.Send(mail);
        }
    }
}