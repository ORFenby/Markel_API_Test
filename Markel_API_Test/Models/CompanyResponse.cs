using Markel_API_Test.Data;

namespace Markel_API_Test.Models
{
    public class CompanyResponse : Company
    {
        public bool HasActiveInsurancePolicy { get; set; }
    }
}
