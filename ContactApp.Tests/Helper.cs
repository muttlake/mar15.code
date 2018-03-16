

namespace ContactApp.Tests
{
    public class Helper
    {
        [Fact]
        public void Test_ContactHelper_Add()
        {
            //arrange
            var ch = new ContactHelper<Person>();

            //act
            var actual = ch.Add(new Person());

            //assert
            Assert.True(actual);
        }

    }
}