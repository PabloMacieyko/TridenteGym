﻿
namespace Domain.Entities
{
    public class Professor : User
    {
        public IList<Activity> Activities { get; set; } = [];
    }
}
