namespace MockRetailerApi.Models.Requests;

public class GenerateOtpRequest
{
    public string Username { get; set; } =
        string.Empty;

    public string Version { get; set; } =
        string.Empty;
}