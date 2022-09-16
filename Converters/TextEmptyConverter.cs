using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch1_0.Converters
{
    //most of this code is generic and created with the ligh bulb
    //upon inhereting from the two classes IMarkupExtension & IValueConverter
    public class TextEmptyConverter : IMarkupExtension, IValueConverter
    {
        public object TextIsEmpty { get; set; }
        public object TextIsNotEmpty { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == null | (string)value == "") { return TextIsEmpty; }
            return TextIsNotEmpty;
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

