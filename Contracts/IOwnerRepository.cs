using Entities.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        IEnumerable<Owner> GetAllOwners();
        PagedList<Owner> GetOwners(OwnerParameters ownerParameters);
        Owner GetOwnerById(Guid ownerId);
        Owner GetOwnerWithDetails(Guid ownerId);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}

