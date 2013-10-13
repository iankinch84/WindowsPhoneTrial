using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;


namespace Pararaton___Windows_Phone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            HttpHandler test = new HttpHandler();

            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"u", "ian_kinch"},
                {"p", "asdasdasd"}
            };

            string temp = test.Request("user", "login", "post", parameter, null);
        }
    }
}