using MockRetailerApi.Models.Entities;

namespace MockRetailerApi.MockData;

public static class MockRetailerData
{
    public static List<OtpStore> ValidOtpStore =
    [
        new()
        {
            Mobile = "8446152135",
            Otp = "179237",
            OtpToken = "TOKEN_001"
        },

        new()
        {
            Mobile = "7208505572",
            Otp = "316243",
            OtpToken = "TOKEN_002"
        },

        new()
        {
            Mobile = "9819631954",
            Otp = "654321",
            OtpToken = "TOKEN_003"
        },

        new()
        {
            Mobile = "9988776655",
            Otp = "111111",
            OtpToken = "TOKEN_004"
        }
    ];
}