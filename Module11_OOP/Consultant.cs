using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Module11_OOP
{
    internal class Consultant : Workers, IClientDataView, IClientDataViewChange
    {


        public void DataViewChanged(string IId, string IFirstName, string ILastName, string IFatherName, string IPhoneNumber, string IPassport)
        {
            Client client = new Client();
            string list = string.Empty;
            foreach (var item in Bank_A.Clients)
            {
               
                if (Convert.ToString(item.Id) == IId)
                {
                    if (IPhoneNumber == String.Empty)
                    {
                        MainWindow.Popup("Поле должно быть заполненым"); return;

                    }
                    else
                    {
                        
                        if (item.phoneNumber != IPhoneNumber)
                        {
                            
                            item.PhoneNumber = IPhoneNumber;
                        }
                        
                        Bank_A.Serialise(Bank_A.Clients);

                    }
                }
            }
            
        }


        /// <summary>
        /// Метод форматированого вывода
        /// </summary>
        /// <param name="Client"></param>
        /// <returns></returns>
        public Client ViewClientData(Client Newclient)
        {

            if (Newclient.passport.Length != 0)
            {
                Newclient.passport = "************";
            }
            
            return Newclient;
        }


    }

    
}
