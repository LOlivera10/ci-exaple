using System.Collections;

namespace Application.utils
{
    public class Response
    {
        public bool succes { get; set; }
        public string content { get; set; }
        public object objects { get; set; }
        public ArrayList arrList { get; set; }
        public int statusCode { get; set; }
        public Response(bool succes, string content)
        {
            this.succes = succes;
            this.content = content;
        }

    }
}
