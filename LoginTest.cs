using BusinessComponent.Abstract;
using BusinessComponent.Implement;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using NUnitSample.Controllers;
using System.Linq;
using Moq;
using Ninject;

namespace UnitTestProject_core
{

    [TestClass]
    public class LoginTest
    {
        StandardKernel kernel = new StandardKernel();
        //this can be uni test startup method

        [TestInitialize]
        public void CreateKernel()        {

            kernel.Bind<ILogin>().To<LoginMock>();
            //other bindings here
        }

        [TestMethod]
        public void Login_Success()
        {

            ILogin login = new CustomLogin();
            var controller = new WeatherForecastController(login);// new Logger<TestMethod>);
            Assert.IsTrue(controller.Get().Count() > 0);
        }

        [TestMethod]
        public void Login_Suucess_Moq()
        {
            var login = new Mock<ILogin>();
            login.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(true);//says if any 2 string parameter is supplied, return true
            var controller = new WeatherForecastController(login.Object);// new Logger<TestMethod>);
            Assert.IsTrue(controller.Get().Count() > 0);

        }

        [TestMethod]
        public void LoginSuccess_Mock()
        {   
            var controller = new WeatherForecastController(kernel.Get<ILogin>());
            Assert.IsTrue(controller.Get().Count() > 0);
        }

    }


}
