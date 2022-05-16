using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class ClientService
    {
        public static List<Client> GetAllClients()
        {
            using (ModelDataBaseContainer container = new ModelDataBaseContainer())
            {
                return container.Clients.ToList();
            }
        }

        public static bool DeleteClients(List<Client> clientsIds)
        {
            using (ModelDataBaseContainer container = new ModelDataBaseContainer())
            {
                var clients = new List<Client>();

                foreach (var clientId in clientsIds)
                {
                    var client = container.Clients.Find(clientId.Id);

                    clients.Add(client);
                }

                container.Clients.RemoveRange(clients);
                container.SaveChanges();
            }

            return true;
        }

        public static bool AddClient(string FirstName, string LastName, string Patranomic, string Phone)
        {
            using (ModelDataBaseContainer container = new ModelDataBaseContainer())
            {
                var client = new Client();
                client.FirstName = FirstName;
                client.LastName = LastName;
                client.Patranymic = Patranomic;
                client.Phone = Phone;
                client.DateCreate = DateTime.Now;
                container.Clients.Add(client);
                container.SaveChanges();
                return true;
            }
        }
        public static bool CheckInputs(string FirstName, string LastName, string Patranomic, string Phone)
        {
            if(FirstName == String.Empty || LastName == String.Empty ||  Phone == String.Empty)
            {
                return false;
            }
            if(LastName.Length<6 || LastName.Length > 75)
            {
                return false;
            }
            if (FirstName.Length < 2 || FirstName.Length > 75)
            {
                return false;
            }
            if (!Patranomic.Equals(String.Empty))
            {
                if (Patranomic.Length < 5 || Patranomic.Length > 75)
                {
                    return false;
                }
            }
            return true;
        }
        public static List<Client> FindClients(string str)
        {
            using (ModelDataBaseContainer container = new ModelDataBaseContainer())
            {
                List<Client> client = new List<Client>();

                if (str == String.Empty || str.Equals("Поиск"))
                {
                    return GetAllClients();
                }
                else
                {
                    client = container.Clients.Where
                        (x => x.Phone.Contains(str) ||
                         x.FirstName.Contains(str) ||
                         x.LastName.Contains(str) ||
                         x.Patranymic.Contains(str)).ToList();
                    return client;
                }
            }
        }
    }
}
