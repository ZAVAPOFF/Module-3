using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notification
{

    public partial class MainWindow : Window
    {
        private Notify notify;

        public MainWindow()
        {
            InitializeComponent();
            notify = new Notify();

            notify.Message += Notify_Message;
            notify.Call += Notify_Call;
            notify.Email += Notify_Email;

            btnMessage.Click += (s, e) => notify.SendMessage("Привет, мир!");
            btnCall.Click += (s, e) => notify.CreateCall("+123456789");
            btnEmail.Click += (s, e) => notify.SendEmail("example@example.com", "Тест", "Это тестовое письмо.");
        }

        private void Notify_Message(object sender, EventArgs e)
        {
            MessageBox.Show("Сообщение отправлено.");
        }

        private void Notify_Call(object sender, EventArgs e)
        {
            MessageBox.Show("Звонок совершен.");
        }

        private void Notify_Email(object sender, EventArgs e)
        {
            MessageBox.Show("Электронное письмо отправлено.");
        }
    }
}

