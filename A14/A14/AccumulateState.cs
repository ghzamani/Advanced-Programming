using System;
using static System.Console;

namespace A14
{
    public class AccumulateState : CalculatorState
    {
        public AccumulateState(Calculator calc) : base(calc) { }

        // #7 لطفا
        public override IState EnterEqual()
        {
            Calc.Evalute(); // انجام محاسبات
            Calc.UpdateDisplay(); // ریختن محسابات در
            //display

            return new ComputeState(this.Calc); 
        }

        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');
        public override IState EnterNonZeroDigit(char c)
        {
            // #8 لطفا!
            this.Calc.Display += c.ToString();
            return this;
        }

        // #9 لطفا!
        public override IState EnterOperator(char c)
        {
            Calc.Evalute();

            return new ComputeState(this.Calc);
        }
        
        public override IState EnterPoint()
        {
            // #10 لطفا!

            //با زدن نقطه وارد 
            //PointState
            //می شویم
            this.Calc.Display += ".";
            return new PointState(this.Calc);
        }
    }
}