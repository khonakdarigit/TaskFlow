using System.ComponentModel;

namespace Domain.Enums
{
    public enum TaskStatus
    {
        [Description("Not Started")]
        NotStarted = 0,

        [Description("In Progress")]
        InProgress = 1,

        [Description("Completed")]
        Completed = 2,

        [Description("On Hold")]
        OnHold = 3,

        [Description("Canceled")]
        Canceled = 4
    }
}
