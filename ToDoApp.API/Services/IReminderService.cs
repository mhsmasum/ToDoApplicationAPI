using ToDoApp.API.DTOs;
using ToDoApp.API.ViewModel;

namespace ToDoApp.API.Services
{
    public interface IReminderService
    {

        Task<ResponseResult> Save(CreateReminder model, string userId);
        Task<ResponseResult> Update(UpdateReminder model, string userId);
        Task<ResponseResult> GetById(int id, string userId);
        Task<ResponseResult> GetAll(string userId);
        Task<ResponseResult> Delete(int id, string userId);
    }
}
