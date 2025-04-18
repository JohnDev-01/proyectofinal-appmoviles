using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using proyectofinal_appmoviles.Models;
using proyectofinal_appmoviles.Services;

namespace proyectofinal_appmoviles.ViewModels
{
    public class QuieroSerVoluntarioViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;

        // Form fields
        private string _cedula;
        public string Cedula
        {
            get => _cedula;
            set { _cedula = value; OnPropertyChanged(); }
        }

        private string _nombre;
        public string Nombre
        {
            get => _nombre;
            set { _nombre = value; OnPropertyChanged(); }
        }

        private string _apellido;
        public string Apellido
        {
            get => _apellido;
            set { _apellido = value; OnPropertyChanged(); }
        }

        private string _correo;
        public string Correo
        {
            get => _correo;
            set { _correo = value; OnPropertyChanged(); }
        }

        private string _telefono;
        public string Telefono
        {
            get => _telefono;
            set { _telefono = value; OnPropertyChanged(); }
        }

        private string _contrasena;
        public string Contrasena
        {
            get => _contrasena;
            set { _contrasena = value; OnPropertyChanged(); }
        }

        // Validation error messages
        private string _cedulaError;
        public string CedulaError
        {
            get => _cedulaError;
            set { _cedulaError = value; OnPropertyChanged(); }
        }

        private string _nombreError;
        public string NombreError
        {
            get => _nombreError;
            set { _nombreError = value; OnPropertyChanged(); }
        }

        private string _apellidoError;
        public string ApellidoError
        {
            get => _apellidoError;
            set { _apellidoError = value; OnPropertyChanged(); }
        }

        private string _correoError;
        public string CorreoError
        {
            get => _correoError;
            set { _correoError = value; OnPropertyChanged(); }
        }

        private string _telefonoError;
        public string TelefonoError
        {
            get => _telefonoError;
            set { _telefonoError = value; OnPropertyChanged(); }
        }

        private string _contrasenaError;
        public string ContrasenaError
        {
            get => _contrasenaError;
            set { _contrasenaError = value; OnPropertyChanged(); }
        }

        // Visual feedback properties
        private bool _isSubmitting;
        public bool IsSubmitting
        {
            get => _isSubmitting;
            set { _isSubmitting = value; OnPropertyChanged(); }
        }

        private string _successMessage;
        public string SuccessMessage
        {
            get => _successMessage;
            set { _successMessage = value; OnPropertyChanged(); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public ICommand SubmitCommand { get; }

        public QuieroSerVoluntarioViewModel()
        {
            _apiService = new ApiService();
            SubmitCommand = new Command(async () => await SubmitVolunteerRequestAsync());
        }

        private bool ValidateFields()
        {
            bool isValid = true;
            CedulaError = NombreError = ApellidoError = CorreoError = TelefonoError = ContrasenaError = "";
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
            if (string.IsNullOrWhiteSpace(Contrasena) || Contrasena.Length < 6)
            {
                ContrasenaError = "Contraseña debe tener al menos 6 caracteres.";
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

            var volunteerData = new
            {
                cedula = Cedula,
                nombre = Nombre,
                apellido = Apellido,
                correo = Correo,
                telefono = Telefono,
                contrasena = Contrasena
            };

            var response = await _apiService.PostVoluntarioAsync<object>(volunteerData);

            if (response != null)
            {
                SuccessMessage = "Solicitud enviada con éxito.";
                Cedula = Nombre = Apellido = Correo = Telefono = Contrasena = "";
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
