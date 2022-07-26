using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _userRepository.GetById(id));
        }
        #endregion

        #endregion

    }
}
