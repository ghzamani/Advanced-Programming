namespace A7
{
    public class Professor : ICitizen , ITeacher
    {
        public Professor(string nationalId, string name, string imgUrl,
           Degree topDegree , int researchCount)
        {
            NationalId = nationalId;
            Name = name;
            ImgUrl = imgUrl;
            TopDegree = topDegree;
            ResearchCount = researchCount;
        }
        private string _name;
        private Degree _topDegree;
        private string _imgUrl;
        private string _nationalId;
        private int _researchCount;

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
        public int ResearchCount
        {
            get => _researchCount;
            set
            {
                _researchCount = value;
            }
        }

        public string Teach()
        {
            string str = string.Empty;
            str = str + nameof(Professor) + " " + this.Name + " is teaching";
            return str;
        }
   
    }
}