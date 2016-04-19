﻿		 
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Common.DDD;

namespace TimeKeep.TimeSheets
{
	public class EntryState : Entity
    {
		public Int32 ProjectNumber { get; set; } 
		public String Comment { get; set; } 
		public DateTime TimePeriod_Start { get; set; } 
		public DateTime TimePeriod_End { get; set; } 
		public TimeSpan TimePeriod_Duration { get; set; } 
	}
}
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
