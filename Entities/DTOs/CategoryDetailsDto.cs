using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CategoryDetailsDto : IDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public double Score { get; set; }
    }
}
