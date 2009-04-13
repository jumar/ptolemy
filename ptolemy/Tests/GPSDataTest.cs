
using System;
using System.Xml.Serialization;
using System.IO;
using NUnit.Framework;
using Ptolemy.Model;
using Ptolemy.Formats.GPX;
using log4net;
using log4net.Config;

namespace Ptolemy
{
	
	
	[TestFixture()]
	public class GPSDataTest
	{
	
		private static readonly ILog sLogger = log4net.LogManager.GetLogger(typeof(GPSDataTest));
		public static gpxType sGPXInfo;
		
		[SetUp]
    	public void Init()
    	{
	      	XmlSerializer lSerializer = new XmlSerializer(typeof(gpxType));
			using (FileStream lStream = new FileStream("../../data/Gare de prevost.gpx", FileMode.Open))
      		{
        		sGPXInfo = (gpxType)lSerializer.Deserialize(lStream);
	      	}
    	}
    	
		[Test()]
		public void TestConstructor()
		{
			const decimal lLat = 45.8724776m;
			const decimal lLng = -74.0754513m;
			decimal lElev = 432.3m;
			// Simple constructor
			GPSData lPoint = new GPSData(lLat, lLng, lElev);
			Assert.AreEqual(lLat, lPoint.Lat, "Lat nok");
			Assert.AreEqual(lLng, lPoint.Lng, "Lng nok");
			Assert.AreEqual(lElev, lPoint.Elev, "alt nok");
			// with null parameter
			lPoint = new GPSData(null);
			Assert.AreEqual(0, lPoint.Lat, "Lat nok");
			Assert.AreEqual(0, lPoint.Lng, "Lng nok");
			Assert.AreEqual(0, lPoint.Elev, "alt nok");
			// with correct parameter
			lElev = 0m;
			const String lName = "Gare de Prévost";
			const String lDesc = "Départ des sentiers";
			const String lComment = "Rue de la Traverse";
			lPoint = new GPSData(sGPXInfo.wpt[0]);
			Assert.AreEqual(lLat, lPoint.Lat, "Lat nok");
			Assert.AreEqual(lLng, lPoint.Lng, "Lng nok");
			Assert.AreEqual(lElev, lPoint.Elev, "alt nok");
			Assert.AreEqual(lName, lPoint.Name, "name nok");
			Assert.AreEqual(lComment, lPoint.Comment, "comment nok");
			Assert.AreEqual(lDesc, lPoint.Desc, "desc nok");
		}
		
	}
}
