using Microsoft.AspNetCore.Mvc;
using MockRetailerApi.MockData;
using MockRetailerApi.Models.Requests;

namespace MockRetailerApi.Controllers;

[ApiController]
public class RetailerController : ControllerBase
{
    [HttpPost]
    [Route("register/retailer/validatemobile/generate_otp")]
    public IActionResult GenerateOtp(
        [FromBody] GenerateOtpRequest request)
    {
        var otp = "179237";

        var otpToken =
            Guid.NewGuid().ToString();

        MockRetailerData.ValidOtpStore.Add(
            new()
            {
                Mobile = request.Username,
                Otp = otp,
                OtpToken = otpToken
            });

        return Ok(new
        {
            resultCode = "200",
            resultStatus = "TXN",
            resultMessage =
                $"Verification code has been send to mobile number {request.Username}",
            otpToken
        });
    }

    [HttpPost]
    [Route("register/retailer/validatemobile/check_otp")]
    public IActionResult CheckOtp(
        [FromBody] CheckOtpRequest request)
    {
        var data =
            MockRetailerData.ValidOtpStore
            .FirstOrDefault(x =>
                x.Otp == request.Otp);

        if (data == null)
        {
            return BadRequest(new
            {
                resultCode = "400",
                resultStatus = "ERR",
                resultMessage = "In-valid Otp."
            });
        }

        return Ok(new
        {
            resultCode = "200",
            resultStatus = "TXN",
            otpToken = Guid.NewGuid().ToString(),
            resultMessage = "Details not found"
        });
    }

    [HttpPost]
    [Route("register/retailer/new")]
    public IActionResult RegisterRetailer(
        [FromBody] RegisterRetailerRequest request)
    {
        var data =
            MockRetailerData.ValidOtpStore
            .FirstOrDefault(x =>
                x.Otp == request.Otp);

        if (data == null)
        {
            return BadRequest(new
            {
                resultCode = "400",
                resultStatus = "ERR",
                resultMessage = "Invalid OTP"
            });
        }

        return Ok(new
        {
            status = "true",
            data = "Details found.",
            businessIdentificationCode = "876fb243",
            businessName = "NA",
            businessOwnerName =
                $"{request.FirstName} {request.LastName}",
            mobile = request.MobileNo,
            businessStatus = "IN COMPLETE",
            isKycOfficer = 0,
            companyType = request.CompanyType,
            businessServiceType =
                request.BusinessServiceType,
            balance = "0",
            businessAuthToken = "sample-token",
            resultMessage =
                "Retailer Registered Successfully",
            resultCode = "200",
            resultStatus = "TXN"
        });
    }

    [HttpPost]
    [Route("retailer/businessdetailsFetchnew")]
    public IActionResult BusinessDetails(
        [FromBody] BusinessDetailsRequest request)
    {
        return Ok(new
        {
            status = "true",
            data = "Details found.",
            businessIdentificationCode =
                request.IdentificationCode,
            businessName = "Nikhil Enterprise",
            businessOwnerName = "Nikhil Nishad",
            mobile = "9819631954",
            businessStatus = "IN COMPLETE",
            isKycOfficer = 0,
            companyType = 2,
            businessServiceType = "2",
            balance = "0",
            resultMessage = "Details found.",
            resultCode = "200",
            resultStatus = "TXN"
        });
    }
}