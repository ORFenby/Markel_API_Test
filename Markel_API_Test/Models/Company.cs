using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Markel_API_Test.Data
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Address1 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Address2 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Address3 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string PostCode { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; }

        public bool Active { get; set; }

        public DateTime InsuranceEndDate { get; set; }   
    }
}
