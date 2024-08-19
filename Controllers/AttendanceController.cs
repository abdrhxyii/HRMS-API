using HumanResource.Data;
using HumanResource.Modals;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Controllers
{
    [Route("attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("")]
        public async Task<ActionResult<AttendanceModal>> CreateAttendance([FromBody] AttendanceModal attendanceModal)
        {
            _context.Attendances.Add(attendanceModal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateAttendance), new {id = attendanceModal.Id}, attendanceModal);
        }
        
    }
}