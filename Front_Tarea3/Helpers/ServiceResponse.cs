namespace Front_Tarea3.Helpers
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public ServiceResponse()
        {
           
        }

        public ServiceResponse(T data, bool success, string message)
        {
            this.Data = data;
            this.Success = success;
            this.Message = message;
        }
    }
}
