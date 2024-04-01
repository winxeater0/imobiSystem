using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace imobiSystem.Utils
{
    public static class StringExtension
    {
        public static string CheckObjAsString(object obj, string str)
        {
            if (obj == null)
                return str;
            else
                return JsonSerializer.Serialize(obj);
        }
    }
}
