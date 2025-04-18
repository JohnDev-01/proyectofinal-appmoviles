using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;
using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;

namespace proyectofinal_appmoviles.ViewModels
{
    public class MiembrosViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;

        private ObservableCollection<MiembroDto> _miembros;
        public ObservableCollection<MiembroDto> Miembros
        {
            get => _miembros;
            set
            {
                _miembros = value;
                OnPropertyChanged();
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

// Form fields
private string _cedula;
public string Cedula
{
    get => _cedula;
    set
    {
        _cedula = value;
        OnPropertyChanged();
    }
}

private string _nombre;
public string Nombre
{
    get => _nombre;
    set
    {
        _nombre = value;
        OnPropertyChanged();
    }
}

private string _apellido;
public string Apellido
{
    get => _apellido;
    set
    {
        _apellido = value;
        OnPropertyChanged();
    }
}

private string _correo;
public string Correo
{
    get => _correo;
    set
    {
        _correo = value;
        OnPropertyChanged();
    }
}

private string _telefono;
public string Telefono
{
    get => _telefono;
    set
    {
        _telefono = value;
        OnPropertyChanged();
    }
}

// Validation error messages
private string _cedulaError;
public string CedulaError
{
    get => _cedulaError;
    set
    {
        _cedulaError = value;
        OnPropertyChanged();
    }
}

private string _nombreError;
public string NombreError
{
    get => _nombreError;
    set
    {
        _nombreError = value;
        OnPropertyChanged();
    }
}

private string _apellidoError;
public string ApellidoError
{
    get => _apellidoError;
    set
    {
        _apellidoError = value;
        OnPropertyChanged();
    }
}

private string _correoError;
public string CorreoError
{
    get => _correoError;
    set
    {
        _correoError = value;
        OnPropertyChanged();
    }
}

private string _telefonoError;
public string TelefonoError
{
    get => _telefonoError;
    set
    {
        _telefonoError = value;
        OnPropertyChanged();
    }
}

        // Visual feedback properties
        private bool _isSubmitting;
        public bool IsSubmitting
        {
            get => _isSubmitting;
            set
            {
                _isSubmitting = value;
                OnPropertyChanged();
            }
        }

        private string _successMessage;
        public string SuccessMessage
        {
            get => _successMessage;
            set
            {
                _successMessage = value;
                OnPropertyChanged();
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitCommand { get; }

        public MiembrosViewModel()
        {
            _apiService = new ApiService();
            Miembros = new ObservableCollection<MiembroDto>();
            SubmitCommand = new Command(async () => await SubmitVolunteerRequestAsync());
            LoadMiembrosAsync();
        }

        public async Task LoadMiembrosAsync()
        {
            IsLoading = true;
            var response = await _apiService.GetMiembrosAsync();
            if (response != null && response.Exito && response.Datos != null)
            {
                Miembros.Clear();
                foreach (var miembro in response.Datos)
                {
                    Miembros.Add(miembro);
                }
            }
            IsLoading = false;
        }

        private bool ValidateFields()
        {
            bool isValid = true;
            // Reset errors
            CedulaError = NombreError = ApellidoError = CorreoError = TelefonoError = "";
            ErrorMessage = SuccessMessage = "";

            if (string.IsNullOrWhiteSpace(Cedula))
            {
                CedulaError = "Cédula es requerida.";
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                NombreError = "Nombre es requerido.";
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(Apellido))
            {
                ApellidoError = "Apellido es requerido.";
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(Correo) || !Regex.IsMatch(Correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                CorreoError = "Correo inválido.";
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(Telefono))
            {
                TelefonoError = "Teléfono es requerido.";
                isValid = false;
            }
            return isValid;
        }

        public async Task SubmitVolunteerRequestAsync()
        {
            if (!ValidateFields())
            {
                return;
            }

            IsSubmitting = true;
            ErrorMessage = "";
            SuccessMessage = "";

            var newMember = new MiembroDto
            {
                Cedula = Cedula,
                Nombre = Nombre,
                Apellido = Apellido,
                Correo = Correo,
                Telefono = Telefono
            };

            var response = await _apiService.PostAsync<MiembroDto, MiembroResponseDto>("miembros.php", newMember);

            if (response != null && response.Exito)
            {
                SuccessMessage = "Solicitud enviada con éxito.";
                // Optionally clear form
                Cedula = Nombre = Apellido = Correo = Telefono = "";
                await LoadMiembrosAsync();
            }
            else
            {
                ErrorMessage = "Error al enviar la solicitud. Intente nuevamente.";
            }

            IsSubmitting = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
