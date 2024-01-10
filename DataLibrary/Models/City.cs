using System;
using System.Collections.Generic;

namespace DataLibrary.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Guest> Guest { get; set; } = new List<Guest>();
}
