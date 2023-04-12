using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            count++;

            var viewmodel = this.listView.BindingContext as ContactsViewModel;
            viewmodel.Contactsinfo.Add(new Contacts()
            {
                ContactName = "New Item" + count.ToString(),
                ContactNumber = "789 - 123",
                ContactImage = ImageSource.FromResource("ListViewXamarin.Images.Image15.png")
            });

            this.listView.RefreshListViewItem(-1, -1, true);
        }
    }
}
