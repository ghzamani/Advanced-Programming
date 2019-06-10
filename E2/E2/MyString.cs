namespace E2
{
    public class MyString
    {
        public string S;
        public static implicit operator MyString(string s)
        {
            return s;
        }

        public static implicit operator string(MyString myStr)
        {
            return myStr;
        }

        public MyString(string s)
        {
            this.S = s;
        }
        public static bool operator == (MyString s1 , string s2)
        {
            MyString s3 = (MyString)s2;
            return s3 == s1;
        }

        public static bool operator != (MyString s1, string s2)
        {
            return !(s1 == s2);
        }
    }
}
