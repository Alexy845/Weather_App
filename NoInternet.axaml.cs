using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Net.NetworkInformation;

namespace Weather_App;

public partial class NoInternet : Window
{
    public NoInternet()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (NetworkInterface.GetIsNetworkAvailable() && Internet.DnsTest())
        {
            var window = new MainWindow();
            window.Show();
            Close();
        }
    }
}