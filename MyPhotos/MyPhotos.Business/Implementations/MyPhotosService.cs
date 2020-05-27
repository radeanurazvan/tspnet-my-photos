using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MyPhotos.Business.Contracts;
using MyPhotos.Domain;
using MyPhotos.Domain.Interfaces;
using Attribute = MyPhotos.Domain.Attribute;

namespace MyPhotos.Business.Implementations
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    internal sealed class MyPhotosService : IMyPhotosFacade
    {
        private readonly IRepository<Attribute> attributesRepository;
        private readonly IRepository<Photo> photosRepository;

        public MyPhotosService(IRepository<Attribute> attributesRepository, IRepository<Photo> photosRepository)
        {
            this.attributesRepository = attributesRepository;
            this.photosRepository = photosRepository;
        }

        public async Task<IEnumerable<AttributeDto>> GetAttributes()
        {
            var attributes = await attributesRepository.GetAll();
            return attributes.Select(a => new AttributeDto
            {
                Id = a.Id,
                Name = a.Name,
                AllowsMultipleValues = a.AllowsMultipleValues
            });
        }

        public async Task<ApiResult<AttributeDto>> CreateAttribute(AttributeDto dto)
        {
            var duplicateAttribute = await this.attributesRepository.FindOne(a => a.Name == dto.Name);
            return await Result.FailureIf(duplicateAttribute.HasValue, "Attribute already exists with given name!")
                .Bind(() => Attribute.Create(dto.Name, dto.AllowsMultipleValues))
                .Tap(a => this.attributesRepository.Add(a))
                .Tap(() => this.attributesRepository.SaveChanges())
                .Map(a => new AttributeDto { AllowsMultipleValues = a.AllowsMultipleValues, Id = a.Id, Name = a.Name})
                .ToApiResult();
        }

        public async Task<IEnumerable<FileAttributeDto>> GetAllAttributesValues()
        {
            var photos = await this.photosRepository.GetAll();
            return photos.SelectMany(p => p.FileAttributes)
                .Select(fa => new FileAttributeDto(fa))
                .Distinct(new AttributeValueComparer())
                .OrderBy(fa => fa.AttributeName)
                .ThenBy(fa => fa.Value);
        }

        public async Task<ApiResult> DeleteAttribute(Guid id)
        {
            return await this.attributesRepository.GetById(id).ToResult("Attribute does not exist!")
                .Tap(a => a.Delete())
                .Tap(() => this.attributesRepository.SaveChanges())
                .Bind(_ => Result.Ok())
                .ToApiResult();
        }

        public async Task<IEnumerable<FileDto>> GetPhotos()
        {
            var photos = await photosRepository.GetAll();
            return photos.Select(p => new FileDto(p));
        }

        public async Task<IEnumerable<FileDto>> FindByKeyword(string keyword)
        {
            var photos = await this.photosRepository.GetAll();

            return photos.Where(p => p.ContainsKeyword(keyword))
                .Select(p => new FileDto(p));
        }

        public async Task<ApiResult<FileDto>> CreatePhoto(string path)
        {
            var duplicatePhoto = await this.photosRepository.FindOne(p => p.Path == path);
            return await Result.FailureIf(duplicatePhoto.HasValue, "Photo already exists at given path!")
                .Bind(() => Photo.Create(path))
                .Tap(p => this.photosRepository.Add(p))
                .Tap(() => this.photosRepository.SaveChanges())
                .Map(p => new FileDto(p))
                .ToApiResult();
        }

        public async Task<ApiResult<FileDto>> ChangeTitle(Guid id, string title)
        {
            var photoResult = await this.photosRepository.GetById(id).ToResult("Photo does not exist!");
            return await photoResult
                .Bind(p => p.ChangeTitle(title))
                .Tap(() => this.photosRepository.SaveChanges())
                .Map(() => new FileDto(photoResult.Value))
                .ToApiResult();
        }

        public async Task<ApiResult<FileDto>> AddAttributeValue(Guid id, Guid attributeId, string value)
        {
            var photoResult = await this.photosRepository.GetById(id).ToResult("Photo does not exist!");
            var attributeResult = await attributesRepository.GetById(attributeId).ToResult("Attribute does not exist!");

            return await Result.FirstFailureOrSuccess(photoResult, attributeResult)
                .Bind(() => photoResult.Value.AddAttribute(attributeResult.Value, value))
                .Tap(() => this.photosRepository.SaveChanges())
                .Map(() => new FileDto(photoResult.Value))
                .ToApiResult();
        }

        public async Task<ApiResult> DeletePhoto(Guid id)
        {
            return await this.photosRepository.GetById(id).ToResult("Photo does not exist!")
                .Tap(a => a.Delete())
                .Tap(() => this.photosRepository.SaveChanges())
                .Bind(_ => Result.Ok())
                .ToApiResult();
        }

        private sealed class AttributeValueComparer : IEqualityComparer<FileAttributeDto>
        {
            public bool Equals(FileAttributeDto x, FileAttributeDto y)
            {
                return x.AttributeId == y.AttributeId && x.Value == y.Value;
            }

            public int GetHashCode(FileAttributeDto obj)
            {
                return obj.Value.GetHashCode() + obj.AttributeId.GetHashCode();
            }
        }
    }
}