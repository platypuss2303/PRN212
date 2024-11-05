using Microsoft.EntityFrameworkCore;
using PRN212.DAL.Repositories;

namespace PRN212.BLL.Services
{
    public class TaskService
    {
        private TaskRepository _repo = new TaskRepository();

        public List<DAL.Models.Task> GetAllTasks() => _repo.GetTasks();
        public List<DAL.Models.Task> GetTaskById(Guid id) => _repo.GetTaskById(id);
        public void RemoveTask(DAL.Models.Task task)
        {
            _repo.DeleteTask(task); 
        }

        public DAL.Models.Task? FindTask(int id)
        {
            return _repo.Find(id);
        }
    }
}
