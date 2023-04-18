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

namespace Gra_w_kosci_tutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Dice> results { get; set; }
        public ObservableCollection<Score> scores { get; set; }
        public int NumberOfDice { get; set; }
        public int NumberOfTries { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            NumberOfDice = 5;
            results = new ObservableCollection<Dice>();
            scores = new ObservableCollection<Score>();
            DataContext = this;
            preparegame();

        }

        private void preparegame()
        {
            scores.Add(new Score("jedynki"));
            scores.Add(new Score("dwojki"));
            scores.Add(new Score("trojki"));
            scores.Add(new Score("czworki"));
            scores.Add(new Score("piatki"));
            scores.Add(new Score("szóstki"));
            scores.Add(new Score("trzy"));
            scores.Add(new Score("cztery"));
            scores.Add(new Score("full"));
            scores.Add(new Score("mały strit"));
            scores.Add(new Score("duzy strit"));
            scores.Add(new Score("generał"));
            scores.Add(new Score("szansa"));
            NumberOfTries = 10;


        }


        private void rollbtn_Click(object sender, RoutedEventArgs e)
        {
            if (NumberOfTries > 0)
            {
                var random = new Random();
                foreach (var item in results)
                {
                    if (!item.IsSelected)
                        item.Value = random.Next(1, 7);
                }
                NumberOfTries--;
                showpoints();
            }
            else
                rollbtn.IsEnabled = false;

        }

        private void showpoints()
        {
            if (scores[0].IsSet == false)
                scores[0].Points = suma(results, 1);
            if (scores[1].IsSet == false)
                scores[1].Points = suma(results, 2);
            if (scores[2].IsSet == false)
                scores[2].Points = suma(results, 3);
            if (scores[3].IsSet == false)
                scores[3].Points = suma(results, 4);
            if (scores[4].IsSet == false)
                scores[4].Points = suma(results, 5);
            if (scores[5].IsSet == false)
                scores[5].Points = suma(results, 6);

            if (scores[6].IsSet == false)
                scores[6].Points = trzy(results);

            if (scores[7].IsSet == false)
                scores[7].Points = cztery(results);

            if (scores[8].IsSet == false)
                scores[8].Points = full(results);

            if (scores[9].IsSet == false)
                scores[9].Points = malystrit(results);

            if (scores[10].IsSet == false)
                scores[10].Points = duzystrit(results);

            if (scores[11].IsSet == false)
                scores[11].Points = general(results);

            if (scores[12].IsSet == false)
                scores[12].Points = sumaall(results);

        }

        private int sumaall(ObservableCollection<Dice> tablica)
        {
            int s = 0;
            foreach (Dice dice in tablica)
                s = s + dice.Value;
            return s;

        }

        private int suma(ObservableCollection<Dice> tablica, int nr)
        {
            int s = 0;
            foreach (Dice d in tablica)
                if (d.Value == nr)
                    s = s + d.Value;
            return s;

        }

        private void Button_Dice_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var dice = button.DataContext as Dice;
            dice.IsSelected = !dice.IsSelected;
        }

        private void zatwierdzbtn_Click(object sender, RoutedEventArgs e)
        {
            NumberOfTries = 10;
            rollbtn.IsEnabled = true;
            results.Clear();
            for (int i = 0; i < NumberOfDice; i++)
            {
                results.Add(new Dice());
            }
            int count = 0;
            int totalScore = 0;
            foreach (Score score in scores)
            {
                if (score.IsSet)
                {
                    count++;
                    totalScore += score.Points;
                }
            }

            points.Text = "Punkty: " + totalScore.ToString();
            for (int i = 0; i <= 12; i++)
            {
                if (scores[i].IsSet == true)
                {
                    scores[i].IsEnabled = false;
                }
            }

        }

        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            results.Clear();
            for (int i = 0; i < NumberOfDice; i++)
            {
                results.Add(new Dice());
            }

        }

        private int trzy(ObservableCollection<Dice> tablica)
        {
            int z = 0;
            for (int i = 1; i <= 6; i++)
            {
                z = 0;
                foreach (Dice dice in tablica)
                {
                    if (dice.Value == i)
                    {
                        z += 1;
                    }
                    if (z >= 3)
                    {
                        return 3 * i;
                    }
                }

            }

            return 0;
        }

        private int cztery(ObservableCollection<Dice> tablica)
        {
            int z = 0;
            for (int i = 1; i <= 6; i++)
            {
                z = 0;
                foreach (Dice dice in tablica)
                {
                    if (dice.Value == i)
                    {
                        z += 1;
                    }
                    if (z >= 4)
                    {
                        return 4 * i;
                    }
                }

            }
            return 0;
        }


        private int general(ObservableCollection<Dice> tablica)
        {
            int z = 0;
            for (int i = 1; i <= 6; i++)
            {
                z = 0;
                foreach (Dice dice in tablica)
                {
                    if (dice.Value == i)
                    {
                        z += 1;
                    }
                    if (z >= 5)
                    {
                        return 50;
                    }
                }

            }
            return 0;
        }

        private int malystrit(ObservableCollection<Dice> tablica)
        {
            int z = 0;
            int[] x = new int[6];

            foreach (Dice dice in tablica)
            {
                x[dice.Value - 1] = 1;

            }
            for (int i = 0; i < 5; i++)
            {
                if (x[i] == 1)
                {
                    z += 1;
                }
            }
            if (z == 4) return 15;
            else return 0;
        }

        private int duzystrit(ObservableCollection<Dice> tablica)
        {
            int z = 0;
            int[] x = new int[6];

            foreach (Dice dice in tablica)
            {
                x[dice.Value - 1] = 1;

            }
            for (int i = 1; i <= 5; i++)
            {
                if (x[i] == 1)
                {
                    z += 1;
                }
            }
            if (z == 5) return 30;
            else return 0;
        }


        private int full(ObservableCollection<Dice> tablica)
        {
            bool if3 = false, if2 = false;
            int[] x = new int[6];

            int z = 0;
            foreach (Dice dice in tablica)
            {
                x[dice.Value - 1] += 1;
            }
            for (int i = 0; i < 6; i++)
            {
                if (x[i] == 3)
                {
                    z += 3 * (i + 1);
                    if3 = true;
                }

                if (x[i] == 2)
                {
                    z += 2 * (i + 1);
                    if2 = true;
                }
            }
            if (if2 && if3) return z * 2;
            else return 0;
        }

        private void zatwierdzbtn_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}