using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Windows.Input;

namespace Trash;

public partial class Changer : ContentView
{
    private int? _value;

    public static readonly BindableProperty TextProperty =
           BindableProperty.Create(
               propertyName: nameof(Text),
               returnType: typeof(string),
               defaultValue: "0",
               defaultBindingMode: BindingMode.TwoWay,
               declaringType: typeof(Changer),
               propertyChanged: (bindable, _, _) =>
               {
                   var @this = (Changer)bindable;
                   Trace.WriteLine("Changer.Text changed!");
                   ((Command)@this.UpCommand).ChangeCanExecute();
                   ((Command)@this.DownCommand).ChangeCanExecute();
               });

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public ICommand UpCommand { get; }
    public ICommand DownCommand { get; }

    public Changer()
	{
        UpCommand = new Command(
            execute: () => Text = $"{_value + 1}",
            canExecute: () =>
            {
                Trace.WriteLine("Changer.UpCommand.CanExecute() executed!");
                if (int.TryParse(Text, out int x))
                {
                    _value = x;
                    return true;
                }
                _value = null;
                return false;
            }
        );

        DownCommand = new Command(
            execute: () => Text = $"{_value - 1}",
            canExecute: () =>
            {
                Trace.WriteLine("Changer.DownCommand.CanExecute() executed!");
                if (int.TryParse(Text, out int x))
                {
                    _value = x;
                    return _value > 0;
                }

                _value = null;
                return false;
            }
        );


		InitializeComponent(); // It must be called last!
    }
}