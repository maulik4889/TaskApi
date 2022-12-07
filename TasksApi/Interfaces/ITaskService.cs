using TasksApi.Responses;
using TasksApi.Requests;

namespace TasksApi.Interfaces
{
    public interface ITaskService
    {
        public Task<Response> Create(CreateRequest createRequest);
        public Task<Response> Read(int workerId);
        public Task<Response> Update(int id,UpdateRequest updateRequest);
        public void Delete(int workerId);
        public Task<ViewRequest> List();
        public Task<ViewRequest> GetOver25();
    }
}
