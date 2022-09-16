using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch1_0.Converters;

public class DictAndCatToIntConverter : IMultiValueConverter, IMarkupExtension
{
    public object MediumPriority { get; set; }
    public object MaximumPriority { get; set; }
    public object MinimumPriority { get; set; }
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values != null && values[0] is Dictionary<string, int> dict &&
            values[1] is string key)
        {
            if (!dict.ContainsKey(key)) return MediumPriority;
            if (dict[key] == 0) return MediumPriority;
            if (dict[key] == 1) return MaximumPriority;
            return MinimumPriority;
        }
        else
        {
            return MediumPriority;
        }
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}
