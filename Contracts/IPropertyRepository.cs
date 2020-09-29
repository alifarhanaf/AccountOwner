using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IPropertyRepository : IRepositoryBase<Property>
    {
        IEnumerable<Property> GetAllProperties();
        Property GetPropertyById(Guid propertyId); 
        void CreateProperty(Property property);
        void UpdateProperty(Property property);
        void DeleteProperty(Property property);
    }
}
