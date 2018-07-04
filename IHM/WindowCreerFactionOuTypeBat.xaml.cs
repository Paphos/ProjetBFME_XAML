using lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IHM
{
    /// <summary>
    /// Logique d'interaction pour WindowCreerFaction.xaml
    /// </summary>
    public partial class WindowCreerFactionOuTypeBat : Window
    {
        private Type mType;
        public Type TypeConcerné
        {
            get { return mType; }
            private set
            {
                if (value != typeof(Faction) && value != typeof(TypeBatiment))
                {
                    throw new InvalidOperationException
                        (string.Format("Le constructeur de WindowCreerFactionOuTypeBat ne prend pas en charge le type {0}. Seuls les types Faction et TypeBatiment sont acceptés.", (value as Type).ToString()));
                }
                mType = value;
            }
        }

        public MainWindow FenetrePrincipale { get; private set; }

        public Manager Mana { get; private set; }



        public WindowCreerFactionOuTypeBat(MainWindow mainWin, Type type, Manager mana)
        {
            FenetrePrincipale = mainWin;
            TypeConcerné = type;
            Mana = mana;
            InitializeComponent();

            if (TypeConcerné == typeof(Faction))
            {
                TextBlockLabel.Text = "Nom de la nouvelle faction";
            }
            else
            {
                TextBlockLabel.Text = "Nom du nouveau type de bâtiment";
            }

            TextBoxNom.Focus();
        }

        private void TextBoxNom_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            int erreur = 0;
            TextBox tb = sender as TextBox;

            while (true)
            {
                if (String.IsNullOrWhiteSpace(tb.Text))
                {
                    erreur = 1; break;
                }
                if (TypeConcerné == typeof(Faction) && Mana.Factions.Contains(new Faction(tb.Text)))
                {
                    erreur = 2; break;
                }
                if (TypeConcerné == typeof(TypeBatiment) && Mana.TypeBatiments.Contains(new TypeBatiment(tb.Text)))
                {
                    erreur = 3; break;
                }
                if (Regex.IsMatch(tb.Text, "[/:*?<>|_.\"]+") == true || tb.Text.Contains('\\'))
                {
                    erreur = 4; break;
                }
                break;
            }

            if (erreur > 0)
            {
                ButtonAjouter.IsEnabled = false;
                BorderTextBox.BorderBrush = Brushes.Red;
                TextBoxInfo.Foreground = Brushes.Red;
                switch (erreur)
                {
                    case 1:
                        TextBoxInfo.Text = "Le nom ne doit pas être vide.";
                        break;
                    case 2:
                        TextBoxInfo.Text = string.Format("La faction {0} est déjà existante.", tb.Text);
                        break;
                    case 3:
                        TextBoxInfo.Text = string.Format("Le type {0} est déjà existant.", tb.Text);
                        break;
                    case 4:
                        TextBoxInfo.Text = string.Format("Un caractère interdit a été détecté.", tb.Text);
                        break;
                }
            }
            else
            {
                ButtonAjouter.IsEnabled = true;
                BorderTextBox.BorderBrush = Brushes.Green;
                TextBoxInfo.Foreground = Brushes.Green;
                TextBoxInfo.Text = "Ce nom est correct.";
            }
        }

        private void ButtonAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (TypeConcerné == typeof(Faction))
            {
                Faction f = new Faction(TextBoxNom.Text);
                Mana.AjouterFaction(f);
                FenetrePrincipale.ListBoxFactions.SelectedItem = f;
            }
            else
            {
                Mana.AjouterTypeBatiment(new TypeBatiment(TextBoxNom.Text));
            }
            this.Close();
        }

        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
