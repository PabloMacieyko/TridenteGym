using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requests
{
    public class UpdateEnrollmentRequest
    {
        public int ActivityId { get; set; }
        public int ClientId { get; set; }
    }
}
