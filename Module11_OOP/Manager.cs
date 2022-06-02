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
    internal class Manager : Workers,IClientDataView, IClientDataViewChange
    {
        
        public void DataViewChanged(string IId, string IFirstName, string ILastName, string IFatherName, string IPhoneNumber, string IPassport)
        {
            
            foreach (var item in Bank_A.Clients)
            {

                if (Convert.ToString(item.Id) == IId)
                {
                    if (ILastName == String.Empty || IPhoneNumber == String.Empty ||
            IFatherName == String.Empty || IFirstName == String.Empty || IPassport == String.Empty)
                    {
                        MainWindow.Popup("Поле должно быть заполненым"); return;
                    }
                    else
                    {
                        
                        if (item.FatherName != IFatherName)
                        {
                            item.FatherName = IFatherName;
                        }
                        if (item.phoneNumber != IPhoneNumber)
                        {
                            
                            item.PhoneNumber = IPhoneNumber;
                        }
                        if (item.Passport != IPassport)
                        {
                           
                            item.Passport = IPassport;
                        }
                        if (item.FirstName != IFirstName)
                        {
                            
                            item.FirstName = IFirstName;
                        }
                        if (item.LastName != ILastName)
                        {
                            
                            item.LastName = ILastName;
                        }
                        Bank_A.Serialise(Bank_A.Clients);
                    }
                }
            }
           
        }



        /// <summary>
        /// Метод форматированого вывода
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public Client ViewClientData(Client worker)
        {
            return worker;
        }
    }
}
