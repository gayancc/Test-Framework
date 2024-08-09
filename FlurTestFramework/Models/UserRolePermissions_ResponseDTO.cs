namespace FlurTestFramework.Models
{
    public class UserRolePermissions_ResponseDTO
    {
            public Data Data { get; set; }
        }

        public partial class Data
        {
            public string? Token { get; set; }
            public long IdleTimeoutInMinutes { get; set; }
        }
    }

