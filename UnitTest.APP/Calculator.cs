using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.APP
{
    public class Calculator
    {
        private readonly ICalculatorService calculatorService;

        public Calculator(ICalculatorService calculatorService)
        {
            this.calculatorService = calculatorService;
        }

        public int add(int a, int b)
        {
            return calculatorService.add(a, b);
        }
    }
}
