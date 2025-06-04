using API.IRepository;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatLieuController : ControllerBase
    {
        private readonly IChatLieuRepository _chatLieuRepository;

        public ChatLieuController(IChatLieuRepository chatLieuRepository)
        {
            _chatLieuRepository = chatLieuRepository;
        }

        // GET: api/ChatLieu
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _chatLieuRepository.GetAllAsync();
            return Ok(list);
        }

        // GET: api/ChatLieu/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _chatLieuRepository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        // POST: api/ChatLieu
        [HttpPost]
        public async Task<IActionResult> Create(ChatLieu chatLieu)
        {
            chatLieu.ChatLieuId = Guid.NewGuid();
            await _chatLieuRepository.AddAsync(chatLieu);
            return Ok();
        }

        // PUT: api/ChatLieu/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ChatLieu chatLieu)
        {
            var existing = await _chatLieuRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.TenChatLieu = chatLieu.TenChatLieu;
            existing.MoTa = chatLieu.MoTa;
            existing.TrangThai = chatLieu.TrangThai;

            await _chatLieuRepository.UpdateAsync(existing);
            return Ok();
        }

        // DELETE: api/ChatLieu/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _chatLieuRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
