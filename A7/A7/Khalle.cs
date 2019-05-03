namespace A7
{
    public class Khalle : ICitizen, ITeacher
    {
        public Khalle(string nationalId, string name, string imgUrl , Degree topDegree)
        {
            this.Name = name;
            this.NationalId = nationalId;
            this.TopDegree = topDegree;
            this.ImgUrl = imgUrl;
        }
        private string _name;
        private string _nationalId;
        private Degree _topDegree;
        private string _imgUrl;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
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

        public string Teach()
        {
            string str = string.Empty;
            str += nameof(Khalle) + " " + this.Name + " is teaching";
            return str;
        }
    }
}