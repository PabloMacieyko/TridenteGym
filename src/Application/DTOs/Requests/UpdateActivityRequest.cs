﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requests
{
    public class UpdateActivityRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProfessorId { get; set; }
        public int Price { get; set; }
        public int AvailableSlots { get; set; }
    }
}
