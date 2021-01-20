using System;

namespace XCore.Models
{
    public class Task
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		public bool Done { get; set; }
    }
}
