﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace MVVM.Converter
{
    //Converter, welcher die Reflection-Objekte (durch ihren Positionsindex und den ObjektDataProvider)
    //aus der ComboBox in Color-Objekte für Person.Lieblingsfarbe umwandeln (und zurück)
    class ColorToIndexerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PropertyInfo[] props = (parameter as ObjectDataProvider).Data as PropertyInfo[];

            Color color = (Color)value;

            for (int i = 0; i < props.Length; i++)
            {
                var color2 = props[i].GetGetMethod().Invoke(new object(), new object[] { });
                if (color.Equals(color2))
                    return i;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((parameter as ObjectDataProvider).Data as PropertyInfo[])[(int)value].GetGetMethod().Invoke(new object(), new object[] { });
        }
    }
}
