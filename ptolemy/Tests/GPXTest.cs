
using System;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using Ptolemy.Formats.GPX;
using log4net;
using log4net.Config;

namespace Ptolemy.Tests
{	
	//[TestFixture()]
	public class GPXTest
	{
		private static readonly ILog sLogger = log4net.LogManager.GetLogger(typeof(GPXTest));
		
		//[SetUp]
    	public void Init()
    	{
	      	 XmlConfigurator.Configure(new System.IO.FileInfo("../../conf/log4net.xml"));
    	}

		//[Test()]
		public void TestGPX()
		{
			sLogger.Info("Starting GPX test case");
			XmlSerializer lSerializer = new XmlSerializer(typeof(gpxType));
			using (FileStream lStream = new FileStream("../../data/Default.gpx", FileMode.Open))
      		{
        		gpxType lGPXInfo = (gpxType)lSerializer.Deserialize(lStream);

        		foreach(wptType lWayPOint in lGPXInfo.wpt)
        		{
        			OutputWayPoint(lWayPOint);
        		}
        		if (lGPXInfo.trk != null)
		        {
		          	OutputTracks(lGPXInfo.trk);
		        }
	      	}
		}
		
		static void OutputWayPoint(wptType pWayPoint)
		{
			Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}m", pWayPoint.name, pWayPoint.cmt, pWayPoint.desc, pWayPoint.time, pWayPoint.lat, pWayPoint.lon, pWayPoint.ele);
		}
		
		static void OutputTracks(trkType[] pTracks)
    	{
      		Console.WriteLine("{0} Tracks", pTracks.Length);
      		Assert.AreEqual(1, pTracks.Length, "Wrong number of tracks");
		    foreach (trkType lTrack in pTracks)
		    {
		        OutputTrack(lTrack);
		    }
    	}
    
    	static void OutputTrack(trkType pTrack)
    	{
      		Console.WriteLine("Track ’{0}’", pTrack.name);
      		if (pTrack.trkseg.Length > 0)
      		{
		        Console.WriteLine("{0} segments", pTrack.trkseg.Length);
		        foreach (trksegType lSegment in pTrack.trkseg)
		        {
			          Console.WriteLine("{0} Points", lSegment.trkpt.Length);
			          foreach (wptType lWayPoint in lSegment.trkpt)
			          {
			           		OutputWayPoint(lWayPoint);
			          }
		        }
     		}
    }

	}
}
