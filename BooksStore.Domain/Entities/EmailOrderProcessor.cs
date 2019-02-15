using BooksStore.Domain.Abstract;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BooksStore.Domain.Entities
{
    public class EmailOrderProcessor : IOrderProcessor
    {
        EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings emailSettings) => this.emailSettings = emailSettings;
        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {
            using(var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder();
                body.AppendLine("A new order has been sent\n");
                body.AppendLine("Items:");
                foreach(var item in cart.Items)
                    body.AppendLine($"{item.Book.BookId} {item.Book.Title} {item.Quantity} {item.Book.Price * item.Quantity,2:c}");
                body.AppendLine($"\nTOTAL: {cart.TotalValue(),2:c}\n");
                body.AppendLine("Ship to:");
                body.AppendLine($"Name: {shippingDetails.Name}");
                body.AppendLine($"Email: {shippingDetails.Email}");
                body.AppendLine($"Phone: {shippingDetails.Phone}");
                body.AppendLine($"Address: {shippingDetails.Address}");
                body.AppendLine($"City: {shippingDetails.City}");
                body.AppendLine($"Gift wrap: {(shippingDetails.GiftWrap ? "yes" : "no")}");

                MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAddress, emailSettings.MailToAddress, "New order!", body.ToString());

                if (emailSettings.WriteAsFile)
                    mailMessage.BodyEncoding = Encoding.ASCII;

                smtpClient.Send(mailMessage);
            }
        }
    }

    public class EmailSettings
    {
        public string MailToAddress { get; set; } = "orders@example.com";
        public string MailFromAddress { get; set; } = "booksstore@example.com";
        public bool UseSsl { get; set; } = true;
        public string Username { get; set; } = "SmtpUsername";
        public string Password { get; set; } = "SmtpPassword";
        public string ServerName { get; set; } = "smtp.example.com";
        public int ServerPort { get; set; } = 587;
        public bool WriteAsFile { get; set; } = false;//for file
        public string FileLocation { get; set; } = @"c:\books_store_emails";//folder for example
    }
}