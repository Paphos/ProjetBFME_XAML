using lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IHM
{
    /// <summary>
    /// Logique d'interaction pour UserControlEtat.xaml
    /// </summary>
    public partial class UserControlEtat : UserControl
    {

        public string Champ
        {
            get { return (string)GetValue(ChampProperty); }
            set { SetValue(ChampProperty, value); }
        }
        public static readonly DependencyProperty ChampProperty =
            DependencyProperty.Register("Champ", typeof(string), typeof(UserControlEtat), new PropertyMetadata(null));


        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(UserControlEtat), new PropertyMetadata(null));


        public string Icone
        {
            get { return (string)GetValue(IconeProperty); }
            set { SetValue(IconeProperty, value); }
        }
        public static readonly DependencyProperty IconeProperty =
            DependencyProperty.Register("Icone", typeof(string), typeof(UserControlEtat), new PropertyMetadata(null));


        public bool? IsModifiable
        {
            get { return (bool?)GetValue(IsModifiableProperty); }
            set { SetValue(IsModifiableProperty, value); }
        }
        public static readonly DependencyProperty IsModifiableProperty =
            DependencyProperty.Register("IsModifiable", typeof(bool?), typeof(UserControlEtat), new PropertyMetadata(false));




        public UserControlEtat()
        {
            InitializeComponent();
        }

        private void Grid_DataContextChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {
            Binding myBinding = new Binding(Champ);
            myBinding.Source = GridUC.DataContext;
            TextBlockEtat.SetBinding(TextBlock.TextProperty, myBinding);
            TextBoxEtat.SetBinding(TextBox.TextProperty, myBinding);
        }

        private void ToggleButtonEdit_Checked(object sender, RoutedEventArgs e)
        {
            TextBlockEtat.Visibility = Visibility.Collapsed;
            TextBoxEtat.Visibility = Visibility.Visible;
            TextBoxEtat.Focus();
        }

        private void TextBoxEtat_LostKeyboardFocus_1(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBoxEtat.Visibility = Visibility.Collapsed;
            TextBlockEtat.Visibility = Visibility.Visible;
        }

        private void TextBoxEtat_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ToggleButtonEdit.IsChecked = false;
                ToggleButtonEdit.Focus();
            }
        }
    }
}
