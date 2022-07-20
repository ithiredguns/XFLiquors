using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFLiquors.Converters
{
    //Rounds to one digit after the decimal ( If rating is 4.25, rounds it to 4.3 )
    public class IsNumberIntConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number;
            var result = int.TryParse(value.ToString(), out number);

            return number == 0 ? System.Convert.ToDouble(value).ToString("N1") : number.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
