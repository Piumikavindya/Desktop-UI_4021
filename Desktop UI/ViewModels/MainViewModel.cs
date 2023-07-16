using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows;
using Desktop_UI.Views;

namespace Desktop_UI.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<Student> Students { get; } = new ObservableCollection<Student>();

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set { SetProperty(ref _selectedStudent, value); }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }
        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand RefreshCommand { get; }

        public MainViewModel()
        {
            // Add some initial data for testing purposes
            Students.Add(new Student
            {
                FirstName = "Piumi",
                LastName = "Nisansala",
                Image = new BitmapImage(new Uri("Images/7.png", UriKind.Relative)),
                DateOfBirth = new DateTime(1998, 10, 15),
                GPA = 3.5
            });
            Students.Add(new Student
            {
                FirstName = "Nisal",
                LastName = "Kavinda",
                Image = new BitmapImage(new Uri("Images/2.png", UriKind.Relative)),
                DateOfBirth = new DateTime(1999, 2, 2),
                GPA = 4.0
            });
            Students.Add(new Student
            {
                FirstName = "Dayani",
                LastName = "Samanthika",
                Image = new BitmapImage(new Uri("Images/4.png", UriKind.Relative)),
                DateOfBirth = new DateTime(2000, 12, 25),
                GPA = 4.0
            });

            AddCommand = new RelayCommand(AddStudent);
            EditCommand = new RelayCommand(ExecuteEditStudentCommand);
            DeleteCommand = new RelayCommand(DeleteStudent);
            RefreshCommand = new RelayCommand(Refresh);
        }

        public void AddStudent()
        {
            var vm = new AddStudentViewModel();
            vm.title = "ADD STUDENT";
            AddStudentView window = new AddStudentView(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                Students.Add(vm.Student);
            }
            else
            {
                MessageBox.Show("Please Enter valid details ", "Warning!");
            }
        }

        private void ExecuteEditStudentCommand()
        {
            if (SelectedStudent != null)
            {
                var vm = new AddStudentViewModel(SelectedStudent);
                vm.title = "EDIT STUDENT";
                var window = new AddStudentView(vm);

                window.ShowDialog();


                int index = Students.IndexOf(SelectedStudent);
                Students.RemoveAt(index);
                Students.Insert(index, vm.Student);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }


        private void DeleteStudent()
        {
            if (SelectedStudent != null)
            {
                Students.Remove(SelectedStudent);
                SelectedStudent = null;
                MessageBox.Show($"Student is Deleted successfuly.", "DELETED \a ");
            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");


            }
        }

        private void Refresh()
        {
            Status = $"Last Refreshed: {DateTime.Now}";
        }
    }
}
