//using API.IRepository;
//using API.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AnhApiController : ControllerBase
//    {
//        private readonly IAnhRepository _anhRepository;

//        public AnhApiController(IAnhRepository anhRepository)
//        {
//            _anhRepository = anhRepository;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Anh>>> GetAll()
//        {
//            var result = await _anhRepository.GetAllAsync();
//            return Ok(result);
//        }


//        [HttpGet("{id}")]
//        public async Task<ActionResult<Anh>> GetById(Guid id)
//        {
//            var result = await _anhRepository.GetByIdAsync(id);
//            if (result == null) return NotFound();
//            return Ok(result);
//        }

//        [HttpPost("upload")]
//        [Consumes("multipart/form-data")]
//        public async Task<ActionResult<Anh>> Upload([FromForm] IFormFile file, [FromForm] string tenAnh)
//        {
//            var result = await _anhRepository.UploadAsync(file, tenAnh);
//            if (result == null) return BadRequest("Upload thất bại hoặc file không hợp lệ.");
//            return Ok(result);
//        }

//        [HttpPut("{id}/file")]
//        [Consumes("multipart/form-data")]
//        public async Task<ActionResult<Anh>> Update(Guid id, [FromBody] Anh anh)
//        {
//            if (id != anh.AnhId) return BadRequest("Id không khớp.");
//            var result = await _anhRepository.UpdateAsync(anh);
//            if (result == null) return NotFound();
//            return Ok(result);
//        }

//        [HttpPut("{id}/file")]
//        public async Task<ActionResult<Anh>> UpdateFile(Guid id, [FromForm] IFormFile file, [FromForm] string tenAnh)
//        {
//            var result = await _anhRepository.UpdateFileAsync(id, file, tenAnh);
//            if (result == null) return BadRequest("Cập nhật file ảnh thất bại.");
//            return Ok(result);
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> Delete(Guid id)
//        {
//            var result = await _anhRepository.DeleteAsync(id);
//            if (!result) return NotFound();
//            return Ok();
//        }
//    }
//}

//        [HttpGet("{id}")]
//        public async Task<ActionResult<Anh>> GetById(Guid id)
//        {
//            var result = await _anhRepository.GetByIdAsync(id);
//            if (result == null) return NotFound();
//            return Ok(result);
//        }
//    }
//}

