using Entities.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        //IEnumerable<Account> AccountsByOwner(Guid ownerId);
        IEnumerable<Account> GetAllAccounts();

        PagedList<Account> GetAccountsByOwner(Guid ownerId, AccountParameters parameters);
        Account GetAccountById(Guid accountId);
        Account GetAccountByOwner(Guid ownerId, Guid id);
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(Account account);
    }
}
