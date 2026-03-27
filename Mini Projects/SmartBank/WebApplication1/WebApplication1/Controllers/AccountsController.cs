using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountServices _service;

        public AccountsController(IAccountServices service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(CreateAccountDto dto)
        {
            var result = _service.CreateAccount(dto);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPost("deposit")]
        public IActionResult Deposit(TransactionDto dto)
        {
            _service.Deposit(dto);
            return Ok("Deposited successfully");
        }

        [HttpPost("withdraw")]
        public IActionResult Withdraw(TransactionDto dto)
        {
            _service.Withdraw(dto);
            return Ok("Withdrawn successfully");
        }
    }
}
