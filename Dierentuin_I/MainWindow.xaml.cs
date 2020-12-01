using Dierentuin_I.Core;
using Dierentuin_I.Models;
using RandomNameGeneratorLibrary;
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
        public int DeadAnimals = 0;


        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += timer_tick;
            timer.Start();

        }
        void timer_tick(object sender, EventArgs e)
        {
            foreach (var animal in AllAnimals)
            {
                animal.Energy = animal.EnergyUse();                
            }
            update();
        }

        //private void AddNewAnimal_Click(object sender, RoutedEventArgs e)
        //{
          

        //    if (CB_animals.SelectedIndex != -1)
        //    {
        //        switch(CB_animals.SelectedIndex)
        //        {
        //            case 0:
        //                Animal monkey = new Monkey
        //                {
        //                    TypeOfAnimal = CB_animals.SelectedItem.ToString(),
        //                    Name = name,
        //                    Energy = 60
        //                };
        //                AllAnimals.Add(monkey);
        //                break;
        //            case 1:
        //                Animal lion = new Lion
        //                {
        //                    TypeOfAnimal = CB_animals.SelectedItem.ToString(),
        //                    Name = name,
        //                    Energy = 100
        //                };
        //                AllAnimals.Add(lion);
        //                break;
        //            case 2:
        //                Animal elephant = new Elephant
        //                {
        //                    TypeOfAnimal = CB_animals.SelectedItem.ToString(),
        //                    Name = name,
        //                    Energy = 100
        //                };
        //                AllAnimals.Add(elephant);
        //                break;
        //        }
        //        update();
        //    }
        //    else
        //    {
        //        MessageBox.Show("U heeft nog geen naam en/of dier geselecteerd");
        //    }
        //}

        public void update()
        {
            var Monkeys = new List<Animal>();
            var Elephants = new List<Animal>();
            var Lions = new List<Animal>();
            var FilteredAnimals = new List<Animal>();

            if (cb_monkeys.IsChecked == true)
            {
                Monkeys = AllAnimals.Where(a => a.TypeOfAnimal == "Aap").ToList();
                FilteredAnimals = Monkeys.Concat(Lions.Concat(Elephants)).ToList();
            }
            
            if (cb_Lions.IsChecked == true)
            { 
                Lions = AllAnimals.Where(a => a.TypeOfAnimal == "Leeuw").ToList();
                FilteredAnimals = Monkeys.Concat(Lions.Concat(Elephants)).ToList();
            }

            if (cb_elephants.IsChecked == true)
            {
                 Elephants = AllAnimals.Where(a => a.TypeOfAnimal == "Olifant").ToList();
                FilteredAnimals = Monkeys.Concat(Lions.Concat(Elephants)).ToList();
            }

            if (cb_elephants.IsChecked == false && cb_monkeys.IsChecked == false && cb_Lions.IsChecked == false)
            {
                DG_Animals.ItemsSource = AllAnimals.ToList();
            }
            else
            {
                DG_Animals.ItemsSource = FilteredAnimals.ToList();
            }

            //var FilteredAnimals = new List<Animal>();

            //if (cb_monkeys.IsChecked == true)
            //{
            //    DG_Animals.ItemsSource = FilteredAnimals.Concat(AllAnimals.Where(a => a.TypeOfAnimal == "Aap"));
            //}
            //else if (cb_Lions.IsChecked == true)
            //{ 
            //    DG_Animals.ItemsSource = FilteredAnimals.Concat(AllAnimals.Where(a => a.TypeOfAnimal == "Leeuw"));
            //}
            //else if (cb_elephants.IsChecked == true)
            //{
            //    DG_Animals.ItemsSource = FilteredAnimals.Concat(AllAnimals.Where(a => a.TypeOfAnimal == "Olifant"));
            //}
            //else
            //{
            //    DG_Animals.ItemsSource = AllAnimals.ToList();
            //}
            foreach (var animal in AllAnimals.ToList())
            {
                if (animal.Energy <= 0)
                {
                    AllAnimals.Remove(animal);
                    DeadAnimals += 1;
                    lb_deadanimals.Content = "Aantal dode dieren: " + DeadAnimals.ToString();
                }              
            }

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

        private void Btn_Add_Monkey_Click(object sender, RoutedEventArgs e)
        {
            var _personGenerator = new PersonNameGenerator();
            var name = _personGenerator.GenerateRandomFirstAndLastName();
            var monkey = new Monkey
            {
                TypeOfAnimal ="Aap",
                Name = name,
                Energy = 60
            };
            AllAnimals.Add(monkey);
        }

        private void Btn_Add_Lion_Click(object sender, RoutedEventArgs e)
        {
            var _personGenerator = new PersonNameGenerator();
            var name = _personGenerator.GenerateRandomFirstAndLastName();
            var lion = new Lion
            {
                TypeOfAnimal = "Leeuw",
                Name = name,
                Energy = 100
            };
            AllAnimals.Add(lion);
        }

        private void Btn_Add_Elephant_Click(object sender, RoutedEventArgs e)
        {
            var _personGenerator = new PersonNameGenerator();
            var name = _personGenerator.GenerateRandomFirstAndLastName();
            var elephant = new Elephant
            {
                TypeOfAnimal = "Olifant",
                Name = name,
                Energy = 100
            };
            AllAnimals.Add(elephant);
        }
    }
}
