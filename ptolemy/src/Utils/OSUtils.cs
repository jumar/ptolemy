
using System;

namespace ptolemy.utils
{
	public class OSUtils
	{
		public static string GetUserHomeDirectory ()
		{
    		if ((Environment.OSVersion.Platform == PlatformID.Win32S) ||
        		(Environment.OSVersion.Platform == PlatformID.Win32Windows) ||
       			(Environment.OSVersion.Platform == PlatformID.Win32NT))
    		{
        		return Environment.GetEnvironmentVariable ("USERPROFILE");
    		}
    		else 
    		{
        		return Environment.GetEnvironmentVariable ("HOME");
   			}
		}
	}
}