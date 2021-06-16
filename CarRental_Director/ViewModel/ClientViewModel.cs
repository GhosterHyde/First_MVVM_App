using CarRental_Director.Core;
using CarRental_Director.DataAccess;
using CarRental_Director.Model;
using System;
using CarRental_Director.View;
using System.ComponentModel;
using System.Windows.Input;

namespace CarRental_Director.ViewModel
{
    public class ClientViewModel : ObservableObject, IDataErrorInfo
    {
        #region Fields

        readonly Client _client;
        readonly ClientRepository _clientRepository;
        MainWindowViewModel parrent;
        RelayCommand _saveCommand;

        #endregion

        #region Properties
        public Client Client => _client;
        public MainWindowViewModel Parrent { get => parrent; set => parrent = value; }

        #endregion

        #region Client Properties

        public string Surname
        {
            get { return Client.Surname; }
            set
            {
                if (value == Client.Surname)
                {
                    return;
                }

                Client.Surname = value;

                base.OnPropertyChanged("Surname");
            }
        }

        public string FirstName
        {
            get { return Client.FirstName; }
            set
            {
                if (value == Client.FirstName)
                {
                    return;
                }

                Client.FirstName = value;

                base.OnPropertyChanged("FirstName");
            }
        }

        public string SecondName
        {
            get { return Client.SecondName; }
            set
            {
                if (value == Client.SecondName)
                {
                    return;
                }

                Client.SecondName = value;

                base.OnPropertyChanged("SecondName");
            }
        }

        public string DrivenLicense
        {
            get { return Client.DrivenLicense; }
            set
            {
                if (value == Client.DrivenLicense)
                {
                    return;
                }

                Client.DrivenLicense = value;

                base.OnPropertyChanged("DrivenLicense");
            }
        }

        public string Address
        {
            get { return Client.Address; }
            set
            {
                if (value == Client.Address)
                {
                    return;
                }

                Client.Address = value;

                base.OnPropertyChanged("Address");
            }
        }

        public string PhoneNumber
        {
            get { return Client.PhoneNumber; }
            set
            {
                if (value == Client.PhoneNumber)
                {
                    return;
                }

                Client.PhoneNumber = value;

                base.OnPropertyChanged("PhoneNumber");
            }
        }

        #endregion

        #region Constructors

        public ClientViewModel(Client client, ClientRepository clientRepository, MainWindowViewModel mainWindowViewModel)
        {
            NullExceptionChecking(client, clientRepository, mainWindowViewModel);
            _client = client;
            _clientRepository = clientRepository;
            Parrent = mainWindowViewModel;
        }

        private void NullExceptionChecking(Client client, ClientRepository clientRepository, MainWindowViewModel mainWindowViewModel)
        {
            if ((client == null) || (clientRepository == null) || (mainWindowViewModel == null))
            {
                throw new ArgumentNullException();
            }
        }

        public ClientViewModel(Client client, ClientRepository clientRepository)
        {
            NullExceptionChecking(client, clientRepository);
            _client = client;
            _clientRepository = clientRepository;
            Surname = _client.Surname;
            FirstName = _client.FirstName;
            SecondName = _client.SecondName;
            DrivenLicense = _client.DrivenLicense;
            Address = _client.Address;
            PhoneNumber = _client.PhoneNumber;
        }

        private void NullExceptionChecking(Client client, ClientRepository clientRepository)
        {
            if ((client == null) || (clientRepository == null))
            {
                throw new ArgumentNullException();
            }
        }

        #endregion

        #region Commands

        public RelayCommand SaveClient
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(
                        param => this.Save(),
                        param => this.CanSave
                        );
                }
                return _saveCommand;
            }
        }

        #endregion

        #region Public Methods

        public void Save()
        {
            try
            {
                AddDataForClient();
                if (!Client.IsValid())
                {
                    throw new InvalidOperationException("Client cannot be saved! Correct client data!");
                }
                if (this.IsNewClient)
                {
                    _clientRepository.AddClient(Client);
                }
                _clientRepository.DataContext.SaveChangesAsync();

                Parrent.CurrentView = new ClientSuccessfullAdding();
            }
            catch (Exception ex)
            {
                parrent.CurrentView = new ErrorReportingViewModel(ex.Message);
            }
        }

        private void AddDataForClient()
        {
            Client.Surname = this.Surname;
            Client.FirstName = this.FirstName;
            Client.SecondName = this.SecondName;
            Client.DrivenLicense = this.DrivenLicense;
            Client.Address = this.Address;
            Client.PhoneNumber = this.PhoneNumber;
        }

        #endregion

        #region Private Helpers

        bool IsNewClient
        {
            get { return !_clientRepository.ContainsClient(Client); }
        }

        bool CanSave
        {
            get { return Client.IsValid(); }
        }

        #endregion

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get { return (Client as IDataErrorInfo).Error; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                string error = null;
                error = (Client as IDataErrorInfo)[propertyName];
                CommandManager.InvalidateRequerySuggested();
                return error;
            }
        }
        #endregion
    }
}
