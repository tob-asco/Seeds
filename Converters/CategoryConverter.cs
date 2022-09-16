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
    public class CategoryConverter : IMarkupExtension, IValueConverter
    {
        public object MediumPriority { get; set; }
        public object MaximumPriority { get; set; }
        public object MinimumPriority { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            /*if (value != null && parameter != null &&
                value is Dictionary<string,int> && parameter is string)
            {
                Dictionary<string,int> dict = (Dictionary<string, int>)value;
                string key = (string)parameter;
                if (dict[key] == 0) return MediumPriority;
                if (dict[key] == 1) return MaximumPriority;
                return MinimumPriority;
            }
            else
            {
                return MediumPriority;
            }*/

            if ((int)value == 0) { return MediumPriority; }
            if ((int)value == 1) { return MaximumPriority; }
            return MinimumPriority;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this; // returns all the properties for access in XAML
        }
    }
}
