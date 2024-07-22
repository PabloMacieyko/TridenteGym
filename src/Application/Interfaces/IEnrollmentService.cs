using Application.DTOs.Requests;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IEnrollmentService
    {
        Task<EnrollmentDto> CreateAsync(EnrollmentCreateRequest request);

        Task<EnrollmentDto> GetEnrollmentAsync(int id);

        Task<List<EnrollmentDto>> GetAllAsync();

        Task<EnrollmentDto> UpdateAsync(EnrollmentDto enrollment, int id);

        Task DeleteAsync(int id);
    }
}
