using ETrade.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string? RePassword { get; set; }
        public string? Role { get; set; }
        public bool Error { get; set; }
        public string? Msg { get; set; }
        public User? User { get; set; }
        public User Map()
        {
            User usr = new User();
            usr.Id = Id;
            usr.Mail = Mail;
            usr.Password = Password;
            usr.Role = Role;
            return usr;
        }
    }
}
