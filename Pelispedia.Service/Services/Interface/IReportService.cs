using Pelispedia.Service.DTOs;

namespace Pelispedia.Service.Services.Interface
{
    public interface IReportService
    {
        Task<ReportDTO> GetGeneralReport();
    }
}