namespace geometricBasic.Models
{
    public class Response<T>
    {
        public T Value { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
