using Moq;
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
        public Calculator calculator { get; set; }
        public Mock<ICalculatorService> mymock { get; set; }
        public CalculatorTest()
        {
             mymock = new Mock<ICalculatorService>();

            this.calculator = new Calculator(mymock.Object);
        }
        [Fact]//Method herhangi bir parametre almıyorsa fact kullanılıyor
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

            //Assert.StartsWith("Bir", "Bir masal");//Beklenen değer asıl değerimiz şeklinde yazılıyor.
            //Assert.EndsWith("masal", "Bir masal");

            //dizinin boş olup olmadığını kontrol eder,boş olmasını bekler
            //Assert.Empty(new List<string>() { "Fatih"});
            //Assert.NotEmpty(new List<string>() { "Fatih"});//boş olmamasını bekler


            //Assert.InRange(10, 2, 20);//10 değeri 2 ile 20 arasında true dönmesini bekleriz.
            //Assert.NotInRange(10, 15, 20);//10 değeri 15 ile 20 dışında true dönmesini bekleriz.

            //Assert.Single(new List<string> { "Fatih" });//dizideki count 1 tane mi diye kontrol eder
            //Assert.Single<int>(new List<int> { 1,2,3,4});//dizideki count 1 tane mi diye kontrol eder

            //Assert.IsNotType<string>("umut");//type karşılaştırması yapar
            //Assert.IsType<string>("umut");//type karşılaştırması yapar

            //Assert.IsAssignableFrom<IEnumerable<string>>(new List<string>());   //kaıtılmış veya implemente edilmiş mi diye kontrol eder

            //string deger = null;
            //Assert.Null(deger);//değerin null olup olmadığını kontrol eder.
            //Assert.NotNull(deger);//false döner çünkü null olmaması gerekiyor.

            //Assert.Equal<int>(2, 2);//beklenen değer solda gerçek değer sağda eşit ise true
            //Assert.NotEqual<int>(3, 2);//beklenen değer solda gerçek değer sağda eşit değilse true

        }

        [Theory]
        [InlineData(2, 5, 7)]
        public void AddTest2(int a, int b, int expectedTotal)
        {
            mymock.Setup(x => x.add(a, b)).Returns(expectedTotal);

            var actualTotal = calculator.add(a, b);
            Assert.Equal(expectedTotal, actualTotal);
        }


        //örnek test isimlendirme
        [Theory]
        [InlineData(2, 5, 7)]
        public void Add_simpleValues_ReturnTotalValue(int a, int b, int expectedTotal)
        {

            mymock.Setup(x=>x.add(a,b)).Returns(expectedTotal);
            var actualTotal = calculator.add(a, b);
            Assert.Equal(expectedTotal, actualTotal);

            mymock.Verify(x => x.add(a, b), Times.Once);//methodun kaç kere çalışması gerektiğini belirler.
        }
    }
}
