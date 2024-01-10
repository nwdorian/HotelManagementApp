using System;
using System.Collections.Generic;

namespace DataLibrary.Models;

public partial class Guest
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public int CountryId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public virtual City City { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Reservation> Reservation { get; set; } = new List<Reservation>();
}
