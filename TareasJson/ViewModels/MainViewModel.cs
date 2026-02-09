using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TareasJson.Models;
using TareasJson.Services;

namespace TareasJson.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly JsonService _service = new();

        public ObservableCollection<Contact> Contacts { get; }

        private Contact _selectedContact = new();
        public Contact SelectedContact
        {
            get => _selectedContact;
            set { _selectedContact = value; OnPropertyChanged(); }
        }

        public RelayCommand AddCommand { get; }
        public RelayCommand DeleteCommand { get; }

        public MainViewModel()
        {
            Contacts = new ObservableCollection<Contact>(_service.Load());

            AddCommand = new RelayCommand(AddContact);
            DeleteCommand = new RelayCommand(DeleteContact, () => SelectedContact != null);
        }

        private void AddContact()
        {
            Contacts.Add(new Contact
            {
                Name = SelectedContact.Name,
                Email = SelectedContact.Email,
                Phone = SelectedContact.Phone
            });

            _service.Save(Contacts);
            SelectedContact = new Contact();
        }

        private void DeleteContact()
        {
            if (Contacts.Contains(SelectedContact))
            {
                Contacts.Remove(SelectedContact);
                _service.Save(Contacts);
                SelectedContact = new Contact();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
