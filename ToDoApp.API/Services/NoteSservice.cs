using AutoMapper;
using ToDoApp.API.DTOs;
using ToDoApp.API.Models;
using ToDoApp.API.UOW;
using ToDoApp.API.ViewModel;

namespace ToDoApp.API.Services
{
    public class NoteSservice:INoteService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NoteSservice(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseResult> Delete(int id, string userId)
        {
            ResponseResult aResult = new ResponseResult();
            try
            {
                var isExist = await _unitOfWork.Notes.GetByAsync(a => a.Id == id && a.CreatedBy == userId);
                if (isExist.Count == 0)
                {
                    return new ResponseResult { Data = null, Status = Status.BadRequest, Error = "No Data Found" };
                }
                else
                {
                    await _unitOfWork.Notes.DeleteAsync(id);
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
                var data = await _unitOfWork.Notes.GetByUser(userId);
                return new ResponseResult { Data = _mapper.Map<List<NoteVM>>(data), Status = Status.Success, Error = null };
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
                var data = _unitOfWork.Notes.GetByAsync(a => a.Id == id && a.CreatedBy == userId).Result.SingleOrDefault();
                return new ResponseResult { Data = _mapper.Map<NoteVM>(data), Status = Status.Success, Error = null };
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
                return new ResponseResult { Data = null, Status = Status.BadRequest, Error = ex };
                throw;
            }

        }

        public async Task<ResponseResult> Save(CreateNote model, string userId)
        {

            ResponseResult aResult = new ResponseResult();
            try
            {
                var createModel = _mapper.Map<Note>(model);

                createModel.CreatedBy = userId;
                await _unitOfWork.Notes.CreateAsync(createModel);
                await _unitOfWork.CompleteAsync();

                return new ResponseResult { Data = _mapper.Map<NoteVM>(createModel), Status = Status.Success, Error = null };
            }
            catch (Exception ex)
            {
                return new ResponseResult { Data = null, Status = Status.BadRequest, Error = ex };
                throw;
            }

        }

        public async Task<ResponseResult> Update(UpdateNote model, string userId)
        {
            ResponseResult aResult = new ResponseResult();
            try
            {

                var theModel = await _unitOfWork.Notes.GetById(model.Id);
                theModel.Title = model.Title;
                theModel.Description = model.Description;
                
                theModel.UpdatedBy = userId;
                theModel.UpdateAt = DateTime.Now;
                await _unitOfWork.Notes.UpdateAsync(theModel);
                await _unitOfWork.CompleteAsync();
                return new ResponseResult { Data = _mapper.Map<NoteVM>(theModel), Status = Status.Success, Error = null };
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
