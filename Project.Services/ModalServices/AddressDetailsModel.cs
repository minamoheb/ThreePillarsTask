using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Services.ModalServices
{
    public class DepartmentDataModel
    {
        [JsonProperty("id")] public int? Id { get; set; }
        [JsonProperty("departmentName")] public string DepartmentName { get; set; }
    }
    public class JobTittleModel
    {
        [JsonProperty("id")] public int? Id { get; set; }
        [JsonProperty("jobName")] public string JobName { get; set; }

    }

    public class AddressBookModel
    {
        [JsonProperty("id")] public int? Id { get; set; }

        [Required(ErrorMessage = "FullName is Required")]
        [StringLength(250, ErrorMessage = "Must be between 3 and 250 characters", MinimumLength = 3)]
        [JsonProperty("name")] 
        public string FullName { get; set; }

        [Required(ErrorMessage = "JobTittle is Required")]
        [JsonProperty("jobId")] 
        public int? JobId { get; set; }
        [JsonProperty("jobName")]
        public string JobName { get; set; }
        [JsonProperty("depId")]

        [Required(ErrorMessage = "Department is Required")]
        public int? DepId { get; set; }
        [JsonProperty("depName")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "BirthDate is Required")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        [JsonProperty("birthDate")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime BirthDate { get; set; }

        [Range(1, 120, ErrorMessage = "Age must be between 1-120 in years.")]
        [JsonProperty("age")] 
        public int? Age { get; set; }

        [DataType(DataType.PhoneNumber)]

        [JsonProperty("phone")]
        public string MobilePhone { get; set; }

        [StringLength(250, ErrorMessage = "Must be between 1 and 250 characters", MinimumLength = 1)]
        [JsonProperty("address")]
        public string Address { get; set; }


        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [StringLength(250, ErrorMessage = "Must be between 1 and 250 characters", MinimumLength = 1)]
        [DataType(DataType.Password)]
        [JsonProperty("pass")]
        public string Passowrd { get; set; }

        [JsonProperty("img")]
        public string Photo { get; set; }

    }
}
