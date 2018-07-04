using System;
using System.Collections.Generic;
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
using lib;
using BDD;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using System.IO;

namespace IHM
{
    public partial class MainWindow : Window
    {
        public Manager Mana { get; private set; }

        public Faction SelectedFaction { get; private set; }

        public TypeBatiment SelectedTypeBat { get; private set; }

        public Batiment DisplayedBatiment { get; private set; }

        public bool IsModifiable { get; private set; }

        public int? CheckedBoutonEtat { get; set; }

        private string importer_initialdirectory { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Mana = creationManager();
            this.DataContext = Mana;
            UpdateDetailsEtat();
        }

        public Manager creationManager()
        {
            Manager manager = new Manager();
            manager.DataMgr = new XMLDataMgr();
            manager.Load();
            return manager;
        }

        private void UpdateDetailsBatiment()
        {
            if (SelectedFaction != null && SelectedTypeBat != null && SelectedFaction.contientBatimentDeType(SelectedTypeBat))
            {
                DisplayedBatiment = SelectedFaction.getBatiment(SelectedTypeBat);
                DebugMsg(string.Format("GridDetails1.DataContext = {0}", DisplayedBatiment.Nom));
            }
            else
            {
                DisplayedBatiment = null;
            }

            GridDetails1.DataContext = DisplayedBatiment;

            UpdateButtonsEtat();
        }


        private void UpdateButtonsEtat()
        {
            if (DisplayedBatiment == null || DisplayedBatiment.Count == 0)
            {
                RadioButton1.IsEnabled = false;
                RadioButton2.IsEnabled = false;
                RadioButton3.IsEnabled = false;
                return;
            }

            switch (DisplayedBatiment.Count)
            {
                case 1:
                    RadioButton1.IsEnabled = true;
                    RadioButton2.IsEnabled = false;
                    RadioButton3.IsEnabled = false;
                    break;
                case 2:
                    RadioButton1.IsEnabled = true;
                    RadioButton2.IsEnabled = true;
                    RadioButton3.IsEnabled = false;
                    break;
                case 3:
                    RadioButton1.IsEnabled = true;
                    RadioButton2.IsEnabled = true;
                    RadioButton3.IsEnabled = true;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }


        private void ListBoxFactions_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            SelectedFaction = (sender as ListBox).SelectedItem as Faction;
            if (SelectedFaction != null)
            {
                DebugMsg(string.Format("SelectedFaction = {0}", SelectedFaction.Nom));
            }
            ViewboxImageFaction.DataContext = SelectedFaction;

            UpdateDetailsBatiment();
            UpdateDetailsEtat();
        }

        private void ListBoxTypeBat_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            SelectedTypeBat = (sender as ListBox).SelectedItem as TypeBatiment;
            if (SelectedTypeBat != null)
            {
                DebugMsg(string.Format("SelectedTypeBat = {0}", SelectedTypeBat.Nom));
            }

            DetailsTypeBat.DataContext = SelectedTypeBat;

            if (SelectedFaction != null)
            {
                UpdateDetailsBatiment();
                UpdateDetailsEtat();
            }
        }

        private void UpdateDetailsEtat()
        {
            if (DisplayedBatiment != null)
            {
                if (CheckedBoutonEtat == 1 && DisplayedBatiment.Count > 0)
                {
                    GridDetailsEtat.DataContext = DisplayedBatiment[1];
                    return;
                }

                if (CheckedBoutonEtat == 2 && DisplayedBatiment.Count > 1)
                {
                    GridDetailsEtat.DataContext = DisplayedBatiment[2];
                    return;
                }

                if (CheckedBoutonEtat == 3 && DisplayedBatiment.Count > 2)
                {
                    GridDetailsEtat.DataContext = DisplayedBatiment[3];
                    return;
                }
            }

            GridDetailsEtat.DataContext = null;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (sender as RadioButton);
            DebugMsg(string.Format("{0} : checked !", rb.Name));

            if (rb.Name == "RadioButton1") { CheckedBoutonEtat = 1; }
            if (rb.Name == "RadioButton2") { CheckedBoutonEtat = 2; }
            if (rb.Name == "RadioButton3") { CheckedBoutonEtat = 3; }

            UpdateDetailsEtat();
        }

