using Domain.Entities;
using Mapster;


namespace Application.DTOs.Config
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //config.NewConfig<UserFile, UserFileDto>()
            //      .Map(dest => dest.SharedWithUsers, src => src.SharedWithUsers.Adapt<List<FileShareDto>>());

            //config.NewConfig<FileShare, FileShareDto>()
            //    .Map(c => c.SharedWithUser, c => c.SharedWithUser.Adapt<ApplicationUserDto>());

            config.NewConfig<ApplicationUser, ApplicationUserDto>()
                  .Map(dest => dest.OwnedProjects, src => src.OwnedProjects.Adapt<List<ProjectDto>>())
                  .Map(dest => dest.AssignedTasks, src => src.AssignedTasks.Adapt<List<TaskItemDto>>())
                  .Map(dest => dest.Audits, src => src.Audits.Adapt<List<AuditDto>>())
                  .Map(dest => dest.Comments, src => src.Comments.Adapt<List<CommentDto>>())
                  .Map(dest => dest.Logs, src => src.Logs.Adapt<List<LogDto>>())
                  .Map(dest => dest.Notifications, src => src.Notifications.Adapt<List<NotificationDto>>());
        }
    }

}
