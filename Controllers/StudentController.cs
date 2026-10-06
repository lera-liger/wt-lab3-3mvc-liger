using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wt_lab3_3mvc_liger.Models;
using wt_lab3_3mvc_liger.Views;

namespace wt_lab3_3mvc_liger.Controllers
{
    public class StudentController
    {
        private readonly List<Student> students;
        private readonly StudentView view;

        public StudentController()
        {
            students = new List<Student>
        {
            new Student
            {
                Id = 1,
                FullName = "Лигер Валерия Валерьевна",
                Faculty = "УИР",
                Course = 4,
                AverageGrade = 9.7,
                IsEnrolled = true
            },
            new Student
            {
                Id = 2,
                FullName = "Ясковец Александра Дмитриевна",
                Faculty = "УИР",
                Course = 4,
                AverageGrade = 10,
                IsEnrolled = true
            },
            new Student
            {
                Id = 3,
                FullName = "Иванов Иван Иванович",
                Faculty = "УИР",
                Course = 1,
                AverageGrade = 3.0,
                IsEnrolled = false
            }
        };

            view = new StudentView();
        }

        public void Index()
        {
            view.ShowStudents(students);
        }

        public void Show(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                view.ShowMessage("Студент не найден.");
                return;
            }

            view.ShowStudent(student);
        }

        public void Add(Student student)
        {
            students.Add(student);
            view.ShowMessage("Студент успешно добавлен.");
        }

        public void Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                view.ShowMessage("Студент не найден.");
                return;
            }

            students.Remove(student);
            view.ShowMessage("Студент успешно удалён.");
        }

        public void FilterByFaculty(string faculty)
        {
            var result = students
        .Where(s => s.Faculty.Contains(faculty, StringComparison.OrdinalIgnoreCase))
        .ToList();

            if (result.Count == 0)
            {
                view.ShowMessage("Студенты не найдены.");
                return;
            }

            view.ShowStudents(result);
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("МЕНЮ");
                Console.WriteLine("1. Показать студентов");
                Console.WriteLine("2. Найти студента по ID");
                Console.WriteLine("3. Добавить студента");
                Console.WriteLine("4. Удалить студента");
                Console.WriteLine("5. Фильтр по специальности");
                Console.WriteLine("6. Сортировка по среднему баллу");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                var command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        Index();
                        break;
                    case "2":
                        ShowStudentByUserInput();
                        break;
                    case "3":
                        AddStudentByUserInput();
                        break;
                    case "4":
                        DeleteStudentByUserInput();
                        break;
                    case "5":
                        FilterByUserInput();
                        break;
                    case "6":
                        SortByAverageGrade();  
                        break;
                    case "0":
                        return;
                    default:
                        view.ShowMessage("Неизвестная команда.");
                        break;
                }
            }
        }

        private void ShowStudentByUserInput()
        {
            Console.Write("Введите ID студента: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                view.ShowMessage("Некорректный ID.");
                return;
            }

            Show(id);
        }

        private void AddStudentByUserInput()
        {
            Console.Write("Введите ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                view.ShowMessage("Некорректный ID.");
                return;
            }

            Console.Write("Введите ФИО: ");
            string fullName = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(fullName))
            {
                view.ShowMessage("ФИО не может быть пустым.");
                return;
            }

            Console.Write("Введите специальность: ");
            string faculty = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(faculty))
            {
                view.ShowMessage("Специальность не может быть пустым.");
                return;
            }

            Console.Write("Введите курс (1-4): ");
            if (!int.TryParse(Console.ReadLine(), out int course) || course < 1 || course > 4)
            {
                view.ShowMessage("Некорректный курс. Допустимо от 1 до 4.");
                return;
            }

            Console.Write("Введите средний балл: ");
            if (!double.TryParse(Console.ReadLine(), out double averageGrade)
                || averageGrade < 0 || averageGrade > 10)
            {
                view.ShowMessage("Некорректный средний балл. Допустимо от 0 до 10.");
                return;
            }

            Console.Write("Зачислен? (y/n): ");
            string enrolledInput = (Console.ReadLine() ?? "").Trim().ToLower();
            bool isEnrolled = enrolledInput == "y" || enrolledInput == "yes" || enrolledInput == "д";

            var student = new Student
            {
                Id = id,
                FullName = fullName,
                Faculty = faculty,
                Course = course,
                AverageGrade = averageGrade,
                IsEnrolled = isEnrolled
            };

            Add(student);
        }

        private void DeleteStudentByUserInput()
        {
            Console.Write("Введите ID студента для удаления: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                view.ShowMessage("Некорректный ID.");
                return;
            }

            Delete(id);
        }

        private void FilterByUserInput()
        {
            Console.Write("Введите название специальность: ");
            string faculty = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(faculty))
            {
                view.ShowMessage("Название специальности не может быть пустым.");
                return;
            }

            FilterByFaculty(faculty);
        }

        public void SortByAverageGrade()
        {
            var sorted = students
                .OrderByDescending(s => s.AverageGrade)
                .ToList();

            if (sorted.Count == 0)
            {
                view.ShowMessage("Список студентов пуст.");
                return;
            }

            view.ShowMessage("СТУДЕНТЫ, ОТСОРТИРОВАННЫЕ ПО СРЕДНЕМУ БАЛЛУ (по убыванию)");
            view.ShowStudents(sorted);
        }

    }
}
