namespace CozyThings.Services.CouponApi.Models
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;

        public object Result { get; set; }

        public string DisplayMessage { get; set; } = string.Empty;

        public IReadOnlyList<string> ErrorMessages { get; set; } = Array.Empty<string>();
    }
}
