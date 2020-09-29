using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private RepositoryContext _repositoryContext;
        private IOwnerRepository _owner;
        private IAccountRepository _account;
        private IPropertyRepository _property;

        public RepositoryWrapper(RepositoryContext repositoryContext) {
            _repositoryContext = repositoryContext;
        }

        public IOwnerRepository Owner {
            get {
                if (_owner == null) {
                    _owner = new OwnerRepository(_repositoryContext);
                }
                return _owner;
            }
        }

        public IAccountRepository Account {

            get {
                if (_account == null) {
                    _account = new AccountRepository(_repositoryContext);
                }
                return _account;
            }
        }

        public IPropertyRepository Property
        {
            get
            {
                if (_property == null)
                {
                    _property = new PropertyRepository(_repositoryContext);
                }
                return _property;
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
