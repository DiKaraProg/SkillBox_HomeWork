using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module11_OOP
{


    public class Client
    {
        MainWindow mainWindow = new MainWindow();

        public int id;
        public string firstName;
        public string lastName;
        public string fatherName;
        public string phoneNumber;
        public string passport;
        public string user;
        public string phonechange;
        public string lastNamechange;
        public string firstNamechange;
        public string fatherNamechange;
        public string passportchange;
        public string time;


        public int Id { get { return this.id; } set { id = value; } }
        public string FirstName { get { return this.firstName; } set { firstName = value; } }
        public string LastName { get { return this.lastName; } set { lastName = value; } }
        public string FatherName { get { return this.fatherName; } set { fatherName = value; } }
        public string PhoneNumber { get { return this.phoneNumber; } set { phoneNumber = value; } }
        public string Passport { get { return this.passport; } set { passport = value; } }
        public string User { get { return this.user; } }
        public string Phonechange { get { return this.phonechange; } }
        public string LastNamechange { get { return this.lastNamechange; } }
        public string FirstNamechange { get { return this.firstNamechange; } }
        public string FatherNamechange { get { return this.fatherNamechange; } }
        public string Passportchange { get { return this.passportchange; } }
        public string TimeNow { get { return DateTime.Now.ToString(); } }

        public string FatherNameChange { get; internal set; }

        public Client(string User,string LastNamechange, string FirstNamechange, string FatherNamechange, string Phonechange,string Passportchange)
        {
            this.user = User;
            this.lastNamechange = LastNamechange;
            this.firstNamechange = FirstNamechange;
            this.fatherNamechange = FatherNamechange;
            this.phonechange = Phonechange;
            this.passportchange = Passportchange;

    }
       
        public Client(int Id, string LastName, string FirstName, string FatherName,
            string PhoneNumber, string Passport)
        {
            this.id = Id;
            this.lastName = LastName;
            this.firstName = FirstName;
            this.fatherName = FatherName;
            this.phoneNumber = PhoneNumber;
            this.passport = Passport;
        }

        public Client()
        {
        }

        public class SortByName : IComparer<Client>
        {
            public int Compare(Client x, Client y)
            {
                Client X = (Client)x;
                Client Y = (Client)y;

                return String.Compare(X.firstName, Y.firstName);
            }
        }
        public class SortByLastName : IComparer<Client>
        {
            public int Compare(Client x, Client y)
            {
                Client X = (Client)x;
                Client Y = (Client)y;

                return String.Compare(X.lastName, Y.lastName);
            }
        }

    }
}
