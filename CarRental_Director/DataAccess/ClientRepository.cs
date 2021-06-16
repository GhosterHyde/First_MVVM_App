using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CarRental_Director.Model;

namespace CarRental_Director.DataAccess
{
    public class ClientRepository
    {
        #region Fields

        readonly List<Client> _clients;

        #endregion

        public DataContext DataContext { get; set; }

        #region Constructor

        public ClientRepository()
        {
            _clients = LoadClients();
        }

        public ClientRepository(DataContext dataContext)
        {
            DataContext = dataContext;
            _clients = LoadClients();
        }

        #endregion

        #region Loading Clients

        private List<Client> LoadClients()
        {
            try
            {
                DataContext.Clients.Load();
                return DataContext.Clients.ToList();
            }
            catch (Exception)
            {
                return new List<Client>();
            }
        }

        #endregion

        #region Add Client
        
        public void AddClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            if (!_clients.Contains(client))
            {
                try
                {
                    DataContext.Clients.Add(client);
                    DataContext.SaveChangesAsync();
                    _clients.Add(client);
                }
                catch (Exception)
                {
                    _clients.Add(client);
                }
            }
        }

        #endregion

        #region Delete Client

        public void DeleteClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            if (_clients.Contains(client))
            {
                try
                {
                    DataContext.Clients.Remove(client);
                    DataContext.SaveChangesAsync();
                    _clients.Remove(client);
                }
                catch (Exception)
                {
                    _clients.Remove(client);
                }
            }
        }

        #endregion

        #region Work With Collection

        public bool ContainsClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }
            return _clients.Contains(client);
        }

        public List<Client> GetClients()
        {
            return new List<Client>(_clients);
        }

        public Client GetConcreteClients(int client_id)
        {
            foreach(Client client in _clients)
            {
                if (client.ID == client_id)
                {
                    return client;
                }
            }
            return null;
        }

        #endregion
    }
}
