using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.API.Model.Request;
using Assessment.API.Model.Response;
using Assessment.Data.Model;
using Assessment.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assessment.API.Extensions;

namespace Assessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public ContactController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [Route("contact-list")]
        [HttpGet]
        public async Task<List<ContactListResponse>> ContactList()
        {
            var list = await _repositoryWrapper.ContactRepository.GetContacts();
            return list.ConvertToContactListResponse();
        }

        [Route("contact-list-by-location")]
        [HttpGet]
        public async Task<List<ContactListResponse>> ContactListByLocation(string location)
        {
            var list = await _repositoryWrapper.ContactRepository.GetContactsByLocation(location);
            return list.ConvertToContactListResponse();
        }

        [Route("remove-contact")]
        [HttpPut]
        public async Task<BaseResponse> RemoveContact(ContactRemoveRequest request)
        {
            var result = await _repositoryWrapper.ContactRepository.Remove(request.UUId);
            return new BaseResponse
            {
                IsValid = result.IsValid,
                Detail = result.Detail
            };
        }
        
        [Route("delete-contact")]
        [HttpDelete]
        public async Task<BaseResponse> DeleteContact(ContactRemoveRequest request)
        {
            var result = await _repositoryWrapper.ContactRepository.Delete(request.UUId);
            return new BaseResponse
            {
                IsValid = result.IsValid,
                Detail = result.Detail
            };
        }
        
        [Route("upsert-contact")]
        [HttpPost]
        public async Task<ContactUpsertResponse> UpsertContact(ContactUpsertRequest request)
        {
            var result = await _repositoryWrapper.ContactRepository.Upsert(request.ConvertToContact());
            return new ContactUpsertResponse()
            {
                IsValid = result.IsValid,
                Detail = result.Detail
            };
        }
    }
}