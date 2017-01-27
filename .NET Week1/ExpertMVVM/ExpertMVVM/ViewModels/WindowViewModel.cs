using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpertMVVM.ViewModels
{
    public class WindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SuperHero> _superHeroes;

        public ObservableCollection<SuperHero> superHeroes
        {
            get { return _superHeroes; }
            set 
            { 
                _superHeroes = value;
                OnPropertyChanged("superHeroes");
            }
        }
            
        
        private bool _isVisible;
        public bool isVisible
        {
            get { return _isVisible; }
            set 
            { 
                _isVisible = value;
                OnPropertyChanged("isVisible");
            }
        }

        private ICommand _changeVisibilityCommand;
        public ICommand changeVisibilityCommand
        {
            get
            {
            if (_addSuperHeroCommand == null)
            {
                _addSuperHeroCommand = new Command(ChangeVisibility);
            }
            return _addSuperHeroCommand;
        }
        set { _addSuperHeroCommand = value; }
        }

        private ICommand _addSuperHeroCommand;
        public ICommand addSuperHeroCommand
        {
            get
            {
                if (_addSuperHeroCommand == null)
                {
                    _addSuperHeroCommand = new Command(AddSuperHero);
                }
                return _addSuperHeroCommand;
            }
            set { _addSuperHeroCommand = value; }
        }

        public WindowViewModel()
        {
            superHeroes = new ObservableCollection<SuperHero>();  //METHOD GET ALL ACCOUNTS
            superHeroes.Add(new SuperHero(){ name = "Batman", power = "Money", isGood = true });
            superHeroes.Add(new SuperHero(){ name = "Hulk", power = "OP", isGood = true });
        }

        private void ChangeVisibility()
        {
            isVisible = !isVisible;
        }

        private void AddSuperHero()
        {
            superHeroes.Add(new SuperHero() { name = "Superman", power = "OverPowered", isGood = true });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
