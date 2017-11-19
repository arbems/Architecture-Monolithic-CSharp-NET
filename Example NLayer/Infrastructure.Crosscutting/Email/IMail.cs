namespace Infrastructure.Crosscutting.Email
{
    public interface IMail
    {
        bool SendMail(string _subject, string _body, string _to, string _from, string _error);
    }
}
