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
            //int a = 5;
            //int b = 20;
            //var calcultor = new Calculator();

            //Act
            //Oluşturulan nesnelerin parametrelerini verildiği evredir.
            //var total = calcultor.add(a, b);

            ////Assert
            ////Verimizi çalışıp çalışmadığını test ettiğimiz yerdir

            //Assert.Equal<int>(25, total);
            //var names=new List<string>() { "Fatih","Umut","Emre"};
            //Assert.Contains(names, x => x == "Fatih");//liste içinde fatih olan var mı diye bakar.
            //Assert.Contains("fatih", "fatih çakıroğlu");//içerisinde beklenen değeri arar. true döner çünkü asıl değerimizde fatih ismi vardır.
            //Assert.DoesNotContain("emre", "fatih çakıroğlu");//içerisinde beklenen değeri içermemesini arar. true döner çünkü asıl değerimizde emre ismi yoktur.

            //Assert.True(5 > 2);//şarta göre başarılır olur 
            //Assert.False(5 < 2);//şarta göre başarılır olur 
            //Assert.True("".GetType() == typeof(string));//şarta göre başarılır olur 

            ////regex parametreleri alır.
            //var regex = "^dog";
            //Assert.Matches(regex, "dog Umut");
            //Assert.DoesNotMatch(regex, "umut Dog");
        }
    }
}
