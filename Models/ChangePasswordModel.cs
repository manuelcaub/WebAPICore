namespace WebAPICore.Models
{
    public class ChangePasswordModel
    {
        public string Email { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}