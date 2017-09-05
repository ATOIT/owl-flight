using Domain.Entityes;

namespace Domain.Abstrac
{
    public interface IEmailSending
    {
        void SendMailToAdministrator(Basket basket, Order details, string attachFile);
        void SendMail(Basket basket, Order details, string attachFile);
    }
}