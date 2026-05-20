using System;
using BackendService.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BackendService.Controllers
{
    [Route("api/asymmetric")]
    [ApiController]
    public class AsymmetricController(IAsymmetricCryptographyService asymmetricService) : ControllerBase
    {
        private readonly IAsymmetricCryptographyService _asymmetricService = asymmetricService;

        [HttpGet("keypair")]
        public IActionResult GenerateKeyPair()
        {
            try
            {
                var keys = _asymmetricService.GenerateKeyPair();
                return Ok(new { publicKey = keys.PublicKey, privateKey = keys.PrivateKey });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] AsymmetricEncryptRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.PlainText) || string.IsNullOrWhiteSpace(request.PublicKey))
            {
                return BadRequest(new { error = "PlainText and PublicKey are required." });
            }

            try
            {
                var cipherText = _asymmetricService.Encrypt(request.PlainText, request.PublicKey);
                return Ok(new { cipherText });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] AsymmetricDecryptRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.CipherText) || string.IsNullOrWhiteSpace(request.PrivateKey))
            {
                return BadRequest(new { error = "CipherText and PrivateKey are required." });
            }

            try
            {
                var plainText = _asymmetricService.Decrypt(request.CipherText, request.PrivateKey);
                return Ok(new { plainText });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("sign")]
        public IActionResult Sign([FromBody] AsymmetricSignRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Data) || string.IsNullOrWhiteSpace(request.PrivateKey))
            {
                return BadRequest(new { error = "Data and PrivateKey are required." });
            }

            try
            {
                var signature = _asymmetricService.SignData(request.Data, request.PrivateKey);
                return Ok(new { signature });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("verify")]
        public IActionResult Verify([FromBody] AsymmetricVerifyRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Data) || string.IsNullOrWhiteSpace(request.Signature) || string.IsNullOrWhiteSpace(request.PublicKey))
            {
                return BadRequest(new { error = "Data, Signature, and PublicKey are required." });
            }

            try
            {
                var isValid = _asymmetricService.VerifySignature(request.Data, request.Signature, request.PublicKey);
                return Ok(new { isValid });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }

    public class AsymmetricEncryptRequest
    {
        public string PlainText { get; set; } = string.Empty;
        public string PublicKey { get; set; } = string.Empty;
    }

    public class AsymmetricDecryptRequest
    {
        public string CipherText { get; set; } = string.Empty;
        public string PrivateKey { get; set; } = string.Empty;
    }

    public class AsymmetricSignRequest
    {
        public string Data { get; set; } = string.Empty;
        public string PrivateKey { get; set; } = string.Empty;
    }

    public class AsymmetricVerifyRequest
    {
        public string Data { get; set; } = string.Empty;
        public string Signature { get; set; } = string.Empty;
        public string PublicKey { get; set; } = string.Empty;
    }
}
