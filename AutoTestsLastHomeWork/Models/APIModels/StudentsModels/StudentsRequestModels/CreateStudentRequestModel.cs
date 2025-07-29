using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestsLastHomeWork.Models.APIModels.StudentsModels.StudentsRequestModels;

public class CreateStudentRequestModel
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public int FacultetID { get; set; }

}

