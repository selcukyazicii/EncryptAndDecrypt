using encryptAndDecrypt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace encryptAndDecrypt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptDecryptController : ControllerBase
    {
        [HttpGet]
        [Route("Encrypt")]
        public string Encrypt(string text,string key)
        {
            var encryptString=EncryptDecryptManager.Encrypt(text,key);
            return encryptString;
        }
        [HttpGet]
        [Route("Decrypt")]
        public string Decrypt(string text, string key)
        {
            var decryptString = EncryptDecryptManager.Decrypt(text,key);
            return decryptString;
        }
    }
}
