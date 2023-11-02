using Markel_API_Test.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Markel_API_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly List<Claims> _claims;

        public ClaimsController()
        {
            _claims = new List<Claims>
            {
                new Claims
                {
                    UCR = "1",
                    CompanyId = 1,
                    ClaimDate = DateTime.UtcNow.AddMonths(-1),
                    LossDate = DateTime.UtcNow.AddMonths(-2),
                    AssuredName = "Oliver Fenby",
                    IncurredLoss = 6000.00m,
                    Closed = false
                },
                new Claims
                {
                    UCR = "2",
                    CompanyId = 2,
                    ClaimDate = DateTime.UtcNow.AddMonths(-2),
                    LossDate = DateTime.UtcNow.AddMonths(-3),
                    AssuredName = "Shan Smith",
                    IncurredLoss = 12000.00m,
                    Closed = true
                },
                new Claims
                {
                    UCR = "3",
                    CompanyId = 2,
                    ClaimDate = DateTime.UtcNow.AddMonths(-1),
                    LossDate = DateTime.UtcNow.AddMonths(-4),
                    AssuredName = "Richard Hammond",
                    IncurredLoss = 800000.00m,
                    Closed = true
                },
                new Claims
                {
                    UCR = "4",
                    CompanyId = 3,
                    ClaimDate = DateTime.UtcNow.AddMonths(-1),
                    LossDate = DateTime.UtcNow.AddMonths(-3),
                    AssuredName = "Janet Morrison",
                    IncurredLoss = 700.00m,
                    Closed = true
                }
            };
        }

        [HttpGet("getClaimsForCompany/{companyId}")]
        public ActionResult<List<Claim>> GetClaimsForCompany(int companyId)
        {
            var claimsForCompany = _claims.FindAll(c => c.CompanyId == companyId);
            return Ok(claimsForCompany);
        }

        [HttpGet("getClaimDetailsByUCR/{ucr}")]
        public ActionResult<ClaimDetailesResponse> GetClaimDetails(string ucr)
        {
            var claim = _claims.Find(c => c.UCR == ucr);

            if (claim == null)
            {
                return NotFound();
            }

            var claimDetailsResponse = new ClaimDetailesResponse
            {
                UCR = claim.UCR,
                ClaimDate = claim.ClaimDate,
                LossDate = claim.LossDate,
                AssuredName = claim.AssuredName,
                IncurredLoss = claim.IncurredLoss,
                Closed = claim.Closed,
                DaysOld = (int)(DateTime.UtcNow - claim.ClaimDate).TotalDays
            };

            return Ok(claimDetailsResponse);
        }

        [HttpPut("UpdateClaimByUCR/{ucr}")]
        public ActionResult UpdateClaim(string ucr, Claims updatedClaim)
        {
            var existingClaim = _claims.Find(c => c.UCR == ucr);

            if (existingClaim == null)
            {
                return NotFound();
            }

            // Update claim properties
            existingClaim.ClaimDate = updatedClaim.ClaimDate;
            existingClaim.LossDate = updatedClaim.LossDate;
            existingClaim.AssuredName = updatedClaim.AssuredName;
            existingClaim.IncurredLoss = updatedClaim.IncurredLoss;
            existingClaim.Closed = updatedClaim.Closed;

            return Ok(existingClaim);
        }
    }
}
