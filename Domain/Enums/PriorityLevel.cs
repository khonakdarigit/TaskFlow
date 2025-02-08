﻿using System.ComponentModel;


namespace Domain.Enums
{
    public enum PriorityLevel
    {
        [Description("Low")]   
        Low = 1,

        [Description("Medium")]  
        Medium = 2,

        [Description("High")]   
        High = 3,

        [Description("Critical")]  
        Critical = 4
    }
}
