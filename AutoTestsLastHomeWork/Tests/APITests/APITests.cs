using System.Text;
using AutoTestsLastHomeWork.Models.APIModels.StudentsModels.StudentsRequestModels;
using AutoTestsLastHomeWork.Models.APIModels.StudentsModels.StudentsResponseModels;
using AutoTestsLastHomeWork.Pages;
using Newtonsoft.Json;

namespace AutoTestsLastHomeWork.Tests.APITests;

public class APITests : BaseAPITests
{
    [Test]
    public async Task TestApiMethods()
    {
        CreateStudentRequestModel createStudentRequestModel = new()
        {
            Name = "Вова",
            LastName = "Вовкин",
            Age = 20,
            FacultetID = 1
        };
        var postJson = JsonConvert.SerializeObject(createStudentRequestModel);
        var requestBody = new StringContent(postJson, encoding: Encoding.UTF8, "application/json");
        var postResponse = await DI.RestApiHelper.Post("http://109.172.115.139:5000/api/Students/CreateStudent", requestBody);
        var postResponseModel = JsonConvert.DeserializeObject<CreateStudentResponseModel>(postResponse);

        var getResponse = await DI.RestApiHelper.Get("http://109.172.115.139:5000/api/Students/GetStudents");

        var jsonObj = JsonConvert.DeserializeObject<List<GetStudentsResponseModel>>(getResponse);
    }

    [Test]
    public async Task CheckCreateStudentTest()
    {
        //1. Получить всех студентов
        //2. Создать студента
        //3. Получить всех студентов и сравниваем с 1, что кол-во увеличилось
        //4. Вызвать GET по созданному студенту
        //5. Удалить студента
        int countStudentsBefore = DI.APIHelper.GetStudents().Count;
        CreateStudentRequestModel expectedStudent = new()
        {
            Name = "Андрей",
            LastName = "Андронкин",
            Age = 20,
            FacultetID = 1
        };
        var student = DI.APIHelper.CreateStudent(expectedStudent);
        int countStudentsAfter = DI.APIHelper.GetStudents().Count;
        var studentGetById = DI.APIHelper.GetStudentById((int)student.Id);

        DI.AllureReportHelper.TryRunStep("Проверяем результаты теста", () =>
        {
            int resultCountStudent = countStudentsAfter - countStudentsBefore;
            if (resultCountStudent == 1)
                DI.AllureReportHelper.MessageInNewStep($"Кол-во студентов увеличилось");
            else
                DI.AllureReportHelper.ErrorMessageInNewStep("Кол-во студентов не увеличилось");
            CreateStudentRequestModel studentFromResponse = new()
            {
                Name = studentGetById.Name,
                LastName = studentGetById.LastName,
                Age = studentGetById.Age,
                FacultetID = expectedStudent.FacultetID
            };
            if (expectedStudent.Name == studentFromResponse.Name && expectedStudent.LastName == studentFromResponse.LastName
            && expectedStudent.Age == studentFromResponse.Age && expectedStudent.FacultetID == studentFromResponse.FacultetID)
                DI.AllureReportHelper.MessageInNewStep($"Полученный студент совпал с ожидаемым");
            else
                DI.AllureReportHelper.ErrorMessageInNewStep("Студенты не совпали");
        });
        DI.APIHelper.DeleteStudent((int)student.Id);
    }
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
            foreach (var student in listStudent.Students)
            {
                if (student.Id == studentAdd.Id)
                {
                    DI.AllureReportHelper.MessageInNewStep($"Студент с номером {student.Id} найден");
                    DI.AllureReportHelper.TryRunStep($"Сравниваем остальные атрибуты студента", () =>
                    {
                        if (student.Name.Equals(studentAdd.Name))
                            if (student.LastName.Equals(studentAdd.LastName))
                                if (student.Age.Equals(studentAdd.Age))
                                    DI.AllureReportHelper.MessageInNewStep($"Студент найден. Имя: {student.Name} | Фамилия: {student.LastName}| Возраст: {student.Age}");
                    });
                }
            }
        });
        DI.APIHelper.DeleteStudent((int)studentAdd.Id);
    }
}
