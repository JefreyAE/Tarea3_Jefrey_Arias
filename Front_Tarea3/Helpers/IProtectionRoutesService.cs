using Microsoft.AspNetCore.Mvc;

namespace Front_Tarea3.Helpers
{
    public interface IProtectionRoutesService
    {
        public bool ProtectAction();
    }
}
