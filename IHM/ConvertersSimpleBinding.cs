using lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IHM
{
    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && parameter != null)
            {
                //return new BitmapImage(new Uri(String.Format("images/batiments/{0}", value as string), UriKind.Relative));
                DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory());
                dirInfo = dirInfo.Parent;

                string source = string.Format("{0}\\images\\{1}\\{2}", dirInfo.FullName, parameter as string, value as string);

                if (!(File.Exists(source)))
                {
                    source = string.Format("{0}\\images\\{1}\\notfound.jpg", dirInfo.FullName, parameter as string);
                }

                //BitmapImage bitmap = new BitmapImage(new Uri(source, UriKind.Absolute));   //bloque le fichier source

                MemoryStream ms = new MemoryStream();
                BitmapImage bitmap = new BitmapImage();
                byte[] bytArray = File.ReadAllBytes(source);
                ms.Write(bytArray, 0, bytArray.Length); ms.Position = 0;
                bitmap.BeginInit();
                bitmap.StreamSource = ms;
                bitmap.EndInit();

                return bitmap;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StringToIcone : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                return new BitmapImage(new Uri(String.Format("images/icones/{0}", value as string), UriKind.Relative));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ElementModifiable_Visibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? isModifiable = value as bool?;

            if (isModifiable == true)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DataContext_To_Visibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
