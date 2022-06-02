using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
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
using Tulpep.NotificationWindow;

namespace Module11_OOP
{
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IClientDataView IConsultant = new Consultant();
        IClientDataView IManager = new Manager();
        
        public string PopupErrorUserChoise = "Выберите пользователя";
        public string PopupSaccessSave = "Успешно сохранено";
        public string PopupErrorAccess = "У вас нет доступа";
        public string PopupCollectionEmpty = "Список пуст";

        private int ComboboxSort = -1;
        private int UserChoiceCombobox= -1;

        public static ObservableCollection<Client>  UserChanges(string UserChanded, string TextboxId,
            string TextboxFirstName, string TextboxLastname, string TextboxFatherName, string TextboxPhone, string TextboxPassport)
        {
            Client client = new Client();
            MainWindow main = new MainWindow();
            ObservableCollection<Client> list = new ObservableCollection<Client>();
            foreach (var item in Bank_A.Clients)
            {

                if (Convert.ToString(item.Id) == TextboxId)
                {
                    if (TextboxLastname == String.Empty || TextboxPhone == String.Empty ||
            TextboxFatherName == String.Empty || TextboxFirstName == String.Empty || TextboxPassport == String.Empty)
                    {
                        MessageBox.Show("Поле должно быть заполненым"); return list;

                    }
                    else
                    {


                        client.user = UserChanded;

                        if (item.FatherName != TextboxFatherName)
                        {
                            client.fatherNamechange = $"{item.FatherName} изменено на- {TextboxFatherName}";
                            
                        }
                        if (item.phoneNumber != TextboxPhone)
                        {
                            client.phonechange = $"{item.PhoneNumber} изменено на- {TextboxPhone}";
                           
                        }
                        if (item.Passport != TextboxPassport)
                        {
                            client.passportchange = $"{item.Passport} изменено на- {TextboxPassport}";
                            
                        }
                        if (item.FirstName != TextboxFirstName)
                        {
                            client.firstNamechange = $"{item.FirstName} изменено на- {TextboxFirstName}";
                            
                        }
                        if (item.LastName != TextboxLastname)
                        {
                            client.lastNamechange = $"{item.LastName} изменено на- {TextboxLastname}";
                            
                        }
                        
                    }
                }
            }
            list.Add(new Client(client.user, client.lastNamechange, client.firstNamechange, client.fatherNamechange,
                client.Phonechange, client.Passportchange));
            return list;
            
        }
        public MainWindow()
        {
            InitializeComponent();
            

        }
        /// <summary>
        /// Метод реализации выбора Combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserChoiceCombobox = ComboboxUserChoise.SelectedIndex;
            if (UserChoiceCombobox == 0)
            {
                SelectionChangedConsultant();
            }
            else if (UserChoiceCombobox == 1)
            {
                SelectionChangedManager();
            }
            else Error.Text ="Выберете пользователя";
           
           

        }
        /// <summary>
        /// Метод реализации выбора Консультанта
        /// </summary>
        private void SelectionChangedConsultant()
        {
                ConsIsReadonly();
                if (File.Exists("Data.json") == true)
                {
                    Bank_A.Clients = Bank_A.Deserialise(Bank_A.Clients);
                }
                if (Bank_A.Clients.Count == 0)
                {
                    return;
                }
                else
                {
                    ListView.ItemsSource = FillClientsDataField(IConsultant);
                }
            
        }
        /// <summary>
        /// Метод реализации выбора Менеджера
        /// </summary>
        private void SelectionChangedManager()
        {
                ManagIsReadonly();
                if (File.Exists("Data.json") == true)
                {
                    Bank_A.Clients = Bank_A.Deserialise(Bank_A.Clients);
                }


                if (Bank_A.Clients == null)
                {
                    return;
                }
                else
                {
                    ListView.ItemsSource = FillClientsDataField(IManager);
                }


            
        }
        /// <summary>
        /// Метод доступа к записи
        /// </summary>
        private void ConsIsReadonly()
        {
            Id.IsReadOnly = true;
            LastName.IsReadOnly = true;
            FirstName.IsReadOnly = true;
            FatherName.IsReadOnly = true;
            Passport.IsReadOnly = true;
            PhoneNumber.IsReadOnly = false;
        }
        /// <summary>
        ///  Метод доступа к записи
        /// </summary>
        private void ManagIsReadonly()
        {
            Id.IsReadOnly = true;
            LastName.IsReadOnly = false;
            FirstName.IsReadOnly = false;
            FatherName.IsReadOnly = false;
            Passport.IsReadOnly = false;
            PhoneNumber.IsReadOnly = false;

        }
        
        /// <summary>
        /// Метод всплывающего оповещения
        /// </summary>
        public static void Popup(string text)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Внимание!";
            popup.ContentText = text;
            popup.Image = SystemIcons.Warning.ToBitmap();
            popup.HeaderColor = System.Drawing.Color.Gray;
            popup.BodyColor = System.Drawing.Color.Black;
            popup.ContentColor = System.Drawing.Color.White;
            popup.TitleColor= System.Drawing.Color.Gray;
            popup.Popup();
        }
        
        private static ObservableCollection<Client>  FillClientsDataField(IClientDataView clientDataView)
        {
            
            ObservableCollection<Client> clients = new ObservableCollection<Client>();
            
                foreach (var item in Bank_A.Clients)
                {
                clients.Add(clientDataView.ViewClientData(new Client(item.Id, item.LastName,
                            item.FirstName, item.FatherName, item.PhoneNumber, item.Passport)));
                }

                return clients;
        }
       
        /// <summary>
        /// Метод вывода нового окна при нажатии на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Add_Costomer(object sender, RoutedEventArgs e)
        {
            if (UserChoiceCombobox == -1)
            {
                Popup(PopupErrorUserChoise); return;
                
            }

            switch (UserChoiceCombobox)
            {
                case 1:
                    AddManager addManager = new AddManager();
                    addManager.Show();
                    this.Close(); break;
                case 0:
                    Popup(PopupErrorAccess); break;

                default:
                    Popup(PopupErrorUserChoise); break;
            }
        }
        /// <summary>
        /// Метод нажаия на кнопку и сохранения изменений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Save_Changed(object sender, RoutedEventArgs e)
        {
            IClientDataViewChange clientDataViewChangeManager = new Manager();
            IClientDataViewChange clientDataViewChangeConsultant = new Consultant();
            Client client = new Client();
            switch (UserChoiceCombobox)
            {
                case 1:
                    client.user = "Менеджер";
                    UserChange.ItemsSource = UserChanges(client.user,Id.Text, FirstName.Text, LastName.Text, FatherName.Text, PhoneNumber.Text, Passport.Text);
                    clientDataViewChangeManager.DataViewChanged(Id.Text, FirstName.Text, LastName.Text, FatherName.Text, PhoneNumber.Text, Passport.Text);
                    ListView.ItemsSource = FillClientsDataField(IManager);
                   
                    break;

                case 0:
                    client.user = "Консультант";
                    UserChange.ItemsSource = UserChanges(client.user,Id.Text, FirstName.Text, LastName.Text, FatherName.Text, PhoneNumber.Text, Passport.Text);
                    clientDataViewChangeConsultant.DataViewChanged(Id.Text, FirstName.Text, LastName.Text, FatherName.Text, PhoneNumber.Text, Passport.Text);
                    ListView.ItemsSource = FillClientsDataField(IConsultant);break;

                default:
                    Popup(PopupErrorUserChoise); 
                    break;
                    
            }
            
        }
        /// <summary>
        /// Метод выбора метода сортировки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboboxSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboboxSort = ComboboxSortBy.SelectedIndex;
            if (UserChoiceCombobox == -1)
            {
                Popup(PopupErrorUserChoise); return;
            }

            if (ListView == null)
            {
                Popup(PopupCollectionEmpty); return;
            }
               
            if (UserChoiceCombobox == 0)
            {
                if (ComboboxSort == 0)
                {
                    ListView.ItemsSource = FillClientsDataFieldSortedbyName(IConsultant);
                }
                else ListView.ItemsSource = FillClientsDataFieldSortedbyLastName(IConsultant);
            }
            else
            {
                if (ComboboxSort == 0)
                {
                    ListView.ItemsSource = FillClientsDataFieldSortedbyName(IManager);
                }
                else ListView.ItemsSource = FillClientsDataFieldSortedbyLastName(IManager);
            }

        }
        /// <summary>
        /// Метод сортировки по алфавиту(Имя)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static List<Client> FillClientsDataFieldSortedbyName(IClientDataView clientDataView)
        {

            List<Client> clients = new List<Client>();

            foreach (var item in Bank_A.Clients)
            {
                clients.Add(clientDataView.ViewClientData(new Client(item.Id, item.LastName,
                        item.FirstName, item.FatherName, item.PhoneNumber, item.Passport)));
            }
            clients.Sort(new Client.SortByName());
            return clients;
        }
        /// <summary>
        /// Метод сортировки по алфавиту(Фамилия)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static List<Client> FillClientsDataFieldSortedbyLastName(IClientDataView clientDataView)
        {

            List<Client> clients = new List<Client>();

            foreach (var item in Bank_A.Clients)
            {
                clients.Add(clientDataView.ViewClientData(new Client(item.Id, item.LastName,
                        item.FirstName, item.FatherName, item.PhoneNumber, item.Passport)));
            }
            clients.Sort(new Client.SortByLastName());
            return clients;
        }
    }
}
