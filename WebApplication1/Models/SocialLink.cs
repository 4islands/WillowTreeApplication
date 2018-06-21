using System;

namespace Names.API.Models
{
	/// <summary>
	/// Represents a social link as returned as a portiono of the WillowTree People dataset
	/// </summary>
	public class SocialLink
	{	
		/// <summary>
		/// Gets or sets the type of this social link
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// Gets or sets a prompt text for this social link
		/// </summary>
		public string callToAction { get; set; }

		/// <summary>
		/// Gets or sets URL for this social link
		/// </summary>
		public Uri RequestUri { get; set; }
	}
}