using System.Collections.Generic;

namespace E2_C
{
    public class MyString
    {
        public string S;

        public MyString(string s)
        {
            this.S = s;
        }

        public static implicit operator MyString(string s)
        {
            return new MyString(s);
        }

        public static implicit operator string(MyString myStr)
        {
            return myStr.S;
        }

        public static bool operator ==(MyString s1, MyString s2) => s1.S == s2.S;//s1.S.Equals(s2.S);        

        public static bool operator !=(MyString s1, MyString s2) => !(s1 == s2);

        public static bool operator ==(MyString s1, string s2) => s1.S == s2;//s1.S.Equals(s2);

        public static bool operator !=(MyString s1, string s2) => !(s1 == s2);
        

        public static MyString operator ++(MyString str)
        {
            string s = (string)str;
            string result = string.Empty;
            foreach (var a in s)
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

        public override bool Equals(object obj)
        {
            //    var @string = obj as MyString;
            //    return @string != null &&
            //           S == @string.S;
            if (obj as string != null)
                return this == (string)obj;
            else return this == S;
        }

        public override int GetHashCode()
        {
            return S.GetHashCode();
        }

        public bool Equals(string str)
        {
            return this.S == str;
        }

        public bool Equals (MyString myStr)
        {
            return this.S == myStr.S;
        }
    }
}