        private void Button_Click_AjouterFaction(object sender, RoutedEventArgs e)
        {
            WindowCreerFactionOuTypeBat wcf = new WindowCreerFactionOuTypeBat(this, typeof(Faction), Mana);
            wcf.ShowDialog();
        }

        private void Button_Click_AjouterTypeBat(object sender, RoutedEventArgs e)
        {
            WindowCreerFactionOuTypeBat wcf = new WindowCreerFactionOuTypeBat(this, typeof(TypeBatiment), Mana);
            wcf.ShowDialog();
        }

        private void Button_Click_SupprFaction(object sender, RoutedEventArgs e)
        {
            if (SelectedFaction != null)
            {
                Mana.SupprimerFaction(SelectedFaction);
            }
        }

        private void Button_Click_SupprTypeBat(object sender, RoutedEventArgs e)
        {
            if (SelectedTypeBat != null)
            {
                Mana.SupprimerTypeBatiment(SelectedTypeBat);
            }
        }

        private void Button_Click_SupprEtat(object sender, RoutedEventArgs e)
        {
            if (DisplayedBatiment != null && DisplayedBatiment.Count > 0)
            {
                DebugMsg(string.Format("[Batiment {0}] Niveau {1} supprimé", DisplayedBatiment.Nom, DisplayedBatiment.Count));
                DisplayedBatiment.supprimerEtat();
                UpdateButtonsEtat();
                UpdateDetailsEtat();
            }
        }

        private void Button_Click_AjouterEtat(object sender, RoutedEventArgs e)
        {
            if (DisplayedBatiment != null && DisplayedBatiment.Count < 3)
            {
                DebugMsg(string.Format("[Batiment {0}] Niveau {1} ajouté", DisplayedBatiment.Nom, DisplayedBatiment.Count + 1));
                DisplayedBatiment.ajouterEtat();
                UpdateButtonsEtat();
                UpdateDetailsEtat();
            }
        }

        public void UserControl_SupprBatiment(UserControlListBoxItem uc)
        {
            if (!(uc.Item is TypeBatiment)) { throw new InvalidOperationException(); }

            Faction temp = SelectedFaction;

            SelectedFaction.supprimerBatiment(uc.Item as TypeBatiment);

            ListBoxFactions.SelectedItem = null;
            ListBoxFactions.SelectedItem = temp;

            UpdateButtonsEtat();
            UpdateDetailsEtat();
            UpdateDetailsBatiment();
        }

        public void UserControl_AjouterBatiment(UserControlListBoxItem uc)
        {
            if (!(uc.Item is TypeBatiment)) { throw new InvalidOperationException(); }

            Faction temp = SelectedFaction;

            SelectedFaction.ajouterBatiment(uc.Item as TypeBatiment, "*Nouveau bâtiment*");

            ListBoxFactions.SelectedItem = null;
            ListBoxFactions.SelectedItem = temp;

            UpdateButtonsEtat();
            UpdateDetailsEtat();
            UpdateDetailsBatiment();
        }

        private void ToggleButtonModifier_Click(object sender, RoutedEventArgs e)
        {
            DebugMsg("togglebuttonmodifié a changé d'état!");
            switch (ToggleButtonModifier.IsChecked)
            {
                case true:
                    IsModifiable = true;
                    break;
                case false:
                    IsModifiable = false;
                    ToggleButtonEdit.IsChecked = false;
                    ToggleButtonEdit2.IsChecked = false;
                    break;
                default:
                    throw new Exception("ToggleButtonModifier est null.");
            }
        }

        private void ButtonSauvegarder_Click(object sender, RoutedEventArgs e)
        {
            Mana.DataMgr = new XMLDataMgr();
            Mana.Save();

            Storyboard sb = this.FindResource("storyboard_popup") as Storyboard;
            sb.Begin();

            DebugMsg("Fichier XML sauvegardé avec succès");
        }

