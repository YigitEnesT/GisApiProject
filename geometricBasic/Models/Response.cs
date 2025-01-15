namespace geometricBasic.Models
{
    public class Response<T>
    {
        public T Value { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
