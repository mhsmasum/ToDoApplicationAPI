using AutoMapper;
using ToDoApp.API.DTOs;
using ToDoApp.API.Models;
using ToDoApp.API.UOW;
using ToDoApp.API.ViewModel;

namespace ToDoApp.API.Services
{
    public class BookmarkService:IBookmarkService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookmarkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseResult> Delete(int id, string userId)
        {
            ResponseResult aResult = new ResponseResult();
            try
            {
                var isExist = await _unitOfWork.Bookmarks.GetByAsync(a => a.Id == id && a.CreatedBy == userId);
                if (isExist.Count == 0)
                {
                    return new ResponseResult { Data = null, Status = Status.BadRequest, Error = "No Data Found" };
                }
                else
                {
                    await _unitOfWork.Bookmarks.DeleteAsync(id);
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
                var data = await _unitOfWork.Bookmarks.GetByUser(userId);
                return new ResponseResult { Data = _mapper.Map<List<BookmarkVM>>(data), Status = Status.Success, Error = null };
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
                var data = _unitOfWork.Bookmarks.GetByAsync(a => a.Id == id && a.CreatedBy == userId).Result.SingleOrDefault();
                return new ResponseResult { Data = _mapper.Map<BookmarkVM>(data), Status = Status.Success, Error = null };
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
                return new ResponseResult { Data = null, Status = Status.BadRequest, Error = ex };
                throw;
            }

        }

        public async Task<ResponseResult> Save(CreateBookmark model, string userId)
        {

            ResponseResult aResult = new ResponseResult();
            try
            {
                var createModel = _mapper.Map<Bookmark>(model);

                createModel.CreatedBy = userId;
                await _unitOfWork.Bookmarks.CreateAsync(createModel);
                await _unitOfWork.CompleteAsync();

                return new ResponseResult { Data = _mapper.Map<BookmarkVM>(createModel), Status = Status.Success, Error = null };
            }
            catch (Exception ex)
            {
                return new ResponseResult { Data = null, Status = Status.BadRequest, Error = ex };
                throw;
            }

        }

        public async Task<ResponseResult> Update(UpdateBookmark model, string userId)
        {
            ResponseResult aResult = new ResponseResult();
            try
            {

                var theModel = await _unitOfWork.Bookmarks.GetById(model.Id);
                theModel.Title = model.Title;
                theModel.URL = model.URL;

                theModel.UpdatedBy = userId;
                theModel.UpdateAt = DateTime.Now;
                await _unitOfWork.Bookmarks.UpdateAsync(theModel);
                await _unitOfWork.CompleteAsync();
                return new ResponseResult { Data = _mapper.Map<BookmarkVM>(theModel), Status = Status.Success, Error = null };
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
