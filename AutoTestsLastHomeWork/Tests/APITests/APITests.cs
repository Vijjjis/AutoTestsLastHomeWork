using System.Text;
using AutoTestsLastHomeWork.Models.APIModels.StudentsModels.StudentsRequestModels;
using AutoTestsLastHomeWork.Models.APIModels.StudentsModels.StudentsResponseModels;
using AutoTestsLastHomeWork.Pages;
using Newtonsoft.Json;

namespace AutoTestsLastHomeWork.Tests.APITests;

public class APITests : BaseAPITests
{
    [Test]
    public void CheckCreateStudentOnFacultet()
    {
        CreateStudentRequestModel expectedStudent = new()
        {
            Name = "Владислав 3",
            LastName = "Последнезаданьев",
            Age = 20,
            FacultetID = 1010
        };
        var studentAdd = DI.APIHelper.CreateStudent(expectedStudent);
        var idFacultet = studentAdd.Facultet.Id;
        var listStudent = DI.APIHelper.GetFacultetById(idFacultet);
        DI.AllureReportHelper.RunStep($"Ищем созданного абонента в факультете \"{studentAdd.Facultet.Name}\" c номером {idFacultet}", () =>
        {
            Console.WriteLine($"Ищем созданного абонента в факультете \"{studentAdd.Facultet.Name}\" c номером {idFacultet}");
            foreach (var student in listStudent.Students)
            {
                if (student.Id == studentAdd.Id)
                {
                    DI.AllureReportHelper.MessageInNewStep($"Студент с номером {student.Id} найден");
                    Console.WriteLine($"Студент с номером {student.Id} найден");
                    DI.AllureReportHelper.RunStep($"Сравниваем остальные атрибуты студента", () =>
                    {
                        Console.WriteLine($"Сравниваем остальные атрибуты студента");
                        if (student.Name==studentAdd.Name &&
                            student.LastName==studentAdd.LastName &&
                            student.Age==studentAdd.Age)
                        {
                            Console.WriteLine($"Студент найден. Имя: {student.Name} | Фамилия: {student.LastName}| Возраст: {student.Age}");
                            DI.AllureReportHelper.MessageInNewStep($"Студент найден. Имя: {student.Name} | Фамилия: {student.LastName}| Возраст: {student.Age}");
                        }

                    });
                }
            }
        });
        DI.APIHelper.DeleteStudent((int)studentAdd.Id);
    }
}
