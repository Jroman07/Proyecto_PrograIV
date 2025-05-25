using Proyecto_Final_PrograIV.Entities;

namespace Proyecto_Final_PrograIV.Model.Auth.Service
{
    public interface ISvAuth
    {
        public AuthResponse Authenticate(Auth auth);
    }
}
