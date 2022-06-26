using AutoMapper;
using ToDoApp.API.DTOs;
using ToDoApp.API.Models;
using ToDoApp.API.UOW;
using ToDoApp.API.ViewModel;

namespace ToDoApp.API.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ToDoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseResult> Delete(int id , string userId)
        {
            ResponseResult aResult = new ResponseResult();
            try
            {
                var isExist = await _unitOfWork.ToDos.GetByAsync(a => a.Id == id && a.CreatedBy == userId);
                if (isExist.Count == 0)
                {
                    return new ResponseResult { Data = null, Status = Status.BadRequest, Error = "No Data Found" };
                }
                else
                {
                    await _unitOfWork.ToDos.DeleteAsync(id);
                    await _unitOfWork.CompleteAsync();
                    return new ResponseResult { Data = isExist.SingleOrDefault(), Status = Status.Success };
                }
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
                return new ResponseResult { Data = null, Status = Status.BadRequest, Error = ex };
                throw;
            }

        }

        public async Task<ResponseResult> GetAll(string userId)
        {
            ResponseResult aResult = new ResponseResult();
            try
            {
                var data = await _unitOfWork.ToDos.GetByUser( userId);
                return new ResponseResult { Data = _mapper.Map<List<ToDoVM>>(data), Status = Status.Success, Error = null };
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
                return new ResponseResult { Data = null, Status = Status.BadRequest, Error = ex };
                throw;
            }
        }

        public async Task<ResponseResult> GetById(int id, string userId)
        {
            ResponseResult aResult = new ResponseResult();
            try
            {
                var data =  _unitOfWork.ToDos.GetByAsync(a => a.Id == id && a.CreatedBy == userId).Result.SingleOrDefault();
                return new ResponseResult { Data = _mapper.Map<ToDoVM>(data), Status = Status.Success, Error = null };
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
                return new ResponseResult { Data = null, Status = Status.BadRequest, Error = ex };
                throw;
            }

        }

        public async Task<ResponseResult> SaveTodo(CreateToDo model, string userId)
        {

            ResponseResult aResult = new ResponseResult();
            try
            {
                var createModel = _mapper.Map<ToDo>(model);

                createModel.CreatedBy = userId;
                await _unitOfWork.ToDos.CreateAsync(createModel);
                await _unitOfWork.CompleteAsync();

                return new ResponseResult { Data = _mapper.Map<ToDoVM>(createModel), Status = Status.Success, Error = null };
            }
            catch (Exception ex)
            {
                return new ResponseResult { Data = null, Status = Status.BadRequest, Error = ex };
                throw;
            }

        }

        public async Task<ResponseResult> UpdateToDo(UpdateToDo model, string userId)
        {
            ResponseResult aResult = new ResponseResult();
            try
            {

                var theModel = await _unitOfWork.ToDos.GetById(model.Id);
                theModel.Title = model.Title;
                theModel.Description = model.Description;
                theModel.DueDate = model.DueDate;
                theModel.UpdatedBy = userId;
                theModel.UpdateAt = DateTime.Now;
                theModel.IsComplete = model.IsComplete;
                await _unitOfWork.ToDos.UpdateAsync(theModel);
                await _unitOfWork.CompleteAsync();
                return new ResponseResult { Data = _mapper.Map<ToDoVM>(theModel), Status = Status.Success, Error = null };
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
                return new ResponseResult { Data = null, Status = Status.BadRequest, Error = ex };
                throw;
            }
        }

        
    }
}
