using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN212.DAL.Models
{
    public partial class Reminder
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public bool Dismissed { get; set; }
        public TimeSpan TimeInterval { get; set; }

        public virtual Task Task { get; set; }
    }
}
