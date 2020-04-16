using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject 
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStats();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStats();
    }


    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {            
            grades = new List<double>();
            Name = name;
        }
         
        public override void AddGrade(double grade)
        {            
            if(grade <= 100 && grade >= 0)
            {                
                grades.Add(grade);  
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
               throw new ArgumentException($"Invalid {nameof(grade)}");
            }            
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStats()
        {
            var result = new Statistics();
            
            for(var index = 0; index < grades.Count; index += 1)
            {
                result.Add(grades[index]);                            
            }
                
            return result;
        }

        private List<double> grades;
        
        public const string CATEGORY = "Science";
    }
}