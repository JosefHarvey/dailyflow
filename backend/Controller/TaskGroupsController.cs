using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using backend.Data;
using backend.DTO;
using backend.Models;

namespace backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskGroupController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TaskGroupController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseTaskGroupDto>>> GetTaskGroup()
        {
            var groups = await _context.TaskGroups.ToListAsync();
            var dtoList = _mapper.Map<List<ResponseTaskGroupDto>>(groups);

            return Ok(dtoList);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseTaskGroupDto>> CreateTaskGroup(CreateTaskGroupDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync();
    
            if (user == null)
            {
                user = new User 
                { 
                    Name = "Josef Harvey", 
                    Email = "josef@test.com", 
                    GoogleAuthId = "dummy_token_123", 
                    CreatedAt = DateTime.UtcNow 
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync(); // Simpan User Josef ke database
            }

            var newGroup = _mapper.Map<TaskGroup>(dto);

            newGroup.UserId = 1;

            _context.TaskGroups.Add(newGroup);
            await _context.SaveChangesAsync();

            var responseDto = _mapper.Map<ResponseTaskGroupDto>(newGroup);

            return CreatedAtAction(nameof(GetTaskGroup), new { id = responseDto.GroupId }, responseDto);
        }
    }
}