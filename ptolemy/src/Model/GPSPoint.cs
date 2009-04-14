
using System;
using System.Text;
using Ptolemy.Formats.GPX;
using log4net;

namespace Ptolemy.Model
{	
	/// <summary>
	/// Represents a Generic GPS data point. Including latitude, longitide, elevation
	/// and other basic information defining a GPS point.
	/// </summary>
	public class GPSPoint : GPSData
	{
		private static readonly ILog sLogger = log4net.LogManager.GetLogger(typeof(GPSPoint));
		
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
		
		public GPSPoint()
		{
		
		}
		/// <summary>
		/// Creates a GPS Data with given lat, long and elevation
		/// </summary>
		public GPSPoint(decimal pLat, decimal pLng, decimal pElev)
		{
			mInit(pLat, pLng, pElev);
		}
		
		/// <summary>
		/// Creates a GPS Data with given lat, long, elevation, name, comment, description and creation time
		/// </summary>
		public GPSPoint(decimal pLat, decimal pLng, decimal pElev, String pName, String pComment, String pDesc, DateTime pTime)
		: base(pName, pComment, pDesc)
		{
			mInit(pLat, pLng, pElev, pTime);
		}
		
		/// <summary>
		/// Creates a GPSPoint object based on the given GPX waypoint
		/// </summary>
		/// <param name="pGPXWaypoint">
		/// A <see cref="wptType"/>
		/// </param>
		public GPSPoint(wptType pGPXWaypoint)
		: base( pGPXWaypoint != null ? pGPXWaypoint.name : null, pGPXWaypoint != null ? pGPXWaypoint.cmt : null, pGPXWaypoint != null ? pGPXWaypoint.desc : null)
		{
			if(pGPXWaypoint == null)
			{
				sLogger.Warn("Building a GPSPoint from a null GPX waypoint");
			}
			else
			{
				mInit(pGPXWaypoint.lat, pGPXWaypoint.lon, pGPXWaypoint.ele, pGPXWaypoint.time);
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
		public String ToString()
		{
			StringBuilder lStr = new StringBuilder();
			lStr.Append("Type: " + GetType().ToString());
			lStr.AppendLine();
			lStr.Append(base.ToString());
			lStr.Append("lat " + aLat + ", lng " + aLng + ", alt " + aElev);
			return lStr.ToString();
		}
		#endregion public methods
		
		#region private methods
		private void mInit(decimal pLat, decimal pLng, decimal pElev)
		{
			aLat = pLat;
			aLng = pLng;
			aElev = pElev;
		}
		
		private void mInit(decimal pLat, decimal pLng, decimal pElev, DateTime pTime)
		{
			mInit(pLat, pLng, pElev);
			aTime = pTime;
		}
		#endregion private methods
	}
}
