using Markel_API_Test.Controllers;
using Markel_API_Test.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using Xunit;

namespace Markel_API_Test.UnitTest
{
    public class ClaimsControllerTest
    {

        [Fact]
        public void GetClaimsForCompany_ReturnsClaimsForValidCompanyId()
        {
            var controller = new ClaimsController();
            var companyId = 1;

            var result = controller.GetClaimsForCompany(companyId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var claims = Assert.IsType<List<Claims>>(okResult.Value);
            Assert.NotEmpty(claims);
            Assert.Equal(companyId, claims[0].CompanyId);
        }

        [Fact]
        public void GetClaimDetails_ReturnsClaimDetailsWithDaysOld()
        {
            var controller = new ClaimsController();
            var ucr = "1";

            var result = controller.GetClaimDetails(ucr);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var claimDetailsResponse = Assert.IsType<ClaimDetailesResponse>(okResult.Value);
            Assert.Equal(ucr, claimDetailsResponse.UCR);
            Assert.True(claimDetailsResponse.DaysOld >= 0);
        }
    }
}
