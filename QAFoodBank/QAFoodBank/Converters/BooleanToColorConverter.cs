using System;
using System.Globalization;
using Xamarin.Forms;

namespace QAFoodBank.Converters
{
    public class BooleanToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var converter = new ColorTypeConverter();
			if ((value is Boolean && (Boolean)value == true) || (value is Boolean? && (Boolean?)value == true))
<<<<<<< HEAD
                return Xamarin.Forms.Color.Orange;
=======
                return Xamarin.Forms.Color.LightBlue;
>>>>>>> cb604b2feefe91e0f2e7de98f175de3e81e49cdf
            
            return Xamarin.Forms.Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
