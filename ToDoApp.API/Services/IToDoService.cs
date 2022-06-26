using ToDoApp.API.DTOs;
using ToDoApp.API.ViewModel;

namespace ToDoApp.API.Services
{
    public interface IToDoService
    {
        Task<ResponseResult> SaveTodo(CreateToDo model, string userId);
        Task<ResponseResult> UpdateToDo(UpdateToDo model, string userId);
        Task<ResponseResult> GetById(int id, string userId);
        Task<ResponseResult> GetAll( string userId);
        Task<ResponseResult> Delete( int id , string userId);
    }
}
