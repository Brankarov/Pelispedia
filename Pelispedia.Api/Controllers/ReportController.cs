using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pelispedia.Service.DTOs;
using Pelispedia.Service.Services.Interface;

namespace Pelispedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService) 
        {
            _reportService = reportService;
        }

        [HttpGet("GetGeneralReporte", Name = "GetGeneralReporte")]
        public async Task<ActionResult<ReportDTO>> GetGeneralReport() 
        {
            var report = await _reportService.GetGeneralReport();
            return Ok(report);
        }


    }
}
