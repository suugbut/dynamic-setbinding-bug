using System.Diagnostics;

namespace Trash;

public partial class MainPage : ContentPage
{
    private MainPageViewModel _model;
    public MainPage()
    {
        InitializeComponent();
        _model = new MainPageViewModel { ValueA = 2, ValueB = 2 };
        BindingContext = _model;
        RadioValueA.IsChecked = true;
    }

    private void Radio_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {            
            var rb = sender as RadioButton;
            if (rb == RadioValueA)
            {
                Trace.WriteLine("Radio A");

                ChangerInstance.SetBinding(Changer.TextProperty, nameof(MainPageViewModel.ValueA));
                
                // Why should I call the following?
                // ChangerInstance.Text = _model.ValueA.ToString();
            }
            if (rb == RadioValueB)
            {
                Trace.WriteLine("Radio B");

                ChangerInstance.SetBinding(Changer.TextProperty, nameof(MainPageViewModel.ValueB));
                
                // Why should I call the following?
                // ChangerInstance.Text = _model.ValueB.ToString();
            }
        }
    }
}
