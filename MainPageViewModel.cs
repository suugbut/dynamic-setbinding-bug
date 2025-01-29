using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Trash;
public class MainPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private int _valueA;
    public int ValueA
    {
        get => _valueA;
        set
        {
            _valueA = value;
            OnPropertyChanged();
        }
    }

    private int _valueB;
    public int ValueB
    {
        get => _valueB;
        set
        {
            _valueB = value;
            OnPropertyChanged();
        }
    }
}
