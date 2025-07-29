using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AutoTestsLastHomeWork.Models.APIModels.StudentsModels.StudentsResponseModels;

public class GetStudentsResponseModel
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("lastName")]
    public string LastName { get; set; } = string.Empty;

    [JsonProperty("age")]
    public int Age { get; set; }

    [JsonProperty("facultetName")]
    public string FacultetName { get; set; } = string.Empty;
}
