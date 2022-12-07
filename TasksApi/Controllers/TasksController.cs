using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasksApi.Interfaces;
using TasksApi.Requests;
using TasksApi.Responses;

namespace TasksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : BaseApiController
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpPost("worker/Create")]
        public async Task<Response> Create([FromForm]CreateRequest createRequest)
        {
            return await taskService.Create(createRequest);
        }

        [HttpGet("Worker/Read/{id}")]
        public async Task<Response> Read([FromRoute(Name = "id")] int id)
        {
            return await taskService.Read(id);
        }

        [HttpPut("Worker/Update/{id}")]
        public async Task<Response> Update([FromRoute(Name = "id")] int id,[FromForm] UpdateRequest updateRequest)
        {
            return await taskService.Update(id, updateRequest);
        }

        [HttpDelete("Worker/Delete/{id}")]
        public void Delete([FromRoute(Name = "id")] int id)
        {
            taskService.Delete(id);
        }

        [HttpGet("Worker/List")]
        public async Task<ViewRequest> List()
        {
            return await taskService.List();
        }

        [HttpGet("Worker/GetOver25")]
        public async Task<ViewRequest> GetOver25()
        {
            return await taskService.GetOver25();
        }

    }
}
