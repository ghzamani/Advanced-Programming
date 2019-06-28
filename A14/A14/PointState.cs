namespace A14
{
    /// <summary>
    /// این وضعیت نشان دهنده حالتی است که نقطه زده شده
    /// این وضعیت شبیه وضعیت
    /// Accumulate
    /// است
    /// تنها فرقش این است که نقطه جدیدی نمی شود زد.
    /// تغییرات لازم را برای این کار بدهید.
    /// </summary>
    public class PointState : AccumulateState
    {
        public PointState(Calculator calc) : base(calc) { }

        //#1 لطفا!
        
        //اگر کاربر عدد وارد کرد باید وارد
        //AccumulateState
        //بشویم، چون این کلاس از کلاس 
        //AccumulateState
        //به ارث برده پس تمامی متدهای آن کلاس را دارد
        
        //اگر کاربر نقطه وارد کرد باید در همین 
        //state
        //بمانیم
        public override IState EnterPoint()
        {
            return this;
        }
             
    }
}