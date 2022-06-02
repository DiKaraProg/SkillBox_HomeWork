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
    internal class Bank_A
    {
        public static ObservableCollection<Client> Clients = new ObservableCollection<Client>();// Коллекция всех клиентов
        public static ObservableCollection<Client> ChangedInfo = new ObservableCollection<Client>();

        /// <summary>
        /// Метод сериализации
        /// </summary>
        /// <param name="Clients">Клиент</param>
        public static void Serialise(ObservableCollection<Client> Clients)
        {
            JArray array = new JArray();
            foreach (var item in Clients)
            {
                JObject o = new JObject
                {
                    ["Id"] = item.Id,
                    ["FirstName"] = item.FirstName,
                    ["LastName"] = item.LastName,
                    ["FatherName"] = item.FatherName,
                    ["PhoneNumber"] = item.PhoneNumber,
                    ["Passport"] = item.Passport

                };
                array.Add(o);

                string json = array.ToString();

                File.WriteAllText("Data.json", json);
                
            }
        }
        /// <summary>
        /// Метод десиреализации
        /// </summary>
        /// <param name="Client"></param>
        /// <returns></returns>
        public static ObservableCollection<Client> Deserialise(ObservableCollection<Client> Client)
        {
            
            string json = File.ReadAllText("Data.json");

            return Client = JsonConvert.DeserializeObject<ObservableCollection<Client>>(json);
        }

    }
   
    
}
