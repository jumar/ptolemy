
using System;
using System.Xml.Serialization;
using System.IO;
using NUnit.Framework;
using Ptolemy.Model;
using Ptolemy.Formats.GPX;

namespace ptolemy.Tests
{
	
	
	[TestFixture()]
	public class GPSTrackTest
	{
		public static gpxType sGPXInfo;
		
		[SetUp]
    	public void Init()
    	{
	      	XmlSerializer lSerializer = new XmlSerializer(typeof(gpxType));
			using (FileStream lStream = new FileStream("../../data/Default.gpx", FileMode.Open))
      		{
        		sGPXInfo = (gpxType)lSerializer.Deserialize(lStream);
	      	}
    	}
    	
		[Test()]
		public void TestConstructors()
		{
			Assert.IsNotEmpty(sGPXInfo.trk, "Precondition failed: no track in test file");
			GPSTrack lTrk = new GPSTrack(sGPXInfo.trk[0]);
			Assert.AreEqual(sGPXInfo.trk[0].trkseg.Length, lTrk.Segments.Count, "Track has not the expected size");
			lTrk = new GPSTrack(null);
			Assert.IsNotNull(lTrk, "GPSTrack constructor with null parameter failed");
		}
		
		[Test()]
		public void TestPrint()
		{
			Assert.IsNotEmpty(sGPXInfo.trk, "Precondition failed: no track in test file");
			GPSTrack lTrk = new GPSTrack(sGPXInfo.trk[0]);
			System.Console.Write(lTrk.ToString());
		}
	}
}
