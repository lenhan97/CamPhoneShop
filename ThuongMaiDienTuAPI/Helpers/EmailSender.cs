using System.Net.Mail;

namespace ThuongMaiDienTuAPI.Helpers
{
    public class EmailSender
    {
        public const string MAIL_ADDRESS = "tmdtservermail@gmail.com";
        public const string HOST = @"http://localhost:57233/";
        private static void Send(string toMail, string title, string content)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(MAIL_ADDRESS);
            mail.To.Add(toMail);
            mail.Subject = title;
            mail.Body = content;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("tmdtservermail@gmail.com", "tmdtservermail123");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
        public static void SendVerifyMail(string toMail, string code)
        {
            string content = "Cảm ơn bạn đã tham gia!!!\n" +
                "Xin click vào link này để xác nhận: " + HOST + "seller/verifymail/" + code;
            Send(toMail, "Xác nhận tài khoản", content);
        }
    }
}
