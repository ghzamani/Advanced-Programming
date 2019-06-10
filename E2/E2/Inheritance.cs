namespace E2
{
    public abstract class Person
    {
        private string _name;
        private bool _female;

        public bool IsFemale { get => _female; }
        public abstract int LunchRate { get; }
        
        public virtual string Name
        {
            get => $"{_name}";
        }

        public Person(string name, bool isFemale)
        {
            _female = isFemale;
            if (_female)
                _name += "خانم ";
            else
                _name += "آقای ";

            _name += name;            
        }
    }

    public class Student : Person
    {
        public Student(string name, bool isFemale) : base(name, isFemale)
        {
        }

        public override int LunchRate => 2000;
    }

    public class Employee : Person
    {
        public Employee(string name, bool isFemale) : base(name, isFemale)
        {
        }

        public override int LunchRate => 5000;

        public virtual int CalculateSalary(int hour) => hour * 5000;
    }

    public class Teacher : Employee
    {
        private string _name;
        private bool _female;
        public bool IsFemale { get => _female; }

        //public virtual string Name
        //{
        //    get => $"{_name}";
        //}

        public Teacher(string name, bool isFemale) :base(name,isFemale)
        {
        //    string[] n = name.Split();
        //    n[0] = "استاد";
        //    _name = string.Join(" ", n);
            _name = "استاد " + name;            
        }

        public override int LunchRate => 10000;

        public override int CalculateSalary(int hour) => hour * 20000;
    }
}