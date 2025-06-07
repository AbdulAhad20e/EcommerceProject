using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APILayer.Services.User
{
    public class PreferenceService
    {
        public void SaveKey(HttpContext context, string keyword)
        {
            var existingKeywords = GetKeywords(context);

            if (!existingKeywords.Contains(keyword, StringComparer.OrdinalIgnoreCase))
            {
                existingKeywords.Add(keyword);
            }

            var keywordString = string.Join(",", existingKeywords);

            context.Response.Cookies.Append("Preference", keywordString, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7)
            });
        }

        public List<string> GetKeywords(HttpContext context)
        {
            var cookie = context.Request.Cookies["Preference"];

            return string.IsNullOrEmpty(cookie)
                ? new List<string>()
                : cookie.Split(',').Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        }
    }
}
