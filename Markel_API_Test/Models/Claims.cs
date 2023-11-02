using Markel_API_Test.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Markel_API_Test.Models
{
    public class Claims
    {
        [Column(TypeName = "nvarchar(20)")]
        public string UCR { get; set; }
        public int CompanyId { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime LossDate { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string AssuredName { get; set; }
        [Column(TypeName = "decimal(15,2)")]
        public decimal IncurredLoss { get; set;}
        public bool Closed { get; set;}

        //public Claims(string ucr, int companyId, DateTime claimDate, DateTime lossDate, string assuredName, decimal incurredLoss, bool closes)
        //{
        //    UCR = ucr;
        //    CompanyId = companyId;
        //    ClaimDate = claimDate;
        //    LossDate = lossDate;
        //    AssuredName = assuredName;
        //    IncurredLoss = incurredLoss;
        //    Closes = closes;
        //}
    }
}
