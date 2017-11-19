namespace Infrastructure.Crosscutting.Email
{
    public static class MailFactory
    {
        static IMailFactory _currentMailFactory = null;

        public static void SetCurrent(IMailFactory mailFactory)
        {
            _currentMailFactory = mailFactory;
        }

        public static IMail CreateMail()
        {
            var imail = _currentMailFactory.Create();
            return (_currentMailFactory != null) ? imail : null;
        }
    }
}
