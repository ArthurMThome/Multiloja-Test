namespace Multiloja_BLL
{
    public class DefaultReturn<T>
    {
        public System.Net.HttpStatusCode httpStatusCode { get; set; }
        public string msg { get; set; }
        public T obj { get; set; }
    }
}