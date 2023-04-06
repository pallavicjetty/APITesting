using APITesting.Models.Api.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITesting.Assembly
{
    public class Resources
    {
        public static T GetResource<T>() where T : class
        {
            var page = (T)Activator.CreateInstance(typeof(T));
            return page;
        }
        public UserResource userResource => GetResource<UserResource>();
    }
}
