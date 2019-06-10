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
            return myStr.S;
        }

        public MyString(string s)
        {
            this.S = s;
        }

        public static bool operator == (MyString s1 , string s2)
        {
            string s3 = (string)s1;
            return s3 == s2;
        }

        public static bool operator != (MyString s1, string s2)
        {
            return !(s1 == s2);
        }

        public static MyString operator ++ (MyString str)
        {
            string s = (string)str;
            string result = string.Empty;
            foreach(var a in s)
            {
                result += char.ToUpper(a);
            }
            return new MyString(result);
        }

        public static MyString operator --(MyString str)
        {
            string s = (string)str;
            string result = string.Empty;
            foreach (var a in s)
            {
                result += char.ToLower(a);
            }
            return new MyString(result);
        }
    }
}
