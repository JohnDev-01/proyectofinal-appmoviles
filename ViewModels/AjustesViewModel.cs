using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace proyectofinal_appmoviles.ViewModels
{
    public class AjustesViewModel : INotifyPropertyChanged
    {
        private bool _darkModeEnabled = false;
        private string? _themePreference;

        public bool DarkModeEnabled
        {
            get => _darkModeEnabled;
            set => SetField(ref _darkModeEnabled, value);
        }

        public string? ThemePreference
        {
            get => _themePreference;
            set => SetField(ref _themePreference, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
