using System;
using System.Collections.Generic;

namespace DataLibrary.Models;

public partial class Bed
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Room> Room { get; set; } = new List<Room>();
}
