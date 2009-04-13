
using System;
using System.Collections.Generic;
using Ptolemy.Formats.GPX;

namespace Ptolemy.Model
{
	
	/// <summary>
	/// Implements as segment of a Track, made of GPSData
	/// </summary>
	public class GPSTrackSegment : LinkedList<GPSData>
	{
		
		public GPSTrackSegment()
		{
		}
		
		/// <summary>
		/// Creates a GPSTrackSegment object from a GPX format Track segment
		/// </summary>
		/// <param name="pGPXTrackSegment">
		/// A <see cref="trksegType"/>
		/// </param>
		public GPSTrackSegment(trksegType pGPXTrackSegment)
		{
			foreach (wptType lWayPoint in pGPXTrackSegment.trkpt)
			{
				AddLast(new GPSData(lWayPoint));
			}
		}
	}
}
