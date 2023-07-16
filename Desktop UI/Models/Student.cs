using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Desktop_UI.Models
{
    public class Student
    {


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BitmapImage Image { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double GPA { get; set; }

        public string ImageUrl
        {
            get { return $"/Images/{Image}"; }
        }

        public Student(string firstname, string lastname, BitmapImage image, DateTime dateOfBirth, double gpa)
        {
            FirstName = firstname;
            LastName = lastname;
            Image = image;
            DateOfBirth = dateOfBirth;
            GPA = gpa;
        }

        public Student()
        {
        }

        internal static void Remove(Student selectedStudent)
        {
            throw new NotImplementedException();
        }
    }
}
