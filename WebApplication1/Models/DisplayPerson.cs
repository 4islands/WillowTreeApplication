using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Names.API.Models
{
	public class DisplayPerson
	{
		/// <summary>
		/// Represents a unique identifier for the Person withing the WillowTree People dataset
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Represents the Person's job title
		/// </summary>
		public string jobTitle { get; set; }

		/// <summary>
		/// Represents the formatted name of the Person
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Represents the slug (formatted combined name) for the image
		/// </summary>
		public string slug { get; set; }

		/// <summary>
		/// Represents the URL for the image
		/// </summary>
		public Uri url { get; set; }

		/// <summary>
		/// Represents the image's alternate description for presentation layer
		/// </summary>
		public string alt { get; set; }

		/// <summary>
		/// Represents the display height for the image
		/// </summary>
		public int height { get; set; }

		/// <summary>
		/// Represents the display width for the image
		/// </summary>
		public int width { get; set; }
	}
}