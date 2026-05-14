namespace MockRetailerApi.Models.Requests;

public class RegisterRetailerRequest
{
    public int CompanyType { get; set; }

    public string BusinessServiceType { get; set; } =
        string.Empty;

    public string Email { get; set; } =
        string.Empty;

    public string FirstName { get; set; } =
        string.Empty;

    public string LastName { get; set; } =
        string.Empty;

    public string MobileNo { get; set; } =
        string.Empty;

    public string Otp { get; set; } =
        string.Empty;

    public string OtpToken { get; set; } =
        string.Empty;

    public string Pincode { get; set; } =
        string.Empty;
}