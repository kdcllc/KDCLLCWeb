using KDCLLC.Web.Interfaces.Services;

namespace KDCLLC.Web.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Message from :" + this.GetType();
        }
    }
}
