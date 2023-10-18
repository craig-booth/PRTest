
using PRTest;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            var calc = new Calculator();

            var result = calc.Add(1, 2);

            Assert.Equal(3, result);
        }

    /*    [Fact]
        public void FailingTest()
        {
            var calc = new Calculator();

            var result = calc.Add(5, 5);

            Assert.Equal(11, result);
        } */
    }
}