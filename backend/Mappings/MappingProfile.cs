using AutoMapper;
using backend.Models;
using backend.DTO;
using backend.DTOs;

namespace backend.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTaskGroupDto, TaskGroup>();
            CreateMap<TaskGroup,ResponseTaskGroupDto>();

            CreateMap<CreateHabitDto, Habit>();
            CreateMap<Habit, ResponseHabitDto>().ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.TaskGroup!.GroupName));

            CreateMap<UpdateDailyLogDto, DailyLog>();
            CreateMap<DailyLog, DailyLogResponseDto>().ForMember(dest => dest.HabitName, opt => opt.MapFrom(src => src.Habit!.HabitName));
        }
    }
}