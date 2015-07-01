using System.Web.Mvc;
using KDCLLC.Web.Controllers;
using KDCLLC.Web.Interfaces.Services;
using Moq;
using Xunit;

namespace KDCLLC.Web.Tests.Controllers
{
    public class HomeControllerTest
    {
        private HomeController _controller;
        private Mock<IMessageService> _messageService;
        private Mock<ILogService> _logService;


        public HomeControllerTest()
        {
           _messageService = new Mock<IMessageService>();
            _logService = new Mock<ILogService>();
            
            _controller = new HomeController(_messageService.Object, _logService.Object);
        }

        [Fact]
        public void VerifyContactView()
        {
          
            //ViewBag.Message contains "Message from"

            var result = _controller.Contact() as ViewResultBase;

            var messageResult = result.ViewData["Message"];

            string message = "Your contact page.";

            Assert.Equal(message, messageResult);
        }

        [Fact]
        public void VerifyAbouttView()
        {
            string message = "Test";

            Mock<IMessageService> messageService = new Mock<IMessageService>();
            messageService.Setup(x => x.GetMessage()).Returns(message);

            Mock<ILogService> logService = new Mock<ILogService>();

            var ctr = new HomeController(messageService.Object, logService.Object);

            //ViewBag.Message contains "Message from"

            var result = ctr.About() as ViewResultBase;

            var messageResult = result.ViewData["Message"];

           

            Assert.Equal(message, messageResult);
        }

        [Fact]
        public void AboutView_ShourReturnCorrectRouteDataWithValues()
        {

        }
    }
}
