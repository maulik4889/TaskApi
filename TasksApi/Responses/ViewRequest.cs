using System.ComponentModel.DataAnnotations;

namespace TasksApi.Responses
{
    public class ViewRequest
    {
        public IEnumerable<Worker> GetAllWorkers { get; set; }
    }
}
