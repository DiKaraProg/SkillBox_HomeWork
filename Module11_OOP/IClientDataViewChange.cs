using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module11_OOP
{
    internal interface IClientDataViewChange
    {
        void DataViewChanged(string IId, string IFirstName, string ILastName, string IFatherName, string IPhoneNumber, string IPassport);
    }
}
