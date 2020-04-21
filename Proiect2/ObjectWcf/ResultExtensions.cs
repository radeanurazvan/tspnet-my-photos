using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MyPhotos.Business.Contracts;

namespace MyPhotos.Business
{
    public static class ResultExtensions
    {
        public static async Task<ApiResult<T>> ToApiResult<T>(this Task<Result<T>> resultTask)
            where T : class
        {
            var result = await resultTask;
            return result.ToApiResult();
        }

        public static async Task<ApiResult> ToApiResult(this Task<Result> resultTask)
        {
            var result = await resultTask;
            return result.ToApiResult();
        }

        public static ApiResult ToApiResult(this Result result)
        {
            return new ApiResult
            {
                IsSuccess = result.IsSuccess,
                IsFailure = result.IsFailure,
                Error = result.IsFailure ? result.Error : string.Empty
            };
        }

        public static ApiResult<T> ToApiResult<T>(this Result<T> result)
            where T : class
        {
            return new ApiResult<T>
            {
                IsSuccess = result.IsSuccess,
                IsFailure = result.IsFailure,
                Error = result.IsFailure ? result.Error : string.Empty,
                Value = result.IsSuccess ? result.Value : null as T
            };
        }
    }
}