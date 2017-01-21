using System;
using System.Linq;

namespace WebAPICore.Service
{
    public class LoginService
    {
        public string GenerateToken()
        {
            byte [] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte [] uuid = Guid.NewGuid().ToByteArray();
            return Convert.ToBase64String(time.Concat(uuid).ToArray());
        }
    }
}