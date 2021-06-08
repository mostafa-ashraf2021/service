using System;
using System.Collections.Generic;
using System.Text;

namespace ContextLib.Entites
{
    public class UserService
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string UserName { get; set; }
        public Service Service { get; set; }
    }
}
