using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.APP;

namespace UnitTest.xUnit
{
    public class CalculatorTest
    {
        [Fact]
        public void AddTest()
        {
            //Arrange
            // bir nesne örneği oluşturma kısmı arrange evresinde yapılır
            int a = 5;
            int b = 20;
            var calcultor = new Calculator();

            //Act
            //Oluşturulan nesnelerin parametrelerini verildiği evredir.
            var total = calcultor.add(a, b);

            //Assert
            //Verimizi çalışıp çalışmadığını test ettiğimiz yerdir

            Assert.Equal<int>(25, total);

        }
    }
}
