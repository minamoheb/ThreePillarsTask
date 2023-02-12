using Project.Services.ModalServices;

namespace Project.Services.Helper.ErrorHandler
{
    public interface ILogErrorHandler
    {
        SaveStatusModel SysError(LogErrorModel model);
    }
}
