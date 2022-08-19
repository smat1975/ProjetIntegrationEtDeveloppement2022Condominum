using Microsoft.Extensions.Logging;

namespace CondominiumManagement.Services
{
    public interface IMailService
    {
        void EnvoyerEmail(string destinataire, string titreEmail, string corpsEmail);
    }
}