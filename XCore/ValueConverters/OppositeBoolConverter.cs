using System;
using System.Globalization;
using MvvmCross.Converters;

namespace XCore.ValueConverters
{
    public class OppositeBoolConverter : MvxValueConverter<bool, bool>
    {
        protected override bool Convert(bool value, Type targetType, object parameter, CultureInfo culture) => !value;
        protected override bool ConvertBack(bool value, Type targetType, object parameter, CultureInfo culture) => !value;
    }
}
