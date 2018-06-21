using System;

namespace Names.API.Models
{
	/// <summary>
	/// Represents the data associated with the image as returned as a portiono of the WillowTree People dataset
	/// </summary>
	public class Headshot
	{
		/// <summary>
		/// Represents the image type, e.g. "image"
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// Represents the immage's mime type, e.g. "image/png"
		/// </summary>
		public string mimeType { get; set; }

		/// <summary>
		/// Represents the image'a identifier
		/// </summary>
		public string id { get; set; }

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