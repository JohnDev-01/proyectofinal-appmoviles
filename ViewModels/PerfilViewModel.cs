using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace proyectofinal_appmoviles.ViewModels
{
    public class PerfilViewModel : INotifyPropertyChanged
    {
        private string _userName = string.Empty;
        private string _email = string.Empty;
        private string _avatarUrl = "default_avatar.png";

        public string UserName
        {
            get => _userName;
            set => SetField(ref _userName, value);
        }

        public string Email
        {
            get => _email;
            set => SetField(ref _email, value);
        }

        public string AvatarUrl
        {
            get => _avatarUrl;
            set => SetField(ref _avatarUrl, value);
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
