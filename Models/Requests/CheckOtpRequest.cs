namespace MockRetailerApi.Models.Requests;

public class CheckOtpRequest
{
    public string Otp { get; set; } =
        string.Empty;

    public string OtpToken { get; set; } =
        string.Empty;
}