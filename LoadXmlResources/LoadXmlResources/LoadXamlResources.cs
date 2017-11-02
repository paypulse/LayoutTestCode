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
          
            Uri uri = new Uri("pack://application:,,,/LoadXamlResources.xml");
            Stream stream = Application.GetResourceStream(uri).Stream;
            Window win = XamlReader.Load(stream) as Window;
            win.AddHandler(Button.ClickEvent, new RoutedEventHandler(ButtonOnClick));

            app.Run(win);
        }

        static void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            MessageBox.Show("The button labeled'"+ (args.Source as Button).Content +
                "' has been clicked");
        }

        /*각종 handler를 추가 하자. */



    }
}
