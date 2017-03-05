namespace WebAPICore.Service
{
    using System;
    using System.Linq;

    public class LoginService : ILoginService
    {
        public string GenerateToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] uuid = Guid.NewGuid().ToByteArray();
            return Convert.ToBase64String(time.Concat(uuid).ToArray());
        }
    }
}