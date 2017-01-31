using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetworkMVVM.ViewModels
{
    public class ListOfUsersViewModel : BaseViewModel
    {
        private readonly IDialogService dialogService;
        public RelayCommand Add { get; set; }
        public RelayCommand Edit { get; set; }
        public RelayCommand Delete { get; set; }
        private dotNetworkViewModel selected;

        public ListOfUsersViewModel(ObservableCollection<UsersViewModel> users,
            RelayCommand add,
            RelayCommand edit,
            IDialogService dialogService)
        {
            this.dialogService = dialogService;
            Add = add;
            Edit = edit;
            Delete = new RelayCommand(DeleteSelected, o => o != null);
            Users = users;
        }

        private async void DeleteSelected(object obj)
        {
            var result = await dialogService.AskQuestionAsync("Delete User",
                "Are you sure you want to delete this User?");
            if (result == MessageDialogResult.Affirmative)
            {
                Users.Remove(selected);
                Selected = null;
            }
        }

        public ObservableCollection<UsersViewModel> Users { get; private set; }

        public UsersViewModel Selected
        {
            get { return selected; }
            set
            {
                if (Equals(value, selected)) return;
                selected = value;
                OnPropertyChanged();
            }
        }
    }
}
