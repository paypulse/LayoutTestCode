using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace LoadXmlResources
{
    class LoadXamlResources :Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new LoadXamlResources());
        }

        public LoadXamlResources()
        {
            Title = "Load Xaml Resouces";
            Uri uri = new Uri("pack://application:,,,/LoadXamlResources.xml");
            Stream stream = Application.GetResourceStream(uri).Stream;
            FrameworkElement el = XamlReader.Load(stream) as FrameworkElement;
            Content = el;

            Button btn = el.FindName("My Button") as Button;
            if(btn != null)
            {
                btn.Click += ButtonOnClick;
            }

        }

        void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            MessageBox.Show("The button labeled'"+ (args.Source as Button).Content +
                "' has been clicked");
        }


    }
}
