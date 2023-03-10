using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Entities
{
    public partial class JobTittle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string JobName { get; set; }

        public virtual ICollection<AddressBook> AddressBook { get; set; }
    }
}
