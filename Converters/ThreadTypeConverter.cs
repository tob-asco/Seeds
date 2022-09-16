using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch1_0.Converters;

public class ThreadTypeConverter : IValueConverter, IMarkupExtension
{
    public string ThreadType { get; set; }
    public int Index { get; set; }
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value != null && value is string)
        {
            //string str = value.ToString();
            //if (str.StartsWith('?')) ThreadType = "?";
            //else if (str.StartsWith('!')) ThreadType = "!";
            //else if (str.StartsWith('+')) ThreadType = "+1";
            //else if (str.StartsWith('-')) ThreadType = "-1";
            //else ThreadType = "";
            string type = value.ToString();
            if (type == "?") Index = 1;
            else if (type == "!") Index = 2;
            else if (type == "+1") Index = 3;
            else if (type == "-1") Index = 4;
            else Index = 0;
        }
        return Index;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value != null && value is int)
        {
            //string str = value.ToString();
            //if (str.StartsWith('?')) ThreadType = "?";
            //else if (str.StartsWith('!')) ThreadType = "!";
            //else if (str.StartsWith('+')) ThreadType = "+1";
            //else if (str.StartsWith('-')) ThreadType = "-1";
            //else ThreadType = "";
            int index = (int)value;
            if (index == 1) ThreadType = "?";
            else if (index == 2) ThreadType = "!";
            else if (index == 3) ThreadType = "+1";
            else if (index == 4) ThreadType = "-1";
            else ThreadType = "";
        }

        return ThreadType;
    }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}
