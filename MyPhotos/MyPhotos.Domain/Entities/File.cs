using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using MyPhotos.Domain.Common;

namespace MyPhotos.Domain
{
    public partial class File : IEntity
    {
        protected File(string path)
            : this()
        {
            Id = Guid.NewGuid();
            Path = path;
            Title = path.Split('.').First();
            CreatedAt = DateTime.Now;
        }

        public Result ChangeTitle(string newTitle)
        {
            return Result.FailureIf(string.IsNullOrEmpty(newTitle?.Trim()), "Title should not be null or empty!")
                .Tap(() => Title = newTitle);
        }

        public Result AddAttribute(Attribute attribute, string value)
        {
            var attributeResult = FileAttribute.Create(this, attribute, value);
            var duplicateAttributeResult = attributeResult
                .Map(a => FileAttributes.FirstOrDefault(fa => fa.AttributeId == a.AttributeId))
                .Ensure(a => a == null || a.Attribute.AllowsMultipleValues, "Attribute does not allow multiple values!");

            return Result.FirstFailureOrSuccess(attributeResult, duplicateAttributeResult)
                .Tap(() => FileAttributes.Add(attributeResult.Value));
        }

        public void Delete()
        {
            this.IsDeleted = true;
        }

        private void AddAttributes(IEnumerable<FileAttribute> attributes)
        {
            foreach (var attribute in attributes)
            {
                FileAttributes.Add(attribute);
            }
        }
    }
}