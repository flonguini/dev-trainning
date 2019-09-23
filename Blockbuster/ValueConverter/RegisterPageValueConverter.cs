using Blockbuster.Enums;
using Blockbuster.Views.Register;
using System;
using System.Globalization;

namespace Blockbuster.ValueConverter
{
    public class RegisterPageValueConverter : BaseValueConverter<RegisterPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((RegisterPages)value)
            {
                case RegisterPages.Client:
                    return new RegisterClientView();
                case RegisterPages.Movie:
                    return new RegisterMovieView();
                default:
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
