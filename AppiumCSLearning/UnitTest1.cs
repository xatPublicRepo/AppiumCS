
namespace AppiumCSLearning
{

    public class Tests
    {
        
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            TestContext.Progress.WriteLine("One Time Setup...");
        }

        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Setup...");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("Test1.");
        }
        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("Test 2.");
        }

        [TearDown]
        public void Teardown()
        {
            TestContext.Progress.WriteLine("Tear down...");
        }
        [OneTimeTearDown]
        public void OnetimeTearDown()
        {
            TestContext.Progress.WriteLine("One Time Tear Down...");
        }

    }
}
