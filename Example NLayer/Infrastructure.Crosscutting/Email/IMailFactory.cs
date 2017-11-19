namespace Infrastructure.Crosscutting.Email
{
    public interface IMailFactory
    {
        IMail Create();
    }
}
