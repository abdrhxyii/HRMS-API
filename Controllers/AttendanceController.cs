using HumanResource.Data;
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
        
    }
}