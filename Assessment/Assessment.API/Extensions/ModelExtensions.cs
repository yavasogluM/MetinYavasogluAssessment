using System.Collections.Generic;
using System.Linq;
using Assessment.API.Model.Request;
using Assessment.API.Model.Response;
using Assessment.Data.Model;

namespace Assessment.API.Extensions
{
    public static class ModelExtensions
    {
        public static List<ContactListResponse> ConvertToContactListResponse(this List<Contact> contacts)
        {
            return contacts.Select(x => new ContactListResponse
            {
                UUId = x.UUID,
                Name = x.Name,
                LastName = x.LastName,
                Firm = x.Firm,
                ContentOfInformation = x.ContactInformation.ContentOfInformation,
                ContentOfInformationType = (int) x.ContactInformation.InformationType
            }).ToList();
        }

        public static Contact ConvertToContact(this ContactUpsertRequest contactUpsertRequest)
        {
            return new Contact
            {
                UUID = contactUpsertRequest.UUId,
                Name = contactUpsertRequest.Name,
                LastName = contactUpsertRequest.LastName,
                Firm = contactUpsertRequest.Firm,
                ContactInformation = new ContactInformation
                {
                    ContentOfInformation = contactUpsertRequest.ContentOfInformation,
                    InformationType = contactUpsertRequest.ContentOfInformationType
                }
            };
        }
    }
}