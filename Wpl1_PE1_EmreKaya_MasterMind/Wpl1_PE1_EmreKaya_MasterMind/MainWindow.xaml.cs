using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

namespace Wpl1_PE1_EmreKaya_MasterMind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int attempts;
        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime = DateTime.Now - clicked;
            timerLabel.Content = $"{elapsedTime.Seconds.ToString()}";
        }
        private DispatcherTimer timer = new DispatcherTimer();
        TimeSpan elapsedTime;
        DateTime clicked;

        public MainWindow()
        {
            InitializeComponent();
            titleRandomColors();

            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(1);
        }




        private void titleRandomColors()
        {
            // alle kleuren
            string[] colors = { "Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw" };
            Random random = new Random();

            // StringBuilder voor tietel
            StringBuilder titleBuilder = new StringBuilder("Mastermind kleur: ");

            


            for (int i = 0; i < 5; i++)
            {
                if (i == 4)
                {
                    string attempts = null;
                    titleBuilder.Append("   Poging " + attempts);
                }
                if (i < 4)
                {
                    int randomIndex = random.Next(0, colors.Length);
                    titleBuilder.Append(colors[randomIndex]);

                    // Voeg een komma en spatie toe behalve na de laatste kleur
                    if (i < 3)
                    {
                        titleBuilder.Append(", ");
                    }
                }

            }


            // Stel de titel van het venster in
            this.Title = titleBuilder.ToString();
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox1.SelectedItem is ComboBoxItem ComboBox1Item)  // als item is geselecteerd
            {
                if (ComboBox1Item.Background is SolidColorBrush Kleur) // dan: kleur borstel naar achtergrondskleur van geselecteerde Item
                {
                    label1.Background = Kleur;   //label de keur geven van achtergrondskleur van geselecteerde Item  
                    label1.Content = ComboBox1Item.Content.ToString();
                }
            }
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox2.SelectedItem is ComboBoxItem ComboBox2Item)
            {
                if (ComboBox2Item.Background is SolidColorBrush Kleur)
                {
                    label2.Background = Kleur;
                    label2.Content = ComboBox2Item.Content.ToString();
                }
            }
        }

        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox3.SelectedItem is ComboBoxItem ComboBox3Item)
            {
                if (ComboBox3Item.Background is SolidColorBrush Kleur)
                {
                    label3.Background = Kleur;
                    label3.Content = ComboBox3Item.Content.ToString();
                }
            }
        }

        private void ComboBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox4.SelectedItem is ComboBoxItem ComboBox4Item)
            {
                if (ComboBox4Item.Background is SolidColorBrush Kleur)
                {
                    label4.Background = Kleur;
                    label4.Content = ComboBox4Item.Content.ToString();
                }
            }
        }




        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            
            attempts++;

            

            timer.Start();
            clicked = DateTime.Now;


            label1.BorderBrush = Brushes.LightGray;
            label2.BorderBrush = Brushes.LightGray;
            label3.BorderBrush = Brushes.LightGray;
            label4.BorderBrush = Brushes.LightGray;

            string[] titleColors = this.Title.Split(':')[1].Split(',');

            int MasterMindStrenghtNumber = 0;

            string label1Color = label1.Content.ToString();
            string label2Color = label2.Content.ToString();
            string label3Color = label3.Content.ToString();
            string label4Color = label4.Content.ToString();

            if (this.Title.Contains(label1Color))
            {
                MasterMindStrenghtNumber++;
                if (titleColors[0].Contains(label1Color))
                {
                    label1.BorderBrush = Brushes.DarkRed;
                }
                else
                {
                    label1.BorderBrush = Brushes.Wheat;
                }
            }

            if (this.Title.Contains(label2Color))
            {
                MasterMindStrenghtNumber++;
                if (titleColors[1].Contains(label2Color))
                {
                    label2.BorderBrush = Brushes.DarkRed;
                }
                else
                {
                    label2.BorderBrush = Brushes.Wheat;
                }
            }

            if (this.Title.Contains(label3Color))
            {
                MasterMindStrenghtNumber++;
                if (titleColors[2].Contains(label3Color))
                {
                    label3.BorderBrush = Brushes.DarkRed;
                }
                else
                {
                    label3.BorderBrush = Brushes.Wheat;
                }
            }

            if (this.Title.Contains(label4Color))
            {
                MasterMindStrenghtNumber++;
                if (titleColors[3].Contains(label4Color))
                {
                    label4.BorderBrush = Brushes.DarkRed;
                }
                else
                {
                    label4.BorderBrush = Brushes.Wheat;
                }
            }




            switch (MasterMindStrenghtNumber)
            {
                case 4:
                    resultTextBlock.Text = "4 kleuren komen voor";
                    break;
                case 3:
                    resultTextBlock.Text = "3 kleuren komen voor";
                    break;
                case 2:
                    resultTextBlock.Text = "2 kleuren komen voor";
                    break;
                case 1:
                    resultTextBlock.Text = "1 kleur komt voor";
                    break;
                default:
                    resultTextBlock.Text = "Niet de juiste kleuren gebruikt";
                    break;

            }
        }
    }
}
