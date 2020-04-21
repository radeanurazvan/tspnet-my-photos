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
            return photos.Select(p => new FileDto
            {
                Id = p.Id,
                Path = p.Path,
                Attributes = p.FileAttributes.Select(fa => new FileAttributeDto
                {
                    AttributeId = fa.AttributeId.GetValueOrDefault(),
                    AttributeName = fa.Attribute.Name,
                    Value = fa.Value
                })
            });
        }

        public async Task<ApiResult<FileDto>> CreatePhoto(string path)
        {
            var duplicatePhoto = await this.photosRepository.FindOne(p => p.Path == path);
            return await Result.FailureIf(duplicatePhoto.HasValue, "Photo already exists at given path!")
                .Bind(() => Photo.Create(path))
                .Tap(p => this.photosRepository.Add(p))
                .Tap(() => this.photosRepository.SaveChanges())
                .Map(p => new FileDto { Id = p.Id, Path = p.Path, CreatedAt = p.CreatedAt })
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
    }
}