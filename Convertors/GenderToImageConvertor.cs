using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MedicalPlusFront.Convertors
{
    public class GenderToImageConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int genderId = (int)value;

            string imagePath = "man.png";

            if (genderId == 2)
                imagePath = "woman.png";

            BitmapImage image = new BitmapImage(new Uri($"pack://application:,,,/MedicalPlusFront;component/view/icons/{imagePath}"));
            return image;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
