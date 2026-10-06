using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wt_lab3_3mvc_liger.Models;

namespace wt_lab3_3mvc_liger.Views;

public class StudentView
{
    public void ShowStudents(List<Student> students)
    {
        Console.WriteLine("СПИСОК СТУДЕНТОВ");
        if (students.Count == 0)
        {
            Console.WriteLine("Список пуст.");
            return;
        }

        foreach (var student in students)
        {
            Console.WriteLine(
                $"{student.Id}. " +
                $"{student.FullName} | " +
                $"{student.Faculty} | " +
                $"{student.Course} курс | " +
                $"Средний балл: {student.AverageGrade} | " +
                $"Зачислен: {student.IsEnrolled}"
            );
        }
    }

    public void ShowStudent(Student student)
    {
        Console.WriteLine("СТУДЕНТ");
        Console.WriteLine($"ID: {student.Id}");
        Console.WriteLine($"ФИО: {student.FullName}");
        Console.WriteLine($"Специальность: {student.Faculty}");
        Console.WriteLine($"Курс: {student.Course}");
        Console.WriteLine($"Средний балл: {student.AverageGrade}");
        Console.WriteLine($"Зачислен: {student.IsEnrolled}");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}
