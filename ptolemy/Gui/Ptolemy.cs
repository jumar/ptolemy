using System.Drawing;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using System.IO;
namespace Ptolemy.Gui
{
	public class Ptolemy : Form
	{
		private static readonly ILog sLOGGER = log4net.LogManager.GetLogger(typeof(Ptolemy));
		
		public Ptolemy()
		{
			Text = "Ptolemy";
      	 	Size = new Size(250, 200);
       		CenterToScreen();
       		

		}
		
		public static void Main (string[] args)
		{
			Init();
			sLOGGER.Info("Ptolemy Starting");
			Application.Run(new Ptolemy());
		}
		
		/// <summary>
		/// Performs basic initialization such as log4net config file parsing
		/// </summary>
		public static void Init()
		{
			FileInfo lLog4netConfigFIle = new FileInfo(Directory.GetCurrentDirectory() + "/../../conf/log4net.xml");
			if(!lLog4netConfigFIle.Exists)
			{
				System.Console.WriteLine("[ERROR] Cannot find log4net config file at following path: " + lLog4netConfigFIle.FullName);
			}
			XmlConfigurator.Configure(lLog4netConfigFIle);
		}
	}
}