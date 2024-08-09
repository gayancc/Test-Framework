namespace FlurTestFramework.Models
{

    public  class Login_ResponseDTO
    {
        public Data Data { get; set; }
        public string? StatusCode { get; set; }
        public bool? Success { get; set; }
        public object? Messages { get; set; }
    }

    public partial class Data
    {
        public string? Jwtoken { get; set; }
        public string? ViPorterNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public object? MiddleName { get; set; }
    }
}








