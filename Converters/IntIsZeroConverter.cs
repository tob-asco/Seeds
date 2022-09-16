using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch1_0.Converters;

internal class IntIsZeroConverter : IValueConverter, IMarkupExtension
{
    public object IntIsZero { get; set; }
    public object IntIsNotZero { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if ((int)value == 0) return IntIsZero;
        return IntIsNotZero;
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
