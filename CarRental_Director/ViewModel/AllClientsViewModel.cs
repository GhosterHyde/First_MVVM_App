using CarRental_Director.Core;
using CarRental_Director.DataAccess;
using CarRental_Director.Model;
using System;
using System.Collections.ObjectModel;

namespace CarRental_Director.ViewModel
{
    public class AllClientsViewModel : ObservableObject
    {
        #region Fields

        readonly ClientRepository _clientRepository;
        private MainWindowViewModel parent;
        private ObservableCollection<ClientViewModel> allClients;

        #endregion

        #region Properties

        public ObservableCollection<ClientViewModel> AllClients
        {
            get { return allClients; }
            set
            {
                allClients = value;
                base.OnPropertyChanged("AllClients");
            }
        }

        #endregion

        #region Commands

        public RelayCommand UpdateClient { get; set; }
        public RelayCommand DeleteClient { get; set; }

        #endregion

        #region Constructor

        public AllClientsViewModel(ClientRepository clientRepository, MainWindowViewModel mainWindowViewModel)
        {
            parent = mainWindowViewModel;
            if ((clientRepository == null) || (mainWindowViewModel == null))
            {
                throw new ArgumentNullException("clientRepository");
            }
            _clientRepository = clientRepository;
            AllClients = new ObservableCollection<ClientViewModel>();
            CreateAllClients();

            UpdateClient = new RelayCommand(o =>
            {
                mainWindowViewModel.CurrentView = o;
            });
            DeleteClient = new RelayCommand(o =>
            {
                ClientViewModel clientVM = (ClientViewModel)o;
                Client client = clientVM.Client;
                clientRepository.DeleteClient(client);
                AllClients.Remove(clientVM);
            });
        }

        #endregion

        #region Client Display

        private void CreateAllClients()
        {
            foreach(Client client in _clientRepository.GetClients())
            {
                ClientViewModel clientVM = new ClientViewModel(client, _clientRepository);
                clientVM.Parrent = parent;
                AllClients.Add(clientVM);
            }
        }

        #endregion
    }
}
