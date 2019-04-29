namespace E1B
{
    public interface IHasAge
    {
        int GetAge();
    }
    public class Human : IHasAge
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }

        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                _age = value;
            }
        }

        public Human(string name , int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int GetAge()
        {
            return Age;
        }
    }
}