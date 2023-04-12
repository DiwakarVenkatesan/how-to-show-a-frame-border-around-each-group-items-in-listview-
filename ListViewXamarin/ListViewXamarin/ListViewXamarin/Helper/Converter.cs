using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Syncfusion.ListView.XForms;
using Syncfusion.DataSource.Extensions;
using Syncfusion.DataSource;
using System.Linq;
using System.Collections;

namespace ListViewXamarin
{
    #region CornerRadius Converter
    public class CornerRadiusConverter : IValueConverter
    {
        Thickness firstItemThickness;
        Thickness lastItemThickness;
        Thickness defaultThickness;
        Thickness fullBorderThickness;
        int itemIndex = 0;
        public CornerRadiusConverter()
        {
            firstItemThickness = new Thickness(15, 15, 0, 0);
            defaultThickness = new Thickness(0, 0, 0, 0);
            lastItemThickness = new Thickness(0, 0, 15, 15);
            fullBorderThickness = new Thickness(15);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var listView = parameter as SfListView;
            var itemData = value as Contacts;
            object key = null;
            GroupResult actualGroup = null;
            var descriptor = listView.DataSource.GroupDescriptors[0];

            if (value == null)
                return defaultThickness;

            if (itemData == null)
                return defaultThickness;
            else
            {
                key = descriptor.KeySelector(itemData);
                for (int i = 0; i < listView.DataSource.Groups.Count; i++)
                {
                    var group = listView.DataSource.Groups[i];
                    if ((group.Key != null && group.Key.Equals(key)) || group.Key == key)
                    {
                        actualGroup = group;
                        break;
                    }
                }

                var items = actualGroup.Items.ToList<object>();

                var lastItem = actualGroup.GetGroupLastItem();
                var fistItem = this.GetFirstItem(actualGroup.Items);

                if (items.Count() == 1)
                {
                    return fullBorderThickness;
                }

                if (fistItem == itemData)
                {
                    return firstItemThickness;
                }
                else if (lastItem == itemData)
                {
                    return lastItemThickness;
                }

                return defaultThickness;
            }
        }

        private object GetFirstItem(IEnumerable items)
        {
            return items.ToList<object>().FirstOrDefault();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }        
    }
    #endregion

    #region BorderThickness Converter
    public class BorderThicknessConverter : IValueConverter
    {
        Thickness defaultThickness;
        Thickness fullBorderThickness;
        public BorderThicknessConverter()
        {
            defaultThickness = new Thickness(1, 1, 1, 0);
            fullBorderThickness = new Thickness(1);
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var listView = parameter as SfListView;
            var itemData = value as Contacts;
            object key = null;
            GroupResult actualGroup = null;
            var descriptor = listView.DataSource.GroupDescriptors[0];

            if (value == null)
                return new Thickness(0, 0, 0, 0);

            if (itemData == null)
                return new Thickness(0, 0, 0, 0);
            else
            {
                key = descriptor.KeySelector(itemData);
                for (int i = 0; i < listView.DataSource.Groups.Count; i++)
                {
                    var group = listView.DataSource.Groups[i];
                    if ((group.Key != null && group.Key.Equals(key)) || group.Key == key)
                    {
                        actualGroup = group;
                        break;
                    }
                }
                var lastItem = actualGroup.GetGroupLastItem();
                var fistItem = this.GetFirstItem(actualGroup.Items);

                if (actualGroup.Items.ToList<object>().Count() == 1 || lastItem == itemData)
                {
                    return fullBorderThickness;
                }
                else
                {
                    return defaultThickness;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        private object GetFirstItem(IEnumerable items)
        {
            return items.ToList<object>().FirstOrDefault();
        }
    }
    #endregion
}
