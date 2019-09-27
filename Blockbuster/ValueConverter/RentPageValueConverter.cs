using Blockbuster.Enums;
using Blockbuster.Views.Rent;
using System;
using System.Globalization;

namespace Blockbuster.ValueConverter
{
    public class RentPageValueConverter : BaseValueConverter<RentPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((RentPages)value)
            {
                case RentPages.Rent:
                    return new RentMovieView();
                case RentPages.Return:
                    return new ReturnMovieView();
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
