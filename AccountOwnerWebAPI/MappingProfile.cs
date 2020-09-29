using AutoMapper;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DataTransferObjects;

namespace AccountOwnerWebAPI
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<Owner, OwnerDto>();

            CreateMap<Account, AccountDto>();

            CreateMap<OwnerForCreateDto, Owner>();

            CreateMap<OwnerForUpdateDto, Owner>();

            CreateMap<Account, AccountDto>();

            CreateMap<Property, PropertyDto>();

            CreateMap<PropertyForCreateDto, Property>();

            CreateMap<PropertyForUpdateDto, Property>();

            //CreateMap<Owner, OwnerDto>();
        }
    }
}
