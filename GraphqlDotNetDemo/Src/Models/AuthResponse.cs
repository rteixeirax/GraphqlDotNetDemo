namespace GraphqlDotNetDemo.Src.Models
{
    public class AuthResponse
    {
        public string AccessToken { get; set; }
        public string AccessTokenExpiracy { get; set; }
        public string RefreshToken { get; set; }
        public string RefreshTokenExpiracy { get; set; }
    }
}
