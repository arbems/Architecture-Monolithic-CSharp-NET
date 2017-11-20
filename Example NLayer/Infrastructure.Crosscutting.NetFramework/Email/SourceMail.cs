namespace Infrastructure.Crosscutting.NetFramework.Email
{
    using Infrastructure.Crosscutting.Email;
    using Infrastructure.Crosscutting.Logging;
    using MimeKit;
    using MimeKit.Cryptography;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.OpenSsl;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Mail;

    public sealed class SourceMail : IMail
    {
        public bool SendMail(string subject, string body, string to, string from, string password, string displayName, string host, int port, bool enableSsl, bool useDefaultCredentials, bool isBodyHtml, string nameHeader, string valueHeader, string message)
        {
            var mail = new MailMessage();

            mail.Subject = subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = body;
            mail.From = new MailAddress(from, displayName);
            mail.To.Add(to);
            mail.IsBodyHtml = isBodyHtml;
            mail.Headers.Add(nameHeader, valueHeader);

            var smtp = new SmtpClient();

            smtp.Credentials = new NetworkCredential(from, password);
            smtp.Host = host;
            smtp.Port = port;
            smtp.EnableSsl = enableSsl;
            smtp.UseDefaultCredentials = useDefaultCredentials;

            try
            {
                smtp.Send(mail);
                mail.Dispose();
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                LoggerFactory.CreateLog().LogError(message, ex.Message, "System.Net.Mail.SmtpException: SendMail to: " + to);
                return false;
            }

            return true;
        }

        public bool Mailing(string subject, string body, string from, string password, string displayName, string host, int port, bool enableSsl, bool useDefaultCredentials, bool isBodyHtml, string nameHeader, string valueHeader, string message, string[] addresses = null, string[] addressesInCopy = null)
        {
            var mail = new MailMessage();

            mail.Subject = subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = body;
            mail.From = new MailAddress(from, displayName);
            mail.IsBodyHtml = isBodyHtml;
            mail.Headers.Add(nameHeader, valueHeader);

            foreach (var address in addresses)
                mail.To.Add(address);
            foreach (var address in addressesInCopy)
                mail.Bcc.Add(address);            

            var smtp = new SmtpClient();

            smtp.Credentials = new NetworkCredential(from, password);
            smtp.Host = host;
            smtp.Port = port;
            smtp.EnableSsl = enableSsl;
            smtp.UseDefaultCredentials = useDefaultCredentials;

            try
            {
                smtp.Send(mail);
                mail.Dispose();
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                LoggerFactory.CreateLog().LogError(message, ex.Message, "System.Net.Mail.SmtpException: Mailing to: " + string.Join(",", addresses));
                return false;
            }

            return true;
        }

        void SendMailDkim(string subject, string body, string to, string from, string password, string displayNameTo, string displayNameFrom, string host, int port, bool useSsl, bool useDefaultCredentials, string domain, string selector, string[] addresses, string[] addressesCopy, string message)
        {
            var mimeMessage = new MimeMessage();

            mimeMessage.From.Add(new MailboxAddress(displayNameFrom, from));
            mimeMessage.To.Add(new MailboxAddress(displayNameTo, to));
            mimeMessage.Subject = subject;

            var builder = new BodyBuilder();
            // Set the html version of the message text
            builder.HtmlBody = body;
            // Now we just need to set the message body and we're done
            mimeMessage.Body = builder.ToMessageBody();

            var headersToSign = new[] { HeaderId.From, HeaderId.To, HeaderId.Subject, HeaderId.Date };
            var signer = new DkimSigner(@"C:\my-dkim-key.pem", domain, selector);

            mimeMessage.Sign(signer, headersToSign, DkimCanonicalizationAlgorithm.Relaxed, DkimCanonicalizationAlgorithm.Simple);

            SendMessage(mimeMessage, from, password, host, port, useSsl);

        }
        static AsymmetricKeyParameter readPrivateKey(string privateKeyFileName)
        {
            AsymmetricCipherKeyPair keyPair;

            using (var reader = File.OpenText(privateKeyFileName))
                keyPair = (AsymmetricCipherKeyPair)new PemReader(reader).ReadObject();

            return keyPair.Private;
        }
        static void SendMessage(MimeMessage msg, string address, string password, string host, int port, bool useSsl)
        {
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(host, port, useSsl);

                client.Authenticate(address, password);

                client.Send(msg);

                client.Disconnect(true);
            }
        }

    }
}
