using System;
using System.Collections.Generic;

namespace Core.Shared.Models.Entities
{
    public class ScheduleModel : BaseModel<ScheduleModel>
    {
        public DateTime? Date { get; set; }
        public virtual ICollection<AppointmentModel> Appointments { get; set; }
    }
}