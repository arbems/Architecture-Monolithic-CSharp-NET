namespace Infrastructure.Crosscutting.NetFramework.Email
{
    using Infrastructure.Crosscutting.Email;
    public class SourceMailFactory
        :IMailFactory
    {
        public IMail Create()
        {
            return new SourceMail();
        }
    }
}
