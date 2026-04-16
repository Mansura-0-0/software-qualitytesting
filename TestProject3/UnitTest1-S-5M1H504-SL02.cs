using NUnit.Framework;
using Project;

namespace TestProject3
{
    //Refactor the code to decouple the DiscountService by injecting it as a dependency.
   // This must allow the service to be mocked using Moq during unit testing.

    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {


             
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }

}