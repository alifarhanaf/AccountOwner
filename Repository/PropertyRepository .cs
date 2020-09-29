using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PropertyRepository : RepositoryBase<Property>, IPropertyRepository
    {
        public PropertyRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Property> GetAllProperties()
        {
            return FindAll()
                .OrderBy(p => p.Name);
        }

        public Property GetPropertyById(Guid propertyId) 
        {
            return FindByCondition(property => property.ID.Equals(propertyId)).FirstOrDefault();
        }

        public void CreateProperty (Property property)
        {
            Create(property);
        }

        public void UpdateProperty (Property property)
        {
            Update(property);
        }

        public void DeleteProperty(Property property)
        {
            Delete(property);
        }

    }
}
