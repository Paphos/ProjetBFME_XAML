using lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IHM
{
    public class MultiBinding_UserControl_IsActivé : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Faction factionSelectionnée = values[0] as Faction;
            object itemConcerné = values[1];

            if (itemConcerné is Faction) { return true; }

            TypeBatiment tb = itemConcerné as TypeBatiment;

            if (factionSelectionnée == null || tb == null || !(factionSelectionnée.contientBatimentDeType(tb)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class MultiBinding_ListBoxItem_IsEnabled : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? ToggleButtonModifier_IsChecked = values[0] as bool?;

            if (ToggleButtonModifier_IsChecked == true) { return true; }

            Faction factionSelectionnée = values[1] as Faction;
            object itemConcerné = values[2];

            if (itemConcerné is Faction) { return true; }

            TypeBatiment tb = itemConcerné as TypeBatiment;

            if (factionSelectionnée == null || tb == null || !(factionSelectionnée.contientBatimentDeType(tb)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BackgroundConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? isActivé = values[0] as bool?;
            bool? isModifiable = values[1] as bool?;
            bool? isSelected = values[2] as bool?;

            if (isActivé == true)
            {
                if (isSelected == true)
                    return Application.Current.Resources["grad_base_selected"];
                else
                    return Application.Current.Resources["grad_base"];
            }
            else
            {
                if (isModifiable == true)
                {
                    if (isSelected == true)
                        return Application.Current.Resources["grad_modifiable_selected"];
                    else
                        return Application.Current.Resources["grad_modifiable"];
                }
                else
                    return Application.Current.Resources["grad_base_disabled"];
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ForegroundConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? isActivé = values[0] as bool?;
            bool? isModifiable = values[1] as bool?;
            bool? isSelected = values[2] as bool?;

            if (isActivé == true)
            {
                if (isSelected == true)
                    return Application.Current.Resources["foreground_base_selected"];
                else
                    return Application.Current.Resources["foreground_base"];
            }
            else
            {
                if (isModifiable == true)
                {
                    if (isSelected == true)
                        return Application.Current.Resources["foreground_modifiable_selected"];
                    else
                        return Application.Current.Resources["foreground_modifiable"];
                }
                else
                    return Application.Current.Resources["foreground_disabled"];
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class Multibinding_CroixRouge_Visibility : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            object item = values[0];
            bool? isModifiable = values[1] as bool?;
            bool? isActivé = values[2] as bool?;

            if (item is TypeBatiment && isModifiable == true && isActivé == true)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Multibinding_PlusVert_Visibility : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            object item = values[0];
            bool? isModifiable = values[1] as bool?;
            bool? isActivé = values[2] as bool?;
            Faction selectedFaction = values[3] as Faction;

            if (item is TypeBatiment && isModifiable == true && isActivé == false && selectedFaction != null)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
