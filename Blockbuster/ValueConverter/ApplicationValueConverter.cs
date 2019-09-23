using Blockbuster.Enums;
using Blockbuster.Views;
using System;
using System.Globalization;

namespace Blockbuster.ValueConverter
{
    public class ApplicationValueConverter : BaseValueConverter<ApplicationValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPages)value)
            {
                case ApplicationPages.Register:
                    return new RegisterView();
                case ApplicationPages.Rent:
                    return new RentView();
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
