using System;
using System.Collections.Generic;

namespace DataLibrary.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public int GuestId { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public virtual Guest Guest { get; set; } = null!;

    public virtual ICollection<RoomReservation> RoomReservation { get; set; } = new List<RoomReservation>();
}
