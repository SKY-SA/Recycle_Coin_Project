using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserDetailsDto : IDto
    {
        public int UserId { get; set; }
        public string UserAddress { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Balance { get; set; }
    }
}
