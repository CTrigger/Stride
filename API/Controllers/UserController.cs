using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StrideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Variables
        private readonly IUserRepository _userRepository;
        #endregion
        #region ctor
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion
        #region Methods

        #region Get
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(uint id)
        {
            return Ok(await _userRepository.GetById(id));
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] User user)
        {
            return Ok(await _userRepository.Insert(user));
        }

        #endregion

        #region Put
        /*Update all form*/
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(uint id, [FromForm]User user)
        {
            user.Id = id;
            return Ok(await _userRepository.Update(user));
        }
        #endregion

        #region Patch
        /*Password reset*/
        [HttpPatch]
        public async Task<IActionResult> Patch([FromForm]string email,[FromForm] string password)
        {
            return Ok(await _userRepository.UpdatePassword(email, password));
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm]uint id)
        {
            return Ok(await _userRepository.Delete(id));
        }
        #endregion



        #endregion

    }
}
