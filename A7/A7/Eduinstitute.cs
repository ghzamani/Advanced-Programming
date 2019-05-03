using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace A7
{
    public class EduInstitute<TTeacher> where TTeacher : ITeacher, ICitizen
    {
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
            }
        }

        private Degree _minimumDegree;
        public Degree MinimumDegree
        {
            get => _minimumDegree;
            set
            {
                _minimumDegree = value;
            }
        }

        private List<ICitizen> _teachers;
        public List<ICitizen> Teachers  
        {
            get => _teachers;
            set
            {
                _teachers = value;
            }
        }
        
        public EduInstitute(string title, Degree minimumDegree)
        {
            this.Title = title;
            this.MinimumDegree = minimumDegree;
        }

        public bool Register(TTeacher teacher)
        {
            if (IsEligible(teacher))
            {
                Teachers.Add(teacher);
                return true;
            }
            else return false;
        }

        public bool IsEligible(TTeacher teacher)
        {
            return teacher.TopDegree >= MinimumDegree;
        }
    }
}