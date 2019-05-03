namespace A7
{
    public class Dabir : ICitizen, ITeacher
    {
        public Dabir(string nationalId, string name, string imgUrl,
            Degree topDegree, int under100StudentCount)
        {
            NationalId = nationalId;
            Name = name;
            ImgUrl = imgUrl;
            TopDegree = topDegree;
            Under100StudentCount = under100StudentCount;
        }
        private string _name;
        private Degree _topDegree;
        private string _imgUrl;
        private string _nationalId;
        private int _under100StudentCount;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }
        public Degree TopDegree
        {
            get => _topDegree;
            set
            {
                _topDegree = value;
            }
        }
        public string ImgUrl
        {
            get => _imgUrl;
            set
            {
                _imgUrl = value;
            }
        }
        public string NationalId
        {
            get => _nationalId;
            set
            {
                _nationalId = value;
            }
        }
        public int Under100StudentCount
        {
            get => _under100StudentCount;
            set
            {
                _under100StudentCount = value;
            }
        }

        public string Teach()
        {
            string str = string.Empty;
            str = str +nameof(Dabir) + " " + this.Name + " is teaching";
            return str;
        }
    }
}