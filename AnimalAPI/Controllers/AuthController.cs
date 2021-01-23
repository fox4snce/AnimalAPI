﻿using AnimalAPI.Data;
using AnimalAPI.Models;
using AnimalAPI.Models.Auth;
using AnimalAPI.Models.Dtos.User;
using AnimalAPI.Models.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            ServiceResponse<int> response = await _authRepo.Register
                (
                new User { Username = request.Username }, request.Password
                );
            if(!response.Success)
            {
                return BadRequest(response);
            } else
            {
                return Ok(response);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            ServiceResponse<string> response = await _authRepo.Login
                (
                request.Username, request.Password
                );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("Verify")]
        public async Task<IActionResult> Verify()
        {
            ServiceResponse<string> response = new ServiceResponse<string>();

            response.Success = true;
            response.Message = "Ok";

            return Ok(response);
        }

    }
}
