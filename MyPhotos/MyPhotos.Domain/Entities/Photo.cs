using System;
using System.Linq;
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

        public bool ContainsKeyword(string word)
        {
            return FileAttributes.Any(fa => fa.Value.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}