        private void ImporterImg_Batiment_Click(object sender, RoutedEventArgs e)
        {
            if (DisplayedBatiment != null)
            {
                OpenFileDialog dlg = new OpenFileDialog();

                if (Importer_FileDialog(dlg) == true)
                {
                    DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory());
                    dirInfo = dirInfo.Parent;

                    string nomFinal = string.Format("{0}_{1}{2}", SelectedFaction.Nom, SelectedTypeBat.Nom, System.IO.Path.GetExtension(dlg.SafeFileName));

                    string source = dlg.FileName;
                    string destination = string.Format("{0}\\images\\batiments\\{1}", dirInfo.FullName, nomFinal);

                    System.IO.File.Copy(source, destination, true);

                    DisplayedBatiment.Image = nomFinal;
                    importer_initialdirectory = System.IO.Path.GetDirectoryName(source);
                    DebugMsg("DisplayedBatiment.Image = " + nomFinal);

                    #region update bourrin de l'image
                    TypeBatiment temp = SelectedTypeBat;

                    ListBoxTypeBat.SelectedItem = null;
                    ListBoxTypeBat.SelectedItem = temp;
                    #endregion
                }
            }
        }

        private void ImporterImg_Faction_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedFaction != null)
            {
                OpenFileDialog dlg = new OpenFileDialog();

                if (Importer_FileDialog(dlg) == true)
                {
                    DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory());
                    dirInfo = dirInfo.Parent;
                    string nomFinal = string.Format("f_{0}{1}", SelectedFaction.Nom, System.IO.Path.GetExtension(dlg.SafeFileName));

                    string source = dlg.FileName;
                    string destination = string.Format("{0}\\images\\factions\\{1}", dirInfo.FullName, nomFinal);

                    System.IO.File.Copy(source, destination, true);

                    SelectedFaction.Image = nomFinal;
                    importer_initialdirectory = System.IO.Path.GetDirectoryName(source);
                    DebugMsg("SelectedFaction.Image = " + nomFinal);

                    #region update bourrin de l'image
                    Faction temp = SelectedFaction;

                    ListBoxFactions.SelectedItem = null;
                    ListBoxFactions.SelectedItem = temp;
                    #endregion
                }
            }
        }

        private bool? Importer_FileDialog(OpenFileDialog dlg)
        {
            if (importer_initialdirectory == null)
            {
                dlg.InitialDirectory = "C:\\";
            }
            else
            {
                dlg.InitialDirectory = importer_initialdirectory;
            }
            dlg.DefaultExt = ".jpg | .png | .gif";
            dlg.Filter = "All images files (.jpg, .png, .gif)|*.jpg;*.png;*.gif|JPG files (.jpg)|*.jpg|PNG files (.png)|*.png|GIF files (.gif)|*.gif";

            return dlg.ShowDialog();
        }


        private void ToggleButtonEdit_Checked(object sender, RoutedEventArgs e)
        {
            TextBlockBatimentNom.Visibility = Visibility.Collapsed;
            TextBoxBatimentNom.Visibility = Visibility.Visible;
            TextBoxBatimentNom.Focus();
        }

        private void TextBoxBatimentNom_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBoxBatimentNom.Visibility = Visibility.Collapsed;
            TextBlockBatimentNom.Visibility = Visibility.Visible;
        }

        private void TextBoxBatimentNom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ToggleButtonEdit.IsChecked = false;
                ToggleButtonEdit.Focus();
            }
        }

        private void ToggleButtonEdit2_Checked(object sender, RoutedEventArgs e)
        {
            TextBlockTBDescription.Visibility = Visibility.Collapsed;
            TextBoxTBDescription.Visibility = Visibility.Visible;
            TextBoxTBDescription.Focus();
        }

        private void TextBoxTBDescription_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBoxTBDescription.Visibility = Visibility.Collapsed;
            TextBlockTBDescription.Visibility = Visibility.Visible;
        }

        private void TextBoxTBDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ToggleButtonEdit2.IsChecked = false;
                ToggleButtonEdit2.Focus();
            }
        }

        public void DebugMsg(string info)
        {
            Info1.Text = Info2.Text;
            Info2.Text = string.Format("  [{0}] {1}", DateTime.Now.ToLongTimeString(), info);
        }
    }
}
