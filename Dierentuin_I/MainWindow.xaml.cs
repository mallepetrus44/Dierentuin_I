using Dierentuin_I.Core;
using Dierentuin_I.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Dierentuin_I
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly List<Animal> AllAnimals = new List<Animal>();

        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += timer_tick;
            timer.Start();
            CB_animals.Items.Add("Aap");
            CB_animals.Items.Add("Leeuw");
            CB_animals.Items.Add("Olifant");

        }
        void timer_tick(object sender, EventArgs e)
        {
            foreach (var animal in AllAnimals)
            {
                animal.Energy = animal.EnergyUse();          
            }
            update();
        }

        private void AddNewAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (CB_animals.SelectedIndex != -1 && !string.IsNullOrEmpty(TB_NameAnimal.Text))
            {
                switch(CB_animals.SelectedIndex)
                {
                    case 0:
                        Animal monkey = new Monkey
                        {
                            TypeOfAnimal = CB_animals.SelectedItem.ToString(),
                            Name = TB_NameAnimal.Text,
                            Energy = 60
                        };
                        AllAnimals.Add(monkey);
                        break;
                    case 1:
                        Animal lion = new Lion
                        {
                            TypeOfAnimal = CB_animals.SelectedItem.ToString(),
                            Name = TB_NameAnimal.Text,
                            Energy = 100
                        };
                        AllAnimals.Add(lion);
                        break;
                    case 2:
                        Animal elephant = new Elephant
                        {
                            TypeOfAnimal = CB_animals.SelectedItem.ToString(),
                            Name = TB_NameAnimal.Text,
                            Energy = 100
                        };
                        AllAnimals.Add(elephant);
                        break;
                }
                update();
            }
            else
            {
                MessageBox.Show("U heeft nog geen naam en/of dier geselecteerd");
            }
        }

        public void update()
        {         
            DG_Animals.ItemsSource = AllAnimals.ToList();
        }

        private void FeedAllAnimals_Click(object sender, RoutedEventArgs e)
        {
            foreach(var animal in AllAnimals)
            {
                animal.Energy = animal.Eat();
            }
            update();
        }

        private void FeedMonkey_Click(object sender, RoutedEventArgs e)
        {
            foreach(var animal in AllAnimals)
            {
                if (animal.TypeOfAnimal == "Aap")
                {
                    animal.Energy = animal.Eat();
                }
            }
            update();
        }

        private void FeedLion_Click(object sender, RoutedEventArgs e)
        {
            foreach (var animal in AllAnimals)
            {
                if (animal.TypeOfAnimal == "Leeuw")
                {
                    animal.Energy = animal.Eat();
                }
            }
            update();
        }

        private void FeedElephant_Click(object sender, RoutedEventArgs e)
        {
            foreach (var animal in AllAnimals)
            {
                if (animal.TypeOfAnimal == "Olifant")
                {
                    animal.Energy = animal.Eat();
                }
            }
            update();
        }
    }
}
