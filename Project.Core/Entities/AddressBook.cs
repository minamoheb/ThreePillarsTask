using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Entities
{
    public partial class AddressBook 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string FullName { get; set; }
        public int? JobId { get; set; }
        public int? DepId { get; set; }
  
        public DateTime BirthDate { get; set; }
        public int? Age { get; set; }

        [Column(TypeName = "varchar(11)")]
        public string MobilePhone { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Passowrd { get; set; }
        public string Photo { get; set; }
     

        public virtual Department Department { get; set; }

        public virtual JobTittle JobTittle { get; set; }
    }
}
