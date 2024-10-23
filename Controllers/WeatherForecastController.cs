using Google.Authenticator;
using Microsoft.AspNetCore.Mvc;

namespace TwoFactorAuthAPI.Controllers;

[ApiController]

[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly TwoFactorAuthenticator _tfa;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        _tfa = new TwoFactorAuthenticator();
    }

    [HttpGet("generateqr")]
    public ActionResult<string> GenerateQR(string email)
    {
        string key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);

        SetupCode setupInfo = _tfa.GenerateSetupCode("Traking Code (2FA)", email, key, false, 3);
        Console.WriteLine(new
        {
            key = key,
        });
        return setupInfo.QrCodeSetupImageUrl;
    }

    [HttpPost("validatecode")]
    public ActionResult<bool> ValidateCode(string code, string key)
    {
        return _tfa.ValidateTwoFactorPIN(key, code);
    }

}
