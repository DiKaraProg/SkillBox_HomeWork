using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Module11_OOP
{
    /// <summary>
    /// Логика взаимодействия для AddManager.xaml
    /// </summary>
     public partial class AddManager : Window
    {
        public AddManager()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод очистки всех TextBox
        /// </summary>
        private void TextBox_Delete()
        {
            FirstName.Text = String.Empty;
            LastName.Text = String.Empty;
            FatherName.Text = String.Empty;
            PhoneNumber.Text = String.Empty;
            Passport.Text = String.Empty;
        }
        /// <summary>
        /// Метод добавления нового клиента при нажимании на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Add_New_Client(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Client> test = new ObservableCollection<Client>();
            int num;
            if (LastName.Text.Length!=0 && FirstName.Text.Length!=0 &&
                FatherName.Text.Length!=0 && PhoneNumber.Text.Length!=0 && Passport.Text.Length!=0)//Проверка все ли поля заполнены
            {
                if (Bank_A.Clients==null)//проверка пустая ли коллекция всех клиентов
                {
                    num = 1;
                    test.Add(new Client(num,  LastName.Text, FirstName.Text,
                    FatherName.Text, PhoneNumber.Text, Passport.Text));

                    Bank_A.Clients = test;
                    Bank_A.Serialise(Bank_A.Clients);
                    MainWindow.Popup("Успешно сохранено");
                }
                else
                {
                    num = Bank_A.Clients.Count + 1;
                    Bank_A.Clients.Add(new Client(num,  LastName.Text, FirstName.Text,
                   FatherName.Text, PhoneNumber.Text, Passport.Text));
                    Bank_A.Serialise(Bank_A.Clients);
                    MainWindow.Popup("Успешно сохранено");
                }
            }
            else
            {
                MainWindow.Popup("Не все поля заполнены");
            }
            TextBox_Delete();
        }
        /// <summary>
        /// Метод закрытия текущего окна и открытия MainWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
            

        }
    }
}
