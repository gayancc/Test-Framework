namespace FlurTestFramework.Models
{
    public class Register_ResponseDTO
    {
        public Details Data { get; set; }
        public string? StatusCode { get; set; }
        public bool Success { get; set; }
        public object Messages { get; set; }
    }
    public class Details
    {
        public string? Jwtoken { get; set; }
        public string? ViPorterNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public object MiddleName { get; set; }
    }


}