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

namespace IHM
{
    /// <summary>
    /// Logique d'interaction pour UserControlListBoxItem.xaml
    /// </summary>
    public partial class UserControlListBoxItem : UserControl
    {

        public MainWindow CurrentWindow
        {
            get { return (MainWindow)GetValue(CurrentWindowProperty); }
            set { SetValue(CurrentWindowProperty, value); }
        }
        public static readonly DependencyProperty CurrentWindowProperty =
            DependencyProperty.Register("CurrentWindow", typeof(MainWindow), typeof(UserControlListBoxItem), new PropertyMetadata(null));


        public object Item
        {
            get { return (object)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }
        public static readonly DependencyProperty ItemProperty =
            DependencyProperty.Register("Item", typeof(object), typeof(UserControlListBoxItem), new PropertyMetadata(null));


        public bool? IsSelected
        {
            get { return (bool?)GetValue(IsSelectedProperty); }
            set
            { 
                SetValue(IsSelectedProperty, value);
            }
        }
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool?), typeof(UserControlListBoxItem), new PropertyMetadata(false));


        public bool? IsActivé
        {
            get { return (bool?)GetValue(IsActivéProperty); }
            set
            {
                SetValue(IsActivéProperty, value);
            }
        }
        public static readonly DependencyProperty IsActivéProperty =
            DependencyProperty.Register("IsActivé", typeof(bool?), typeof(UserControlListBoxItem), new PropertyMetadata(false));


        public bool? IsModifiable
        {
            get { return (bool?)GetValue(IsModifiableProperty); }
            set
            {
                SetValue(IsModifiableProperty, value);
            }
        }
        public static readonly DependencyProperty IsModifiableProperty =
            DependencyProperty.Register("IsModifiable", typeof(bool?), typeof(UserControlListBoxItem), new PropertyMetadata(false));


        public Faction SelectedFaction
        {
            get { return (Faction)GetValue(SelectedFactionProperty); }
            set { SetValue(SelectedFactionProperty, value); }
        }
        public static readonly DependencyProperty SelectedFactionProperty =
            DependencyProperty.Register("SelectedFaction", typeof(Faction), typeof(UserControlListBoxItem), new PropertyMetadata(null));




        public UserControlListBoxItem()
        {
            InitializeComponent();
        }

        private void ButtonPlus_Click_1(object sender, RoutedEventArgs e)
        {
            CurrentWindow.UserControl_AjouterBatiment(this);
        }

        private void ButtonCroix_Click_1(object sender, RoutedEventArgs e)
        {
            CurrentWindow.UserControl_SupprBatiment(this);
        }

        
    }
}
