using NUnit.Framework;
using APITesting.Assembly;

namespace APITesting
{
    [TestFixture]
    public class Tests
    {
        protected Resources resources;

        [OneTimeSetUp]
        public void Setup()
        {
            resources = new Resources();
        }

        [Test]
        public void ValidateGetAccount()
        {
            resources.userResource.SendRequestAndValidateResponse();
        }

        [Test]
        public void ValidateGetAccountNegativeScenario()
        {
            resources.userResource.SendNegativeRequestAndValidateResponse();
        }



        [OneTimeTearDown]
        public void Test1()
        {
           
        }
    }
}