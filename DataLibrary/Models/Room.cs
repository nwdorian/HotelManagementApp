using System;
using System.Collections.Generic;

namespace DataLibrary.Models;

public partial class Room
{
    public int Id { get; set; }

    public int BedId { get; set; }

    public int NumBeds { get; set; }

    public int Number { get; set; }

    public int Floor { get; set; }

    public virtual Bed Bed { get; set; } = null!;

    public virtual ICollection<RoomReservation> RoomReservation { get; set; } = new List<RoomReservation>();
}
