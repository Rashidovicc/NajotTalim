namespace NajotTalim.Domain.Commons
{
    public class ErrorResponse
    {
        public ErrorResponse(int? code = null, string message = null)
        {
            this.Code = code;
            this.Message = message;
        }
        public int? Code { get; set; }
        public string Message { get; set; }
    }
}
