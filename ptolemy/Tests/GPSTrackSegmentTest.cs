
using System;
using System.Xml.Serialization;
using System.IO;
using NUnit.Framework;
using Ptolemy.Model;
using Ptolemy.Formats.GPX;
using log4net;
using log4net.Config;

namespace ptolemy.Test
{
	
	[TestFixture()]
	public class GPSTrackSegmentTest
	{
	
		private static readonly ILog sLogger = log4net.LogManager.GetLogger(typeof(GPSTrackSegmentTest));
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
		public void TestCase()
		{
		}
	}
}
