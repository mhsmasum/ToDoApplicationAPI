using ToDoApp.API.DTOs;
using ToDoApp.API.ViewModel;

namespace ToDoApp.API.Services
{
    public interface IBookmarkService
    {
        Task<ResponseResult> Save(CreateBookmark model, string userId);
        Task<ResponseResult> Update(UpdateBookmark model, string userId);
        Task<ResponseResult> GetById(int id, string userId);
        Task<ResponseResult> GetAll(string userId);
        Task<ResponseResult> Delete(int id, string userId);
    }
}
