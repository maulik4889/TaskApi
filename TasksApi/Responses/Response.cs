using System.ComponentModel.DataAnnotations;

namespace TasksApi.Responses
{
    public class Response
    {
        public string workerId { get; set; }
        
        public string forename { get; set; }

        public string surname { get; set; }

        public string email { get; set; }

        public DateTime dob { get; set; }
    }
}
