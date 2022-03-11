using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.ComponentModel;
using Microsoft.AspNet.SignalR.Client;

namespace Chat_Client_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ICollectionView cv;

        private HubConnection hubConnection;

        private IHubProxy ChatHubProxy;

        private List<string> list = new List<string>();

        Window w = new Window();

        TextBox tb_user = new TextBox();

        string user;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hubConnection = new HubConnection("https://localhost:44358/");

            ChatHubProxy = hubConnection.CreateHubProxy("ChatHub");

            ChatHubProxy.On("Empfange", (text) => Empfangen(text));

            cv = CollectionViewSource.GetDefaultView(list);

            hubConnection.Start().Wait();

            SetUser();
        }
        private void bt_sendAll_Click(object sender, RoutedEventArgs e)
        {
            string msg = $"{user}:\t{tb_msg.Text}";

            list.Add(msg);

            Dispatcher.Invoke(() =>
            {
                lv_msg.DataContext = null;
                lv_msg.DataContext = list;
            });

            ChatHubProxy.Invoke("SendeAnAlle", msg).Wait();

        }

        private void SetUser()
        {
            StackPanel sp = new StackPanel();

            Label l = new Label();

            Button bt_ok = new Button();

            l.Content = "Name: ";

            tb_user.Width = 200;
            tb_user.Height = 25;
            tb_user.VerticalContentAlignment = VerticalAlignment.Center;
            tb_user.Margin = new Thickness(5,5,5,5);

            bt_ok.Content = "OK";
            bt_ok.Width = 100;
            bt_ok.Height = 25;
            bt_ok.VerticalContentAlignment = VerticalAlignment.Center;
            bt_ok.Click += Bt_ok_Click; 

            sp.Orientation = Orientation.Vertical;

            sp.Children.Add(l);
            sp.Children.Add(tb_user);
            sp.Children.Add(bt_ok);

            w.Content = sp;

            w.Width = 250;
            w.Height = 150;

            w.ShowDialog();
        }

        private void Bt_ok_Click(object sender, RoutedEventArgs e)
        {
            ChatHubProxy.Invoke("AddToGroup", tb_user.Text).Wait();

            user = tb_user.Text;


            w.Close();           
        }
        
        private void Empfangen(string text)
        {
            list.Add(text);

            Dispatcher.Invoke(() =>
            {
                lv_msg.DataContext = null;
                lv_msg.DataContext = list;
            });
            
        }

        private void bt_sendUser_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_send.Text))
            {
                string[] array = new string[2];

                array[0] = tb_send.Text as string;
                array[1] = $"{user}:\t{tb_msg.Text}";

                list.Add(array[1]);


                ChatHubProxy.Invoke("SendeAnUser", array);
            }
            
            
        }

        
    }
}
