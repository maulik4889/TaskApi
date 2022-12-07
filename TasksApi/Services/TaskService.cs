using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TasksApi.Interfaces;
using TasksApi.Requests;
using TasksApi.Responses;

namespace TasksApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly TasksDbContext tasksDbContext;

        public TaskService(TasksDbContext tasksDbContext)
        {
            this.tasksDbContext = tasksDbContext;
        }

        public async Task<Response> Create(CreateRequest createRequest)
        {
            var worker = new Worker
            {
                forename = createRequest.forename,
                surname = createRequest.surname,
                email = createRequest.email,
                dob = createRequest.dob,
            };

            await tasksDbContext.Workers.AddAsync(worker);

            var saveResponse = await tasksDbContext.SaveChangesAsync();

            return new Response
            {
                workerId = worker.workerId.ToString(),
                forename = worker.forename,
                surname = worker.surname,
                email = worker.email,
                dob = worker.dob
            };
        }

        public async Task<Response> Read(int id)
        {
            var worker = await tasksDbContext.Workers.Where(x => x.workerId == id).Select(x => x).FirstAsync();

            if (worker == null)
            {
                throw new Exception("Not exist workerId");
            }

            return new Response 
            {
                workerId = worker.workerId.ToString(),
                forename = worker.forename,
                surname = worker.surname,
                email = worker.email,
                dob = worker.dob
            };
        }

        public void Delete(int workerId)
        {
            var worker = tasksDbContext.Workers.Where(x => x.workerId == workerId).Select(x => x).First();

            try
            {
                if (worker != null)
                {
                    tasksDbContext.Workers.Remove(worker);

                    var saveResponse = tasksDbContext.SaveChanges();
                }
            }
            catch(Exception)
            {
                throw new Exception("Not exist workerId");
            }

            
        }

        public async Task<Response> Update(int id,UpdateRequest updateRequest)
        {
            var worker = await tasksDbContext.Workers.FindAsync(id);

            if(worker == null)
            {
                throw new Exception("Not exist workerId");
            }

            worker.forename = updateRequest.forename ?? worker.forename;
            worker.surname = updateRequest.surname ?? worker.surname;
            worker.email = updateRequest.email ?? worker.email;
            worker.dob = updateRequest.dob;

            await tasksDbContext.SaveChangesAsync();
            
            return new Response
            {
                forename = worker.forename,
                surname = worker.surname,
                email = worker.email,
                dob = worker.dob
            };
        }

        public async Task<ViewRequest> List()
        {
            var worker = await tasksDbContext.Workers.Select(x => x).ToListAsync();

            return new ViewRequest { GetAllWorkers = worker };
        }

        public async Task<ViewRequest> GetOver25() 
        {
            var worker = await tasksDbContext.Workers.Where(x => x.dob < DateTime.Now.AddYears(-25)).Select(x => x).ToListAsync();

            return new ViewRequest { GetAllWorkers = worker };
        }
    }
}
