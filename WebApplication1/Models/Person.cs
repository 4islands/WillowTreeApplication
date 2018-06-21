using System;

namespace Names.API.Models
{
	/// <summary>
	/// Represents the data associated with a person as returned as a portiono of the WillowTree People dataset
	/// </summary>
	public class Person
	{
		/// <summary>
		/// Represents a unique identifier for the Person withing the WillowTree People dataset
		/// </summary>
		public string id { get; set; }
		
		/// <summary>
		/// Represents the type of entity, for our purposes in this class it will always be 'Person'
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// Represents a composit of the first and last name of the person, separated by a hyphen
		/// </summary>
		public string slug { get; set; }

		/// <summary>
		/// Represents the Person's job title
		/// </summary>
		public string jobTitle { get; set; }

		/// <summary>
		/// Represents the first name of the Person
		/// </summary>
		public string firstName { get; set; }

		/// <summary>
		/// Represents the last name of the Person
		/// </summary>
		public string lastName { get; set; }

		/// <summary>
		/// Represents the image data associated with the Person
		/// </summary>
		public Headshot headshot { get; set; }

		/// <summary>
		/// Represents an array of social links associated with the Person
		/// </summary>
		public SocialLink[] socialLinks { get; set; }
	}
}