using System;
using System.Collections.Generic;
using Java.IO;

namespace Fielder
{

	public class Model1
	{
		public string Text { get; set; }
		public string VehicleId { get; set; }
		public string JobsJSON { get; set;}
		public string JSON { get; set;}
	}

	public class LoginDetails
	{
		public string Username { get; set; }
		public string Password { get; set;}
	}

	public class JobData
	{
		public String JobID { get; set; }
		public String _id { get; set; }
		public String SignatureLabel { get; set; }
		public string JSON { get; set;}
	}

	public static class Helpers
	{
		public const String BASEDIR = "Om2SurveyAPP";
		public static File GetBaseDirectory(File Storage)
		{
			Java.IO.File storageDir = Storage;
			Java.IO.File baseDir = new Java.IO.File (storageDir, BASEDIR);
			if (!baseDir.Exists())
				baseDir.Mkdir ();
			if (! System.IO.File.Exists(baseDir.Path + "/jobs.json")) {
				var st = System.IO.File.Create (baseDir.Path + "/jobs.json");
				st.Close ();
			}

			return baseDir;
		}
		public static File GetJobDirectory(File Storage, String id)
		{
			Java.IO.File storageDir = Storage;
			//Java.IO.File baseDir = new Java.IO.File (storageDir, BASEDIR);
			File finalDir = new File (storageDir, BASEDIR);
			finalDir = new File (finalDir, id);
			if (!finalDir.Exists())
				finalDir.Mkdir ();
			return finalDir;
		}
	}

	public class HistoryData {
		public string Method { get; set;}
		public System.Collections.Specialized.NameValueCollection Parameters { get; set;}
	}
}

