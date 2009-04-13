
using System;
using System.Collections.Generic;
using Ptolemy.Formats.GPX;

namespace Ptolemy.Model
{
	
	/// <summary>
	/// Encapsulates a track made of GPSTrackSegment
	/// </summary>
	public class GPSTrack : LinkedList<GPSTrackSegment>
	{
		
		public GPSTrack()
		{
		}
		
		/// <summary>
		/// Creates a GPSTrack object from a GPX format track
		/// </summary>
		/// <param name="pGPXTrack">
		/// A <see cref="trkType"/>
		/// </param>
		public GPSTrack(trkType pGPXTrack)
		{
			
			
		}
	}
}
