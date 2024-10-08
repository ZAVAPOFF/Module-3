using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    public class Notify
    {
            public event EventHandler Message;
            public event EventHandler Call;
            public event EventHandler Email;

            public void SendMessage(string mes)
            {
                Message?.Invoke(this, EventArgs.Empty);
                Console.WriteLine($"Сообщение отправлено: {mes}");
            }

            public void CreateCall(string numb)
            {
                Call?.Invoke(this, EventArgs.Empty);
                Console.WriteLine($"Звонок совершен на номер: {numb}");
            }

            public void SendEmail(string address, string theme, string text)
            {
                Email?.Invoke(this, EventArgs.Empty);
                Console.WriteLine($"Электронное письмо отправлено на адрес: {address}, Тема: {theme}, Текст: {text}");
            }
        }

}
