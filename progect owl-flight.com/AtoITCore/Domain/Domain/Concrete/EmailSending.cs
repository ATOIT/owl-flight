using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using Domain.Abstrac;
using Domain.Entityes;

namespace Domain.Concrete
{
    /// <summary>
    /// Класс для отправки писем на почту
    /// </summary>
    public class EmailSending : IEmailSending
    {
        /// <summary>
        /// Отправка письма администратору
        /// </summary>
        public  void SendMailToAdministrator(Basket basket, Order details, string attachFile = null)
        {
            try
            {
                //c какой почты отправляем письмо 
                MailMessage mail = new MailMessage { From = new MailAddress("owl-flight.com@test.com") };
                mail.To.Add(new MailAddress("owl-flight.com@test.com")); // E-mail Администратора
                mail.Subject = "Новий заказ";
                mail.Body = EmailMessageToAdministrator(basket, details);
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    //c какой почты отправляем письмо + пароль от этой почты
                    Credentials = new NetworkCredential("owl-flight.com@test.com".Split('@')[0], "123456789"),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                client.Send(mail);
                mail.Dispose();
            }
            catch
            {
                // ignored
            }
        }
        /// <summary>
        /// ОТПРАВКА ПИСЬМА ПОЛЬЗОВАТЕЛЮ
        /// </summary>
        public void SendMail(Basket basket, Order details, string attachFile = null)
        {
            try
            {
                //c какой почты отправляем письмо
                MailMessage mail = new MailMessage { From = new MailAddress("owl-flight.com@test.com") };
                mail.To.Add(new MailAddress(details.Email)); //получаем E-mail который ввел пользователь
                mail.Subject = "owl-flight.com"; // тема письма
                mail.Body = EmailMessage(basket, details);
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient
                {
                    Host = "smtp.gmail.com", //Хост
                    Port = 587,//Порт
                    EnableSsl = true,
                    //c какой почты отправляем письмо + пароль от этой почты
                    Credentials = new NetworkCredential("owl-flight.com@test.com".Split('@')[0], "123456789"),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                client.Send(mail);
                mail.Dispose();
                basket.AnswerList.Add($"Шановний(а), {details.ClientName}! ");
                basket.AnswerList.Add("Дякуємо Вам за покупку!");
                basket.AnswerList.Add($"На Ваш E-mail ({details.Email}) вислані всі деталі замовлення.");
                basket.AnswerList.Add("Замовлення відправлений в обробку, скоро ми з вами зв'яжемося, гарного вам дня!");
            }
            catch (Exception)
            {
                basket.AnswerList.Clear();
                basket.AnswerList.Add($"Щось пішло не так, ми не змогли відправити лист на Ваш E-mail ({details.Email}) ");
                basket.AnswerList.Add("");
                basket.AnswerList.Add("Просимо вибачення, за технічні проблеми.");
                basket.AnswerList.Add("");
                basket.AnswerList.Add("Ваше замовлення передано адміністратору, скоро ми з вами зв'яжемося, гарного вам дня!");
                basket.AnswerList.Add("");
               
            }
        }

        /// <summary>
        /// формирование текста письма для пользователя
        /// </summary>
        public static string EmailMessage(Basket basket, Order details)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("");
            str.AppendFormat($"Доброго дня, шановний(а) {details.ClientName}!");
            str.AppendLine("");
            str.AppendLine("Дякуемо за покупку на сайті - owl-flight.com !");
            str.AppendLine("");
            str.AppendLine("");
            str.AppendLine("Детали заказу:");
            str.AppendLine("");
            foreach (var i in basket.Lines)
            {
                str.AppendFormat($" Футболка  -  \"{i.Product.Name}\"  вартістью - {i.Product.Price} грн. Розмір - {i.Size}");
                str.AppendLine("");
            }
            str.AppendLine("");
            str.AppendFormat($"Загальна сума замовлення - {basket.ComputeTotalValue()} грн.");
            str.AppendLine("");
            str.AppendLine("");

            str.AppendFormat($"обрана Вами доставка - {details.Delivery}");
            str.AppendLine("");
            str.AppendFormat($"обрана Вами форма оплаты - {details.Payment}");
            str.AppendLine("");
            if (!string.IsNullOrEmpty(details.Address))
            {
                str.AppendLine($"Адреса доставки - {details.Address}");
                str.AppendLine("");
            }
            if (!string.IsNullOrEmpty(details.Сomment))
            {
                str.AppendLine($"Ваш коментар - {details.Сomment}");
                str.AppendLine("");
            }
            str.AppendLine("");
            str.AppendFormat("Дата заказу -  {0:U}", details.DateOrder);
            str.AppendLine("");
            str.AppendLine("Замовлення відправлений в обробку, скоро ми з вами зв'яжемося, гарного вам дня!");

            return str.ToString();
        }
        /// <summary>
        /// метод для формирования тела письма Администратору
        /// </summary>
        public static string EmailMessageToAdministrator(Basket basket, Order details)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("");
            str.AppendLine("Доброго дня!");
            str.AppendLine("Ви отримали новий заказ з сайту - owl-flight.com!");
            str.AppendLine("");
            str.AppendLine("");
            str.AppendLine("Замовлені товари:");
            str.AppendLine("");
            foreach (var i in basket.Lines)
            {
                str.AppendFormat($"Футболка  -  \"{i.Product.Name}\"  вартістью - {i.Product.Price} грн. Розмір - {i.Size}");
                str.AppendLine("");
            }
            str.AppendLine("");
            str.AppendLine("");
            str.AppendLine("Подробиці замовлення:");
            str.AppendFormat($"Им'я покупця - {details.ClientName}");
            str.AppendLine("");
            str.AppendFormat($"E-mail покупця - {details.Email}");
            str.AppendLine("");
            str.AppendFormat($"Телефон покупця - {details.Phone}");
            str.AppendLine("");
            str.AppendFormat($"Доставка - {details.Delivery}");
            str.AppendLine("");
            str.AppendFormat($"Оплата - {details.Payment}");
            str.AppendLine("");
            if (!string.IsNullOrEmpty(details.Address))
            {
                str.AppendLine($"Адреса - {details.Address}");
                str.AppendLine("");
            }
            if (!string.IsNullOrEmpty(details.Сomment))
            {
                str.AppendLine($"Коментар до заказу - {details.Сomment}");
                str.AppendLine("");
            }
            str.AppendLine("");
            str.AppendLine("");
            str.AppendFormat("Дата заказу -  {0:U}", details.DateOrder);
            return str.ToString();
        }

    }
}
