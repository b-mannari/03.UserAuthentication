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
    class CreateUserTests
    {
        CreateUser createUser; UserAccount userAccount;
        [OneTimeSetUp]
        public void Setup()
        {
            createUser = new CreateUser(); userAccount = new UserAccount
            { Username = "badari", Password = "Mannari1" };
            userAccount.AddUserInfo();
        }

        [Test]
        public void ShouldReturnSuccess_WhenValidUsernameWithOnlyCharectersArePassed()
        {
            var userName = "Badari";

            var result = createUser.ValidateUserName(userName);

            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldReturnFailure_WhenInValidUsernameWithNumberArePassed()
        {
            var userName = "Badari1";

            var result = createUser.ValidateUserName(userName);

            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnSuccess_WhenValidPasswordIsPassed()
        {
            var passsord = "Test12";

            var result = createUser.ValidatePassword(passsord);

            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldReturnFailure_WhenInValidPasswordIsPassed()
        {
            var passsord = "test";

            var result = createUser.ValidatePassword(passsord);

            Assert.IsFalse(result);
        }

        //[Test]
        //public void ShouldReturnSuccess_WhenValidUsernameIsPassed()
        //{
        //    string expectedResult = "User created Successfully";
        //    string username = "badari"; string password = "Mannari1";

        //    string actulaResult = createUser.AddNewUser(username, password);

        //    Assert.AreEqual(expectedResult, actulaResult);
        //}

        [Test]
        public void ShouldReturnFailure_WhenValidUsernameAndInvalidPasswordIsPassed()
        {
            string expectedResult = "User created Successfully";
            string username = "testuser"; string password = "password";

            string actulaResult = createUser.AddNewUser(username, password);

            Assert.AreNotEqual(expectedResult, actulaResult);
        }

        [Test]
        public void ShouldReturnFailure_WhenInValidUsernameAndInvalidPasswordIsPassed()
        {
            string expectedResult = "User created Successfully";
            string username = "testuser1"; string password = "password";

            string actulaResult = createUser.AddNewUser(username, password);

            Assert.AreNotEqual(expectedResult, actulaResult);
        }

        [Test]
        public void ShouldReturnSuccess_WhenInValidUsernameIsPassed()
        {
            string expectedResult = "Unable to create user";
            string username = "testuser2"; string password = "password";

            string actulaResult = createUser.AddNewUser(username, password);

            Assert.AreEqual(expectedResult, actulaResult);
        }

        [Test]
        public void ShouldReturnSuccess_WhenInValidUsernameIsPassed_Mock()
        {
            //string expectedResult = "Unable to create user";
            string username = "testuser2"; string password = "password";
            UserModel model = new UserModel { Username = username, Password = password };

            var mock = new Mock<IUserInterface>();
            mock.Setup(p => p.AddUser(model)).Returns(Task.Run(() => { return true; }));
            bool actulaResult = mock.Object.AddUser(model).Result;

            Assert.AreEqual(true, actulaResult);
        }

        [Test]
        public void ShouldReturnFailure_WhenValidUsernameAndInvalidPasswordIsPassed_Mock()
        {
            //string expectedResult = "User added successfully.";
            string username = "testuser2"; string password = "password";
            UserModel model = new UserModel { Username = username, Password = password };

            var mock = new Mock<IUserInterface>();
            mock.Setup(p => p.AddUser(model)).Returns(Task.Run(() => { return true; }));
            bool actulaResult = mock.Object.AddUser(model).Result;

            Assert.AreEqual(true, actulaResult);
        }

        [Test]
        public void ShouldReturnFailure_WhenValidUsernameAndInvalidPasswordIsPassed_Mock_Never()
        {
            //string expectedResult = "User added successfully.";
            string username = "testuser2"; string password = "password";
            UserModel model = new UserModel { Username = username, Password = password };

            var mock = new Mock<IUserInterface>();
            mock.Setup(p => p.AddUser(model)).Returns(Task.Run(() => { return true; }));
            mock.Verify(p => p.AddUser(model), Times.Never());

            bool actulaResult = mock.Object.AddUser(model).Result;
            Assert.AreEqual(true, actulaResult);
        }

        [Test]
        public void ShouldReturnSuccess_WhenValidUsernameAndValidPasswordIsPassed_Mock_Once()
        {
            //string expectedResult = "User added successfully.";
            string username = "testuser"; string password = "Testuser1";
            UserModel model = new UserModel { Username = username, Password = password };

            var mock = new Mock<IUserInterface>(); 
            mock.Setup(p => p.AddUser(model)).Returns(Task.Run(() => { return true; }));
            bool actulaResult = mock.Object.AddUser(model).Result;
            mock.Verify(p => p.AddUser(model), Times.Once());
           
            Assert.AreEqual(true, actulaResult);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            createUser = null; userAccount = null;
        }
    }
}
