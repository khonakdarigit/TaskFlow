using Domain.Enums;

namespace Web.Helper
{
    public static class UIHelper
    {
        public static string GetPriorityColor(PriorityLevel priorityLevel)
        {
            string color = "#68b8f1";// Low default
            switch (priorityLevel)
            {
                case PriorityLevel.Low:
                    color = "#68b8f1";
                    break;
                case PriorityLevel.Medium:
                    color = "#d2d500";
                    break;
                case PriorityLevel.High:
                    color = "#ed3a3a";
                    break;
                case PriorityLevel.Critical:
                    color = "#222222";
                    break;
                default:
                    break;
            }
            return color;
        }

        public static string GetTaskStatusColor(Domain.Enums.TaskStatus taskStatus)
        {
            string color = "#68b8f1";// InProgress default
            switch (taskStatus)
            {
                case Domain.Enums.TaskStatus.NotStarted:
                    color = "#0098b1";
                    break;
                case Domain.Enums.TaskStatus.InProgress:
                    color = "#00874f";
                    break;
                case Domain.Enums.TaskStatus.Completed:
                    color = "#861ebb";
                    break;
                case Domain.Enums.TaskStatus.OnHold:
                    color = "#cddb00";
                    break;
                case Domain.Enums.TaskStatus.Canceled:
                    color = "#939393";
                    break;
                default:
                    break;
            }
            return color;
        }
    }
}
