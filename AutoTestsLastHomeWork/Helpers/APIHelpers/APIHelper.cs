using System.Text;
using AutoTestsLastHomeWork.Models.APIModels.FacultetsModels;
using AutoTestsLastHomeWork.Models.APIModels.StudentsModels.StudentsRequestModels;
using AutoTestsLastHomeWork.Models.APIModels.StudentsModels.StudentsResponseModels;
using Newtonsoft.Json;

namespace AutoTestsLastHomeWork.Helpers.APIHelpers;

public class APIHelper
{
    private readonly string _apiURL = "http://109.172.115.139:5000/api/";
    public List<GetStudentsResponseModel> GetStudents()
    {
        List<GetStudentsResponseModel> jsonObj = new List<GetStudentsResponseModel>();
        DI.AllureReportHelper.RunStep("Получаем всех студентов", () =>
        {
            var result = DI.RestApiHelper.Get($"{_apiURL}Students/GetStudents").Result;
            jsonObj = JsonConvert.DeserializeObject<List<GetStudentsResponseModel>>(result)!;
        });
        return jsonObj;
    }
    public CreateStudentResponseModel CreateStudent(CreateStudentRequestModel student)
    {
        var postResponseModel = new CreateStudentResponseModel();
        DI.AllureReportHelper.RunStep($"Добавление студента {student.LastName} {student.Name}", () =>
        {
            var postJson = JsonConvert.SerializeObject(student);
            var requestBody = new StringContent(postJson, encoding: Encoding.UTF8, "application/json");
            var postResponse = DI.RestApiHelper.Post($"{_apiURL}Students/CreateStudent", requestBody).Result;
            postResponseModel = JsonConvert.DeserializeObject<CreateStudentResponseModel>(postResponse);

        });
        return postResponseModel;
    }

    public GetStudentsResponseModel GetStudentById(int id)
    {
        GetStudentsResponseModel getStudentResponseModel = new();
        DI.AllureReportHelper.RunStep($"Получение студента по ID {id}", () =>
        {
            var result = DI.RestApiHelper.Get($"{_apiURL}Students/GetStudent/{id}").Result;
            getStudentResponseModel = JsonConvert.DeserializeObject<GetStudentsResponseModel>(result)!;
        });
        return getStudentResponseModel;
    }

    public bool DeleteStudent(int id)
    {
        bool isDelete = false;
        DI.AllureReportHelper.RunStep($"Удаление студента {id}", () =>
        {
            isDelete = DI.RestApiHelper.Delete($"{_apiURL}Students/DeleteStudent/{id}").IsCompletedSuccessfully;
        });
        return isDelete;
    }
    public GetFacultetsResponseModel GetFacultetById(long id)
    {
        GetFacultetsResponseModel getFacultetsResponseModel = new();
        DI.AllureReportHelper.RunStep($"Получение списка студентов факультета", () =>
        {
            var result = DI.RestApiHelper.Get($"{_apiURL}Facultets/GetFacultet/{id}").Result;
            getFacultetsResponseModel = JsonConvert.DeserializeObject<GetFacultetsResponseModel>(result)!;
        });
        return getFacultetsResponseModel;
    }

}

