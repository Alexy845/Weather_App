using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using System.Net.NetworkInformation;

namespace Weather_App;

public partial class NoInternet : Window
{
    public NoInternet()
    {
        Console.WriteLine("Nouvelle Page");
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (NetworkInterface.GetIsNetworkAvailable())
        {
            var window = new MainWindow();
            window.Show();
            Close();
        }
    }
}