using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AccountOwnerWebAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;


        public AccountController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper) {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]

        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            try
            {
                var accounts = _repository.Account.GetAllAccounts();
                _logger.LogInfo($"Returned all ({accounts}) owners from database");

                var accountResult = _mapper.Map<IEnumerable<AccountDto>>(accounts);

                return Ok(accountResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        //public IActionResult GetAccountsForOwner(Guid ownerId, [FromQuery] AccountParameters parameters)
        //{
        //    var accounts = _repository.Account.GetAccountsByOwner(ownerId, parameters);

        //    var metadata = new
        //    {
        //        accounts.TotalCount,
        //        accounts.PageSize,
        //        accounts.CurrentPage,
        //        accounts.TotalPages,
        //        accounts.HasNext,
        //        accounts.HasPrevious
        //    };

        //    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        //    _logger.LogInfo($"Returned {accounts.TotalCount} owners from database.");

        //    return Ok(accounts);
        //}


        [HttpGet("{id}")]
        public IActionResult GetAccountForOwner(Guid ownerId, Guid id)
        {
            var account = _repository.Account.GetAccountByOwner(ownerId, id);

            if (account== null)
            {
                _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            return Ok(account);
        }


        //[HttpGet]
        //public IActionResult GetAccountsForOwner(Guid ownerId, [FromQuery] AccountParameters parameters) { 

        //    var accounts = _repository.Account.GetAcc

        //}


        //[HttpGet("{id}", Name = "AccountById")]
        //public IActionResult GetAccountById(Guid id) {
        //    try {
        //        var account = _repository.Account.GetAccountById(id);
        //        if (account == null) {
        //            _logger.LogError($"Account with id {id}, hasn't been found in db.");
        //            return NotFound();
        //        } else {
        //            _logger.LogInfo($"Returnes owner with id: {id}");
        //            var accountResult = _mapper.Map<AccountDto>(account);
        //            return Ok(accountResult);
        //        }
        //    }
        //    catch (Exception ex) {
        //        _logger.LogError($"Something went wrong inside GetAccountById action: {ex.Message}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        [HttpPost]
        public IActionResult CreateAccount([FromBody]AccountForCreateDto account) {

            try {
                if (account == null)
                {
                    _logger.LogError($"Account object sent from client is null");
                    return BadRequest("Account object is null");
                }
                if (!ModelState.IsValid) {
                    _logger.LogError($"Invalid account object sent from client");
                    return BadRequest("Invalid account object");
                }

                var accountEntity = _mapper.Map<Account>(account);

                _repository.Account.CreateAccount(accountEntity);
                _repository.Save();

                var createdAccount = _mapper.Map<AccountDto>(accountEntity);

                return CreatedAtRoute("AccountById", new { id = createdAccount.Id }, createdAccount);
            }
            catch (Exception ex) {
                _logger.LogError($"Something went wring inside CreateAccount action : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody]AccountForUpdateDto account) {
            try {
                if (account == null) {
                    _logger.LogError("Account objext sent from client is null");
                    return BadRequest("Account object is null");
                }

                if (!ModelState.IsValid) {
                    _logger.LogError("Invalid account object sent from client");
                    return BadRequest("Invalud account object sent from client");
                }

                var accountEntity = _repository.Account.GetAccountById(id);

                if (accountEntity == null) {
                    _logger.LogError($"Account with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(account, accountEntity);

                _repository.Account.UpdateAccount(accountEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex) {
                _logger.LogError($"Something went wrong inside UpdateAccount action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id) {
            try {
                var account = _repository.Account.GetAccountById(id);
                if (account == null) {
                    _logger.LogError($"Account with id: {id}, hasn't found in db.");
                    return NotFound();
                }

                _repository.Account.DeleteAccount(account);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex) {
                _logger.LogError($"Something went wring inside DeleteAccount action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}