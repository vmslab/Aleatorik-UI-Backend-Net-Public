namespace MozartUI.Services.Template.DTO
{
	public class AuthInfo
	{
		public string? AccessToken { get; set; }
		public string? RefreshToken { get; set; }
		public string? Name { get; set; }
		public string? Role { get; set; }
		public string? Email { get; set; }
		public string? Expiration { get; set; }
		public bool? Success { get; set; }
		public bool? Confirmed { get; set; }
		public string? Password { get; set; }
	}
}