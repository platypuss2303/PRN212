using System;
using System.Collections.Generic;

namespace PRN212.DAL.Models;

public partial class Task
{
    public int Id { get; set; }

    public Guid? UserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Location { get; set; }

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string? FormattedStartDate { get; set; }

    public string? FormattedEndDate { get; set; }

    public string? FormattedStartTime { get; set; }

    public string? FormattedEndTime { get; set; }

    public bool AllDay { get; set; }

    public string? Color { get; set; }

    public string? TextColor { get; set; }

    public int? Importance { get; set; }

    public string? Reminders { get; set; }

    public string? RecurrenceRule { get; set; }

    public bool IsCompleted { get; set; }

    public virtual User? User { get; set; }
}
