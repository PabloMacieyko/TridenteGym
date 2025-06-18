using Application.DTOs;
using Application.DTOs.Requests;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _repository;
        private readonly IActivityRepository _activityRepository;
        private readonly IUserService _userService;

        public EnrollmentService(IEnrollmentRepository repository, IActivityRepository activityRepository, IUserService userService)
        {
            _repository = repository;
            _activityRepository = activityRepository;
            _userService = userService;
        }

        public async Task<EnrollmentDto> CreateAsync(EnrollmentCreateRequest request)
        {
            var user = await _userService.GetUserByIdAsync(request.ClientId);
            if (user == null || user.Role != UserRole.Client)
                throw new Exception("Solo los usuarios con rol 'Client' pueden inscribirse a actividades.");

            // Obtenemos la actividad
            var activity = await _activityRepository.GetByIdAsync(request.ActivityId);
            if (activity == null)
                throw new Exception("Activity not found");

            if (activity.AvailableSlots <= 0)
                throw new Exception("No hay cupos disponibles para esta actividad.");

            activity.AvailableSlots--;
            await _activityRepository.UpdateAsync(activity);

            var enrollment = new Enrollment();
            enrollment.ClientId = request.ClientId;
            enrollment.ActivityId = request.ActivityId;

            _ = await _repository.CreateAsync(enrollment);

            var dto = new EnrollmentDto();
            dto.ActivityId = enrollment.ActivityId;
            dto.ClientId = enrollment.ClientId;
            dto.EnrollmentId = enrollment.EnrollmentId;

            return dto;
        }

        public async Task<EnrollmentDto> GetEnrollmentAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
                throw new Exception("Enrollment not Found");

            var enrollmentDto = new EnrollmentDto()
            {
                EnrollmentId = result.EnrollmentId,
                ActivityId = result.ActivityId,
                ClientId = result.ClientId
            };
            return enrollmentDto;
        }
        public async Task<List<EnrollmentDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            var resultDto = new List<EnrollmentDto>();
            foreach (var enrollment in result)
            {
                var enrollmentDto = new EnrollmentDto()
                {
                    EnrollmentId = enrollment.EnrollmentId,
                    ActivityId = enrollment.ActivityId,
                    ClientId = enrollment.ClientId,
                };
                resultDto.Add(enrollmentDto);
            }
            return resultDto;
        }

        public async Task<EnrollmentDto> UpdateAsync(UpdateEnrollmentRequest request, int id)
        {
            // Validar que el usuario sea Client
            var user = await _userService.GetUserByIdAsync(request.ClientId);
            if (user == null || user.Role != UserRole.Client)
                throw new Exception("Solo los usuarios con rol 'Client' pueden inscribirse a actividades.");

            var enrollment = await _repository.GetByIdAsync(id);
            if (enrollment == null)
                throw new Exception("Enrollment not Found");

            enrollment.ClientId = request.ClientId;
            enrollment.ActivityId = request.ActivityId;

            await _repository.UpdateAsync(enrollment);

            var dto = new EnrollmentDto()
            {
                EnrollmentId = enrollment.EnrollmentId,
                ActivityId = enrollment.ActivityId,
                ClientId = enrollment.ClientId,
            };
            return dto;
        }
        
        public async Task DeleteAsync(int id)
        {
            var enrollment = await _repository.GetByIdAsync(id);
            if (enrollment == null)
                throw new Exception("Enrollment not Found");

            // Obtenemos la actividad
            var activity = await _activityRepository.GetByIdAsync(enrollment.ActivityId);
            if (activity != null)
            {
                activity.AvailableSlots++;
                await _activityRepository.UpdateAsync(activity);
            }

            await _repository.DeleteAsync(enrollment);
        }
    }
}
