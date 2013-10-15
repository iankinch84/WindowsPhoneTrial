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
            Classes.HttpHandler_2 test = new Classes.HttpHandler_2();
            HttpHandler temp = new HttpHandler();

            Dictionary<string, string> parameter = new Dictionary<string, string>()
            {
                {"u", "ian_kinch"},
                {"p", "asdasdasd"}
            };

            try
            {
                test.Request("user", "login", "post", parameter, null);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            
        }
    }
}