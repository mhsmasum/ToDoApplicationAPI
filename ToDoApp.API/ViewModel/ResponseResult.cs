using ToDoApp.API.Repositories;

namespace ToDoApp.API.ViewModel
{
    public class ResponseResult
    {
        public ResponseResult()
        {
            Status = Status.Success;
            
            Data = null;
            Error = null;
            
        }
        public Status Status { get; set; }
       
        public object Data { get; set; }
        public object Error { get; set; }
    }

    public enum Status
    {
        Success = 200,
        Created = 201,
        NoDataAvailable = 204,
        BadRequest = 400,
        Unauthorized = 401,
        AlreadyExists = 403,
        NotFound = 404,
        InternalServerError = 500
    }
}
