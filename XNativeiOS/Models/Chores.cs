﻿using System;

namespace XNativeiOS.Models
{
    public class Chores
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		public bool Done { get; set; }

        public Chores()
        {
        }
    }
}
