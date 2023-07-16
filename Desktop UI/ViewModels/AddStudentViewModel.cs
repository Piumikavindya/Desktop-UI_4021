using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_UI.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Desktop_UI.ViewModels
{
    public partial class AddStudentViewModel : ObservableObject

    {

        [ObservableProperty]
        public string firstName;

        [ObservableProperty]
        public string lastName;

        [ObservableProperty]
        public DateTime dateOfBirth;

        [ObservableProperty]
        public double gPA;

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public BitmapImage selectedImage;

        internal ObservableCollection<Student> Students;
        internal string Status;



        public AddStudentViewModel(Student v)
        {
            Student = v;
            firstName = Student.FirstName;
            lastName = Student.LastName;
            gPA = Student.GPA;
            dateOfBirth = Student.DateOfBirth;
            selectedImage = Student.Image;


        }


        public AddStudentViewModel()
        {
        }

        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;

            if (dialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(dialog.FileName));
                MessageBox.Show("Image successfully uploaded!", "Successful");
            }
        }

        public Student Student { get; private set; }
        public Action CloseAction { get; internal set; }




        [RelayCommand]
        public void Save()
        {
            if (gPA < 0 || gPA > 4)
            {
                MessageBox.Show("GPA value must be between 0 and 4.", "Error");
                return;
            }

            if (Student == null)
            {
                Student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth,
                    Image = selectedImage,
                    GPA = gPA
                };
            }
            else
            {
                Student.FirstName = firstName;
                Student.LastName = lastName;
                Student.GPA = gPA;
                Student.Image = selectedImage;
                Student.DateOfBirth = dateOfBirth;
            }

            if (Student.FirstName != null)
            {
                CloseAction();
            }

            Application.Current.MainWindow.Show();
        }


        private void Save1()
        {
        }

    
    }

}
