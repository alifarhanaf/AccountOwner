using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext) : base(repositoryContext) { 
        }

        public PagedList<Account> GetAccountsByOwner(Guid ownerId, AccountParameters parameters)
        {
            var accounts = FindByCondition(a => a.OwnerId.Equals(ownerId));
            return PagedList<Account>.ToPagedList(accounts, parameters.PageNumber, parameters.PageSize);
        }
        public IEnumerable<Account> GetAllAccounts()
        {
            return FindAll().OrderBy(a => a.AccountType).ToList();
        }

        public Account GetAccountByOwner(Guid ownerId, Guid id)
        {
            return FindByCondition(a => a.OwnerId.Equals(ownerId) && a.Id.Equals(id)).SingleOrDefault();
        }

        public Account GetAccountById(Guid accountId)
        {
            return FindByCondition(account => account.Id.Equals(accountId)).FirstOrDefault();
        }

        public void CreateAccount(Account account)
        {
            Create(account);
        }
        public void DeleteAccount(Account account)
        {
            Delete(account);
        }
        public void UpdateAccount(Account account)
        {
            Update(account);
        }
    }
}
