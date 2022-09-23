using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();

            DoubleAnimation btnAnimation = new DoubleAnimation();
            btnAnimation.From = 0;
            btnAnimation.To = 450;
            btnAnimation.Duration = TimeSpan.FromSeconds(3);
            reqButton.BeginAnimation(Button.WidthProperty, btnAnimation);

        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxlogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass2 = passBox2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();
            if (login.Length < 5)
            {
                textBoxlogin.ToolTip = "Логин не корректен";
                textBoxlogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Введённые пароли не совпадают";
                passBox.Background = Brushes.DarkRed;
            }
            else if (pass != pass2)
            {
                passBox2.ToolTip = "Введённые пароли не совпадают";
                passBox2.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Имейл введён не корректно";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxlogin.ToolTip = "";
                textBoxlogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBox2.ToolTip = "";
                passBox2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;
                MessageBox.Show("Регистрация прошла успешно");

                User user = new User(login, pass, email);

                db.Users.Add(user);
                db.SaveChanges();


                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();
            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
