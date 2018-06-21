using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Names.API.Models
{
	public class DisplayPersons
	{
		/// <summary>
		/// Represents the name for the Person to find withing the collection of the DisplayPeople dataset
		/// </summary>
		public string nameToId { get; set; }

		/// <summary>
		/// Represents the collection of the DisplayPeople dataset
		/// </summary>
		public List<DisplayPerson> displayPersons { get; set; }

		/// <summary>
		/// ctor for DisplayPersons model
		/// </summary>
		public DisplayPersons() { displayPersons = new List<DisplayPerson>(); }
	}
}