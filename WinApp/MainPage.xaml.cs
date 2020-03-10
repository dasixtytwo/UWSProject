using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WinApp
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
        this.InitializeComponent();
    }

    private void NavView_Loaded(object sender, RoutedEventArgs e)
    {
      NavView.MenuItems.Add(new NavigationViewItem
      {
        Content = "Employees",
        Icon = new SymbolIcon(Symbol.BrowsePhotos),
        Tag = "employees"
      });
    }

    private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
      switch (args.InvokedItem.ToString())
      {
        case "Employees":
          ContentFrame.Navigate(typeof(EmployeesPage));
          break;

        default:
          ContentFrame.Navigate(typeof(NotImplementedPage));
          break;
      }
    }

    private async void RefreshButton_Click(object sender, RoutedEventArgs e)
    {
      var notImplementedDialog = new ContentDialog
      {
        Title = "Not implemented",
        Content ="The Refresh functionality has not yet been implemented.",
        CloseButtonText = "OK"
      };
      ContentDialogResult result =
         await notImplementedDialog.ShowAsync();
    }
  }
}
