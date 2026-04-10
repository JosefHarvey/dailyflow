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

    public class HabitController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        
        public HabitController(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseHabitDto>>> GetHabits()
            {
                var habits = await _context.Habits.Include(h=> h.TaskGroup).ToListAsync();

                var dtoList = _mapper.Map<List<ResponseHabitDto>>(habits);

                return Ok(dtoList);
            }

        [HttpPost]
        public async
        Task<ActionResult<ResponseHabitDto>>CreateHabitDto(CreateHabitDto dto)
        {
            var groupExist = await _context.TaskGroups.AnyAsync(g=> g.GroupId == dto.GroupId);

            if (!groupExist)
            {
                return BadRequest("Gagal menyimpan Habit: Kategori tidak ditemuka");
            }

            var newHabit = _mapper.Map<Habit>(dto);

            _context.Habits.Add(newHabit);
            await _context.SaveChangesAsync();
            
            await _context.Entry(newHabit).Reference(h => h.TaskGroup).LoadAsync();

            var responseDto = _mapper.Map<ResponseHabitDto>(newHabit);

            return Ok(responseDto);
        }
    }
}