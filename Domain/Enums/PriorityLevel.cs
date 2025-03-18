using System.ComponentModel;


namespace Domain.Enums
{
    public enum PriorityLevel
    {
        [Description("Low")]   
        Low = 0,

        [Description("Medium")]  
        Medium = 1,

        [Description("High")]   
        High = 2,

        [Description("Critical")]  
        Critical = 3
    }
}
