
using System;
using Ptolemy.Formats.GPX;
using log4net;
using log4net.Config;
namespace Ptolemy.Model
{	
	/// <summary>
	/// Represents a Generic GPS data point. Including latitude, longitide, elevation
	/// and other basic information defining a GPS point.
	/// </summary>
	public class GPSData
	{
		private static readonly ILog sLogger = log4net.LogManager.GetLogger(typeof(GPSData));
		
		#region properties & private fields
		/// <value>
		/// Latitude of the point
		/// </value>
		private decimal aLat;
		public decimal Lat
		{
			get{ return aLat; }
			set{ aLat = value; }
		}
		/// <value>
		/// Longitude of the point 
		/// </value>
		private decimal aLng;
		public decimal Lng
		{
			get{ return aLng; }
			set{ aLng = value; }
		}
		/// <value>
		/// Elevation of the point
		/// </value>
		private decimal aElev;
		public decimal Elev
		{
			get{ return aElev; }
			set{ aElev = value; }
		}
		/// <value>
		/// Name associated to the point
		/// </value>
		private String aName;
		public String Name
		{
			get{ return aName; }
			set{ aName = value; }
		}
		/// <value>
		/// User given comment associated to the point 
		/// </value>
		private String aComment;
		public String Comment
		{
			get{ return aComment; }
			set{ aComment = value; }
		}
		/// <value>
		/// User given comment description to the point 
		/// </value>
		private String aDesc;
		public String Desc
		{
			get{ return aDesc; }
			set{ aDesc = value; }
		}
		/// <value>
		/// Creation time of the point 
		/// </value>
		private DateTime aTime;
		public DateTime Time
		{
			get{ return aTime; }
			set{ aTime = value; }
		}
		#endregion properties & private fields
		
		#region constructors
		
		public GPSData()
		{
		
		}
		/// <summary>
		/// Creates a GPS Data with given lat, long and elevation
		/// </summary>
		public GPSData(decimal pLat, decimal pLng, decimal pElev)
		{
			mInit(pLat, pLng, pElev);
		}
		
		/// <summary>
		/// Creates a GPS Data with given lat, long, elevation, name, comment, description and creation time
		/// </summary>
		public GPSData(decimal pLat, decimal pLng, decimal pElev, String pName, String pComment, String pDesc, DateTime pTime)
		{
			mInit(pLat, pLng, pElev, pName, pComment, pDesc, pTime);
		}
		
		/// <summary>
		/// Creates a GPSData object based on the given GPX waypoint
		/// </summary>
		/// <param name="pGPXWaypoint">
		/// A <see cref="wptType"/>
		/// </param>
		public GPSData(wptType pGPXWaypoint)
		{
			if(pGPXWaypoint == null)
			{
				sLogger.Warn("Trying to build a GPSData from a null GPX waypoint");
			}
			else
			{
				mInit(pGPXWaypoint.lat, pGPXWaypoint.lon, pGPXWaypoint.ele, pGPXWaypoint.name, pGPXWaypoint.cmt, pGPXWaypoint.desc, pGPXWaypoint.time);
			}
		}
		
		#endregion constructors
		
		#region public methods
		/// <summary>
		/// Prints the point latitude, longitude and altitude
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		public String toString()
		{
			return "lat " + aLat + ", lng " + aLng + ", alt " + aElev;
		}
		#endregion public methods
		
		#region private methods
		private void mInit(decimal pLat, decimal pLng, decimal pElev)
		{
			aLat = pLat;
			aLng = pLng;
			aElev = pElev;
		}
		
		private void mInit(decimal pLat, decimal pLng, decimal pElev, String pName, String pComment, String pDesc, DateTime pTime)
		{
			mInit(pLat, pLng, pElev);
			aName = pName;
			aComment = pComment;
			aDesc = pDesc;
			aTime = pTime;
		}
		#endregion private methods
	}
}
