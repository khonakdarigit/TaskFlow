﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Helper
{
    public static class EnumHelper
    {
        public static List<SelectListItem> GetSelectList<TEnum>() where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
                       .Cast<TEnum>()
                       .Select(e => new SelectListItem
                       {
                           Value = Convert.ToInt32(e).ToString(),
                           Text = e.GetDescription()
                       }).ToList();
        }
    }
}
