using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace proyectofinal_appmoviles.ViewModels
{
    public class InicioViewModel : INotifyPropertyChanged
    {
        private string _welcomeMessage = "Bienvenido";
        private bool _isLoading;

        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set => SetField(ref _welcomeMessage, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetField(ref _isLoading, value);
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
