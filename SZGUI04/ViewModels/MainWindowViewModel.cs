namespace SZGUI04.ViewModels
{
    using Microsoft.Toolkit.Mvvm.ComponentModel;
    using Microsoft.Toolkit.Mvvm.DependencyInjection;
    using Microsoft.Toolkit.Mvvm.Input;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using SZGUI04.Models;

    public class MainWindowViewModel : ObservableRecipient
        {
           // IArmyLogic logic;
            public ObservableCollection<Hero> Barrack { get; set; }
            public ObservableCollection<Hero> Army { get; set; }

            private Hero selectedFromBarracks;

            public Hero SelectedFromBarracks
            {
                get { return selectedFromBarracks; }
                set
                {
                    SetProperty(ref selectedFromBarracks, value);
                    (AddToArmyCommand as RelayCommand).NotifyCanExecuteChanged();
                    (EditTrooperCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }

            private Hero selectedFromArmy;

            public Hero SelectedFromArmy
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
                return 0;
                }
            }

            public double AVGPower
            {
                get
                {
                return 0;
                }
            }

            public double AVGSpeed
            {
                get
                {
                return 0;
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


            //public MainWindowViewModel()
            //    : this(IsInDesignMode ? null : Ioc.Default.GetService<IArmyLogic>())
            //{

            //}

            public MainWindowViewModel()
            {
                //this.logic = logic;
                Barrack = new ObservableCollection<Hero>();
                Army = new ObservableCollection<Hero>();

                Barrack.Add(new Hero()
                {
                    Name = "Superman",
                    Power = 8,
                    Speed = 6,
                    Oldal=Side.jo
                });
                Barrack.Add(new Hero()
                {
                    Name = "Batman",
                    Power = 7,
                    Speed = 3,
                    Oldal = Side.jo
                });
                Barrack.Add(new Hero()
                {
                    Name = "Spider-man",
                    Power = 6,
                    Speed = 8,
                    Oldal = Side.semleges
                });
                Barrack.Add(new Hero()
                {
                    Name = "Hulk",
                    Power = 3,
                    Speed = 3,
                    Oldal = Side.gonosz
                });
                Barrack.Add(new Hero()
                {
                    Name = "C-A",
                    Power = 5,
                    Speed = 6,
                    Oldal = Side.gonosz
                });

                Army.Add(Barrack[2].GetCopy());
                Army.Add(Barrack[4].GetCopy());

                //logic.SetupCollections(Barrack, Army);

                //AddToArmyCommand = new RelayCommand(
                //    () => logic.AddToArmy(SelectedFromBarracks),
                //    () => SelectedFromBarracks != null
                //    );

                //RemoveFromArmyCommand = new RelayCommand(
                //    () => logic.RemoveFromArmy(SelectedFromArmy),
                //    () => SelectedFromArmy != null
                //    );

                //EditTrooperCommand = new RelayCommand(
                //    () => logic.EditTrooper(SelectedFromBarracks),
                //    () => SelectedFromBarracks != null
                //    );

                //Messenger.Register<MainWindowViewModel, string, string>(this, "TrooperInfo", (recipient, msg) =>
                //{
                //    OnPropertyChanged("AllCost");
                //    OnPropertyChanged("AVGPower");
                //    OnPropertyChanged("AVGSpeed");
                //});
            }
        }
    }

