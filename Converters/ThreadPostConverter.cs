using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch1_0.Converters
{
    public class ThreadPostConverter : IMarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 2 && values[0] != null && values[1] != null)
            {
                Thread thread = new()
                {
                    Text = values[0].ToString(),
                    Type = values[1].ToString()
                };
                if (values[1].ToString() == "none") thread.Type = "";

                return thread;
            }
            return null;
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
}
