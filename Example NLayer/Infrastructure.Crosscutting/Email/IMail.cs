namespace Infrastructure.Crosscutting.Email
{
    public interface IMail
    {
        bool SendMail(string subject, string body, string to, string from, string password, string displayName, string host, int port, bool enableSsl, bool useDefaultCredentials, bool isBodyHtml, string nameHeader, string valueHeader, string message);
        bool Mailing(string subject, string body, string from, string password, string displayName, string host, int port, bool enableSsl, bool useDefaultCredentials, bool isBodyHtml, string nameHeader, string valueHeader, string message, string[] addresses = null, string[] addressesInCopy = null);
       
    }
}
