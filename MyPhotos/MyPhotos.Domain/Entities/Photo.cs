using CSharpFunctionalExtensions;

namespace MyPhotos.Domain
{
    public partial class Photo 
    {
        private Photo()
        {
        }

        private Photo(string path)
            : base(path)
        {
        }

        public static Result<Photo> Create(string path)
        {
            return Result.FailureIf(string.IsNullOrEmpty(path?.Trim()), "Invalid file path!")
                .Map(() => new Photo(path));
        }
    }
}