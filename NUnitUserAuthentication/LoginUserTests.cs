using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using UserAuthentication;
using UserAuthentication.ClassObjects;
using UserAuthenticationService;
using UserAuthenticationService.ClassObjects;

namespace NUnitUserAuthentication
{
    [TestFixture]
    class LoginUserTests
    {
        LoginUser loginUser; UserAccount userAccount;
        [OneTimeSetUp]
        public void Setup()
        {
            loginUser = new LoginUser(); 
            userAccount = new UserAccount { Username = "badari", Password = "Mannari1" };
            userAccount.AddUserInfo();
        }

        //[Test]
        //public void ShouldReturnSuccess_WhenValidUsernameAndValidPasswordArePassed()
        //{
        //    string expectedResult = "Login Success";

        //    string actulaResult = loginUser.Login(userAccount.Username, userAccount.Password, userAccount);

        //    Assert.AreEqual(expectedResult, actulaResult);
        //}

        //[Test]
        //public void ShouldReturnSuccess_WhenInValidUsernameAndValidPasswordArePassed()
        //{
        //    string expectedResult = "Login failure";
        //    string username = "testuser2"; string password = "testpass1";

        //    string actulaResult = loginUser.Login(username, password, userAccount);

        //    Assert.AreEqual(expectedResult, actulaResult);
        //}

        [Test]
        public void ShouldReturnFailure_WhenInValidUsernameAndInValidPasswordArePassed()
        {
            string expectedResult = "Login Success";
            string username = "testuser2"; string password = "password";

            string actulaResult = loginUser.Login(username, password);

            Assert.AreNotEqual(expectedResult, actulaResult);
        }

        [Test]
        public void ShouldReturnFailure_WhenValidUsernameAndInValidPasswordArePassed()
        {

            string expectedResult = "Login Success";
            string username = "username"; string password = "testpass1";

            string actulaResult = loginUser.Login(username, password);

            Assert.AreNotEqual(expectedResult, actulaResult);
        }

        [Test]
        public void ShouldReturnSuccess_WhenValidUsernameAndValidPasswordArePassed_Mock()
        {
            //string expectedResult = "Login Success";
            string username = "badari"; string password = "badari12";

            UserModel model = new UserModel { Username = username, Password = password };

            var mock = new Mock<IUserInterface>();
            mock.Setup(p => p.Login(model)).Returns(Task.Run(() => { return true; }));
            bool actulaResult = mock.Object.Login(model).Result;

            Assert.AreEqual(true, actulaResult);
        }

        [Test]
        public void ShouldReturnFailure_WhenInValidUsernameAndValidPasswordArePassed_Mock()
        {
            //string expectedResult = "Login failure";
            string username = "testuser2"; string password = "password";

            UserModel model = new UserModel { Username = username, Password = password };

            var mock = new Mock<IUserInterface>();
            mock.Setup(p => p.Login(model)).Returns(Task.Run(() => { return false; }));
            bool actulaResult = mock.Object.Login(model).Result;

            Assert.AreEqual(false, actulaResult);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            loginUser = null; userAccount = null;
        }
    }
}
