using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.Models
{
    public enum DataOperation
    {
        Edit,
        Delete
    }

    public static class BlogHelper
    {
        public static bool VerifyAuther(string blogUserLogin, ClaimsPrincipal currentUser)
        {
            if (blogUserLogin != null && currentUser != null)
            {
                if (currentUser.IsInRole("admin"))
                    return true;
                if (blogUserLogin == currentUser.Identity.Name)
                    return true;
            }

            return false;
        }

        public static bool VerifyOperation(string blogUserLogin, ClaimsPrincipal currentUser, DataOperation dataOperation)
        {
            if (VerifyAuther(blogUserLogin, currentUser))
            {
                //This block goes for future expansion like adding more roles and restrict their operation types
                return true;
            }
            return false;
        }

        public static byte[] ImageToByteArray(IFormFile image)
        {
            if (image != null)
            {
                if (image.Length > 0)
                {
                    byte[] byteImage = null;
                    using (var fileStream = image.OpenReadStream())
                    using (var memoryStream = new MemoryStream())
                    {
                        fileStream.CopyTo(memoryStream);
                        byteImage = memoryStream.ToArray();
                    }
                    return byteImage;
                }
            }
            return null;
        }
    }
}
