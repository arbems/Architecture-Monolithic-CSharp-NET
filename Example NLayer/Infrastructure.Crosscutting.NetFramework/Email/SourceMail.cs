namespace Infrastructure.Crosscutting.NetFramework.Email
{
    using Infrastructure.Crosscutting.Email;
    using Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Logging;
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
        //Envio correo
        SmtpClient smtp = new SmtpClient();
        MailMessage email = new MailMessage();

        public SourceMail()
        {
            smtp.Host = "gelook-info.correoseguro.dinaserver.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
        }

        public bool SendMail(string _subject, string _body, string _to, string _from, string _error)
        {
            //SendMailDkim(_subject, _body, _to, _from, _error);
            //EnviarCorreo();

            smtp.Credentials = new NetworkCredential(_from, "LXnYJ2W3");
            email.Subject = _subject;
            email.Body = _body;
            email.From = new MailAddress(_from, "Gelook");
            email.To.Add(_to);
            email.IsBodyHtml = true;

            try
            {
                smtp.Send(email);
                email.Dispose();
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().LogError(_error, ex.Message, _to);
                return false;
            }

            return true;
        }

        public void SendMailDkim(string _subject, string _body, string _to, string _from, string _error)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Joey", _from));
            message.To.Add(new MailboxAddress("Alice", "arbems@outlook.com"));
            message.Subject = _subject;

            var builder = new BodyBuilder();
            // Set the html version of the message text
            builder.HtmlBody = _body;
            // Now we just need to set the message body and we're done
            message.Body = builder.ToMessageBody ();

var headersToSign = new [] { HeaderId.From, HeaderId.To, 
    HeaderId.Subject, HeaderId.Date };
var signer = new DkimSigner(@"C:\Users\ArBe\Documents\Copias de seguridad\GELOOK\DESARROLLO\2.Web\NLayerGelook2_Design\Infrastructure.Crosscutting.NetFramework\my-dkim-key.pem", "gelook.info", "default");

message.Sign (signer, headersToSign, 
    DkimCanonicalizationAlgorithm.Relaxed, 
    DkimCanonicalizationAlgorithm.Simple);

            SendMessage(message);
            
        }
        static AsymmetricKeyParameter readPrivateKey(string privateKeyFileName)
        {
            AsymmetricCipherKeyPair keyPair;

            using (var reader = File.OpenText(privateKeyFileName))
                keyPair = (AsymmetricCipherKeyPair)new PemReader(reader).ReadObject();

            return keyPair.Private;
        }
        public static void SendMessage(MimeMessage message)
        {
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("gelook-info.correoseguro.dinaserver.com", 587, false);

               client.Authenticate("equipo@gelook.info", "LXnYJ2W3");

                client.Send(message);

                client.Disconnect(true);
            }
        }



        public void EnviarCorreo()
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add("arbems@gmail.com");

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = "Pruebas";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("destinatariocopia@servidordominio.com"); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = "Pruebas numero 2";
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("equipo@gelook.info");
            //mmsg.Headers.Add("X-DKIM-Result", "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC9gXyw/XfOruQiZP0kFirVperrHPkAL5R3ByVIWi2S/4SJg/matONaXTChew8yncUObrYAHfqmQbQ9uFLch18+eQVhp7FQX67XybEWgJ58tY2J/5vvCkGJjq7PHQ7QwMTBwCiIJFCC2CKnG+cwO9cax9EzRJgSbRBJ2UWtMZndLwIDAQAB");


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials = new System.Net.NetworkCredential("equipo@gelook.info", "LXnYJ2W3");

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.UseDefaultCredentials = false;


            cliente.Host = "gelook-info.correoseguro.dinaserver.com"; //Para Gmail "smtp.gmail.com";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }

    }
}
