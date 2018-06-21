using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NameGameUI.Models
{
	public class Colleagues
	{
		/// <summary>
		/// Represents the name for the Person to find within the collection of the Colleague dataset
		/// </summary>
		public string nameToId { get; set; }

		/// <summary>
		/// Represents the name slug for the Person to find within the collection of the Colleague dataset
		/// </summary>
		public string slugToId { get; set; }

		/// <summary>
		/// Represents the collection of the Colleague dataset
		/// </summary>
		public List<Colleague> colleagues { get; set; }

		/// <summary>
		/// ctor for Colleagues model
		/// </summary>
		public Colleagues() { colleagues = new List<Colleague>(); }
	}
}