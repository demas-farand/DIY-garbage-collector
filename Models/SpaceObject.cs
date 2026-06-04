using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace CustomGarbageCollector.Models;

public abstract class SpaceObject : IMemoryEntity, INotifyPropertyChanged
{
    public string Id { get; protected set; } = string.Empty;
    public double Mass { get; protected set; }
    public bool IsGarbage { get; protected set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Size { get; protected set; }

    private int _generation = 0;
    public int Generation
    {
        get => _generation;
        set
        {
            if (_generation != value)
            {
                _generation = value;
                OnPropertyChanged();
            }
        }
    }
    private string _colorHex = "#FFFFFF";
    public string ColorHex 
    { 
        get => _colorHex;
        protected set
        {
            if (_colorHex != value)
            {
                _colorHex = value;
                OnPropertyChanged();
            }
        }
    }

    protected SpaceObject(double mass)
    {
        Mass = mass;
        IsGarbage = false;
    }

    public virtual void MarkAsGarbage()
    {
        IsGarbage = true;
        ColorHex = "#80FF3333"; 
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}