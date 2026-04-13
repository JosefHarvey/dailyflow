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
    public class DailyLogController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DailyLogController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("toggle")]
        public async Task<ActionResult> ToggleDailyLog(UpdateDailyLogDto dto)
        {
            var habitExists = await _context.Habits.AnyAsync(h => h.HabitId == dto.HabitId);

            if (!habitExists)
            {
                return BadRequest("Habit tidak ditemukan");
            }

            var targetDate = dto.LogDate.Date;
            var existingLog = await _context.DailyLogs.FirstOrDefaultAsync(l => l.HabitId == dto.HabitId && l.LogDate.Date == targetDate);

            if (existingLog != null)
            {
                // LOGIKA UPDATE: Kalau lognya sudah ada, kita timpa statusnya dengan yang baru
                existingLog.IsCompleted = dto.IsCompleted;
            }
            else
            {
                // LOGIKA INSERT: Kalau belum ada catatannya sama sekali hari ini, kita buat baru!
                var newLog = new DailyLog
                {
                    HabitId = dto.HabitId,
                    LogDate = targetDate, // Simpan tanggalnya
                    IsCompleted = dto.IsCompleted
                };
                  
                _context.DailyLogs.Add(newLog);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Status Habit harian berhasil diperbarui!", isCompleted = dto.IsCompleted });
        }
    }
}