using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using MVVM_WPF_gyakorlás.Logic;
using MVVM_WPF_gyakorlás.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_WPF_gyakorlás.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        IArmyLogic logic;
        public ObservableCollection<Trooper> Barrack { get; set; }
        public ObservableCollection<Trooper> Army { get; set; }

        private Trooper selectedFromBarrack;

        public Trooper SelectedFromBarrack
        {
            get { return selectedFromBarrack; }
            set
            {
                SetProperty(ref selectedFromBarrack, value);
                (AddToArmyCommand as RelayCommand).NotifyCanExecuteChanged();
                (EditTrooperCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Trooper selectedFromArmy;

        public Trooper SelectedFromArmy
        {
            get { return selectedFromArmy; }
            set
            {
                SetProperty(ref selectedFromArmy, value);
                (RemoveFromArmyCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand AddToArmyCommand { get; set; }
        public ICommand RemoveFromArmyCommand { get; set; }
        public ICommand EditTrooperCommand { get; set; }

        public int AllCost
        {
            get
            {
                return logic.AllCost;
            }
        }

        public double AVGPower
        {
            get
            {
                return logic.AVGPower;
            }
        }
        public double AVGSpeed
        {
            get
            {
                return logic.AVGSpeed;
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;

            }
        }

        public MainWindowViewModel()
            : this(IsInDesignMode ? null : Ioc.Default.GetService<IArmyLogic>())
        {

        }

        public MainWindowViewModel(IArmyLogic logic)
        {
            this.logic = logic;
            Barrack = new ObservableCollection<Trooper>();
            Army = new ObservableCollection<Trooper>();

            Barrack.Add(new Trooper() { Type = "marine", Speed = 6, Power = 8 });
            Barrack.Add(new Trooper() { Type = "sniper", Speed = 2, Power = 9 });
            Barrack.Add(new Trooper() { Type = "pilot", Speed = 3, Power = 7 });
            Barrack.Add(new Trooper() { Type = "infantry", Speed = 8, Power = 6 });
            Barrack.Add(new Trooper() { Type = "engineer", Speed = 6, Power = 5 });

            Army.Add(Barrack[2].GetCopy());
            Army.Add(Barrack[4].GetCopy());

            logic.SetupCollections(Barrack, Army);

            AddToArmyCommand = new RelayCommand(
                () => logic.AddToArmy(selectedFromBarrack),
                () => SelectedFromBarrack != null
                );

            RemoveFromArmyCommand = new RelayCommand(
                () => logic.RemoveFromArmy(SelectedFromArmy),
                () => SelectedFromBarrack != null
                );
            EditTrooperCommand = new RelayCommand(
                () => logic.EditTooper(selectedFromBarrack),
                () => SelectedFromBarrack != null
                );

            Messenger.Register<MainWindowViewModel, string, string>(this, "TrooperInfo", (recipient, msg) =>
          {
              OnPropertyChanged("AllCost");
              OnPropertyChanged("AVGPower");
              OnPropertyChanged("AVGSPeed");

          });



        }
    }
}
