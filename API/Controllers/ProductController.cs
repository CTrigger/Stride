using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Enum;
using Repository.Interfaces;
using Services.Interface;
using System;
using System.IO;
using System.Threading.Tasks;


namespace StrideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Variables
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;
        #endregion

        #region ctor
        public ProductController(
            IProductRepository productRepository,
            IFileService fileService)
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }
        #endregion

        #region Methods
        #region Get
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Ok(await _productRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _productRepository.GetById(id));
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Product product)
        {
            ProcessStatus status = (ProcessStatus)await _productRepository.Insert(product);
            return status switch
            {
                ProcessStatus.Success => StatusCode(StatusCodes.Status201Created, product),
                ProcessStatus.NotFound => StatusCode(StatusCodes.Status304NotModified, product),
                _ => NotFound("Error"),
            };
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile image)
        {
            try
            {
                await _fileService.SaveImageAsync(image, FileMode.CreateNew);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
        #endregion

        #region Put
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(uint id, [FromBody] Product product)
        {

            product.Id = id;
            ProcessStatus status = (ProcessStatus)await _productRepository.Update(product);
            return status switch
            {
                ProcessStatus.Success => Ok(),
                ProcessStatus.Failed => NotFound("Update failed"),
                ProcessStatus.NotFound=> NotFound("Id not found"),
                _ => NotFound("Error"),
            };
        }

        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ProcessStatus status = (ProcessStatus)await _productRepository.Delete(id);
            return status switch
            {
                ProcessStatus.Success => Ok("Record deleted"),
                ProcessStatus.NotFound => NotFound("No record found against this id"),
                ProcessStatus.Failed => StatusCode(StatusCodes.Status304NotModified,"Failed to delete"),
                _ => NotFound("Error")
            };

        }

        #endregion

        #endregion

    }
}
