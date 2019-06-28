using System;

namespace A14
{
    /// <summary>
    /// این کلاس بطور کامل پیاده سازی شده است و نیاز به تغییر ندارد.
    /// تنها تغییرات لازم کامنت های شماست 
    /// </summary>
    public class StartState : CalculatorState
    {
        public StartState(Calculator calc) : base(calc) { }

        public override IState EnterEqual() => 
            ProcessOperator(new ComputeState(this.Calc));
        //اگر کاربر در ابتدا = را وارد کند چون 
        //ProcessOperator
        // به اکسپشن نمیخورد با پیغامی مواجه نمی شود و وارد        
        //ComputeState
        //می شود


        public override IState EnterZeroDigit()
        {
            //تا زمانی که کاربر صفر وارد میکند باید در همین 
            //state
            //باقی بماند
            this.Calc.Display = "0";
            return this;
        }

        public override IState EnterNonZeroDigit(char c)
        {
            //به محض وارد کردن عددی غیر 0 
            //state
            //تغییر میکند
            this.Calc.Display = c.ToString();
            return new AccumulateState(this.Calc);
        }

        public override IState EnterOperator(char c) => 
            ProcessOperator(new ComputeState(this.Calc), c);

        public override IState EnterPoint()
        {
            this.Calc.Display = "0.";
            return new PointState(this.Calc);
        }
    }
}