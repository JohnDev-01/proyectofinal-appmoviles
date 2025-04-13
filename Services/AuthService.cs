namespace proyectofinal_appmoviles.Services
{
    public class AuthService
    {
        public bool UsuarioAutenticado { get; private set; }

        public AuthService()
        {
            // Initialize authentication status
            UsuarioAutenticado = false; // Default to not authenticated
        }

        public void Login()
        {
            // Logic for user login
            UsuarioAutenticado = true; // Set to true on successful login
        }

        public void Logout()
        {
            // Logic for user logout
            UsuarioAutenticado = false; // Set to false on logout
        }
    }
}
