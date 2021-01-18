using System;
using System.Globalization;
using MvvmCross.Converters;

namespace XCore.ValueConverters
{
    public class StringIsNullOrEmptyValueConverter : MvxValueConverter<string, bool>
    {
        protected override bool Convert(string value, Type targetType, object parameter, CultureInfo culture)
            => string.IsNullOrEmpty(value);

        protected override string ConvertBack(bool value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
