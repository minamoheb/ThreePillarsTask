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

        [StringLength(250, ErrorMessage = "Must be between 5 and 250 characters", MinimumLength = 5)]
        [JsonProperty("name")] 
        public string FullName { get; set; }

        [JsonProperty("jobId")] 
        public int? JobId { get; set; }
        [JsonProperty("jobName")]
        public string JobName { get; set; }
        [JsonProperty("depId")]
        public int? DepId { get; set; }
        [JsonProperty("depName")]
        public string DepartmentName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        [JsonProperty("birthDate")] 
        public DateTime BirthDate { get; set; }

        [Range(1, 120, ErrorMessage = "Age must be between 1-120 in years.")]
        [JsonProperty("age")] 
        public int? Age { get; set; }

        [Required(ErrorMessage = "Mobile Phone is Required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})[-. ]?([0-9]{4})[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Not a valid Phone number")]
        [JsonProperty("phone")]
        public string MobilePhone { get; set; }

        [StringLength(250, ErrorMessage = "Must be between 5 and 250 characters", MinimumLength = 5)]
        [JsonProperty("address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [StringLength(250, ErrorMessage = "Must be between 5 and 250 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [JsonProperty("pass")]
        public string Passowrd { get; set; }

        [JsonProperty("img")]
        public string Photo { get; set; }

    }
}
