using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        int getal1, getal2;
        int juisteAntwoord;
        string teken;
        int score = 0;

        public MainWindow()
        {
            InitializeComponent();
            NieuweSom();
        }

        void NieuweSom()
        {
            getal1 = rnd.Next(1, 11);
            getal2 = rnd.Next(1, 11);

            int bewerking = rnd.Next(1, 5);

            switch (bewerking)
            {
                case 1:
                    teken = "+";
                    juisteAntwoord = getal1 + getal2;
                    break;

                case 2:
                    teken = "-";
                    juisteAntwoord = getal1 - getal2;
                    break;

                case 3:
                    teken = "x";
                    juisteAntwoord = getal1 * getal2;
                    break;

                case 4:
                    teken = "/";
                    getal1 = getal2 * rnd.Next(1, 11); // voorkomt kommagetallen
                    juisteAntwoord = getal1 / getal2;
                    break;
            }

            lblSom.Content = $"{getal1} {teken} {getal2} = ?";
            txtAntwoord.Text = "";
            lblFeedback.Content = "";
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAntwoord.Text))
            {
                lblFeedback.Content = "Vul iets in!";
                return;
            }

            int antwoord;

            if (int.TryParse(txtAntwoord.Text, out antwoord))
            {
                if (antwoord == juisteAntwoord)
                {
                    lblFeedback.Content = "Goed! 😊";
                    score++;
                }
                else
                {
                    lblFeedback.Content = "Fout ❌";
                }

                lblScore.Content = $"Score: {score}";
            }
            else
            {
                lblFeedback.Content = "Geen geldig getal!";
            }
        }

        private void NieuweSom_Click(object sender, RoutedEventArgs e)
        {
            NieuweSom();
        }
    }
}