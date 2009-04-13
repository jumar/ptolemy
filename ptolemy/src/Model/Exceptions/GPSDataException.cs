using System;
using Ptolemy.Model;

namespace ptolemy.Model.Exceptions
{
	/// <summary>
	/// This class represents a generic exception related to a GPSData object
	/// </summary>
	public class GPSDataException : Exception
	{
		/// <value>
		/// Reference to the object that raised the exception
		/// </value>
		private GPSData aGPSData;
		public GPSData GPSData
		{
			get
			{
				return aGPSData;
			}
		}
		
		public GPSDataException(GPSData pData)
		{
			aGPSData = pData;
		}
	}
}
