using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Android.OS;
using Android.Locations;
using Android.Provider;
using System.Collections.Generic;
using Java.IO;
using Java.Util;
using Java.Text;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;
using System.Text.RegularExpressions;
using System.Web;


namespace Fielder
{

	public static class App{
		public static Java.IO.File _file;
		public static Java.IO.File _dir;     
		public static Bitmap bitmap;
		public static String vehicleId;
		public static Stack<HistoryData> historyList = new Stack<HistoryData>();
	}
		
	[Activity (Label = "Surveyor", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		public const String BASEDIR = "Om2SurveyAPP";
		const String BEFORECAPTURE = "Before";
		const String AFTERCAPTURE = "After";
		const String DURINGCAPTURE = "During";
		const int REQUESTCODEBEFORE = 1;
		const int REQUESTCODEDURING = 2;
		const int REQUESTCODEAFTER = 3;
		public string VehicleID { get; set;}

		public override bool OnKeyDown (Keycode keyCode, KeyEvent e)
		{
			var myWebView = FindViewById<WebView> (Resource.Id.webView);
			if(e.Action == KeyEventActions.Down){
				switch(keyCode)
				{
				case Keycode.Back:
					if(myWebView.CanGoBack()){
						if (App.historyList.Count > 1) {
							App.historyList.Pop ();
							var last = App.historyList.Peek ();
							this.RenderMethods (myWebView, last.Method, last.Parameters);
						}else{
							Finish ();
						}
					}else{
						Finish();
					}
					return true;
				}

			}
			return base.OnKeyDown (keyCode, e);
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			RequestWindowFeature (WindowFeatures.NoTitle);
			RequestedOrientation = ScreenOrientation.Portrait;
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var webView = FindViewById<WebView> (Resource.Id.webView);
			webView.Settings.JavaScriptEnabled = true;
			webView.Settings.JavaScriptCanOpenWindowsAutomatically = true;
			//webView.Settings.BuiltInZoomControls = true;
			webView.Settings.DomStorageEnabled = true;
			webView.Settings.AllowUniversalAccessFromFileURLs =true;
			webView.Settings.AllowFileAccessFromFileURLs = true;
			// Use subclassed WebViewClient to intercept hybrid native calls
			webView.SetWebViewClient (new HybridWebViewClient ());
			webView.Settings.SetGeolocationEnabled(true);
			webView.SetWebChromeClient(new GeoWebChromeClient());
			//webView.AddJavascriptInterface
			var jsHandler = new JavaScriptHandler (this);
			webView.AddJavascriptInterface (jsHandler, "callMainActivity");

			// Load the rendered HTML into the view with a base URL 
			// that points to the root of the bundled Assets folder
		//	webView.LoadDataWithBaseURL ("file:///android_asset/", page, "text/html", "UTF-8", null);
			//webView.LoadUrl ("http://www.google.com");


			//dispatchTakePictureIntent (webView);

			var baseDir = Helpers.GetBaseDirectory (Environment.ExternalStorageDirectory);

			RenderLoginView (webView);
			//RenderJobDetailsView (webView, "MD2343", "asdasdsad");


		}	

		/*public static void Compress(DirectoryInfo directorySelected)
		{
			foreach (FileInfo fileToCompress in directorySelected.GetFiles())
			{
				using (FileStream originalFileStream = fileToCompress.OpenRead())
				{
					if ((System.IO.File.GetAttributes(fileToCompress.FullName) & 
						FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
					{
						using (FileStream compressedFileStream = System.IO.File.Create(fileToCompress.FullName + ".gz"))
						{
							using (GZipStream compressionStream = new GZipStream(compressedFileStream, 
								CompressionMode.Compress))
							{
								originalFileStream.CopyTo(compressionStream);

							}
						}
						FileInfo info = new FileInfo(directoryPath + "\\" + fileToCompress.Name + ".gz");
					}

				}
			}
		}*/

		public void setToast(String s) {
			Toast.MakeText (this, s, ToastLength.Short);
		}
		public  Bitmap scaleDown(Bitmap realImage, float maxImageSize, Boolean filter) {
			float ratio = Math.Min(
				(float) maxImageSize / realImage.Width,
				(float) maxImageSize / realImage.Height);
			int width = (int) Math.Round((float) ratio * realImage.Width);
			int height = (int) Math.Round((float) ratio * realImage.Height);

			Bitmap newBitmap = Bitmap.CreateScaledBitmap(realImage, width,
				height, filter);
			return newBitmap;
		}

		public string createCompressedBitmap() {
			Bitmap imageBitmap = BitmapFactory.DecodeFile (App._file.Path);
			Bitmap scaledBitmap = scaleDown (imageBitmap, 600, true);
			var newPath = App._file.Parent + "/1_" + App._file.Name;
			System.IO.FileStream fOut = new System.IO.FileStream(newPath, System.IO.FileMode.OpenOrCreate);
			scaledBitmap.Compress (Bitmap.CompressFormat.Jpeg, 100, fOut);
			fOut.Flush ();
			fOut.Close ();
			System.IO.File.Delete (App._file.Path);
			return newPath;
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			//base.OnActivityResult(requestCode, resultCode, data);
			if (requestCode == REQUESTCODEBEFORE) {
				if (resultCode == Result.Ok) {
					//Bundle extras = data.Extras;
					//Bitmap imageBitmap = (Bitmap)extras.Get ("data");
					var webView = FindViewById<WebView> (Resource.Id.webView);
					var newPath = createCompressedBitmap ();
					var js = string.Format ("SetImage('{0}', '{1}');", newPath, BEFORECAPTURE);
					webView.LoadUrl ("javascript:" + js);
				} else
					App._file.Delete();
			}
				
			if (requestCode == REQUESTCODEDURING) {
				if (resultCode == Result.Ok) {
					//Bundle extras = data.Extras;
					//Bitmap imageBitmap = (Bitmap)extras.Get ("data");
					var webView = FindViewById<WebView> (Resource.Id.webView);
					var newPath = createCompressedBitmap ();
					var js = string.Format ("SetImage('{0}', '{1}');", newPath, DURINGCAPTURE);
					webView.LoadUrl ("javascript:" + js);
				} else
					App._file.Delete();
			}

			if (requestCode == REQUESTCODEAFTER) {
				if (resultCode == Result.Ok) {
					//Bundle extras = data.Extras;
					//Bitmap imageBitmap = (Bitmap)extras.Get ("data");
					var webView = FindViewById<WebView> (Resource.Id.webView);
					var newPath = createCompressedBitmap ();
					var js = string.Format ("SetImage('{0}', '{1}');", newPath, AFTERCAPTURE);
					webView.LoadUrl ("javascript:" + js);
				} else
					App._file.Delete();
			}
		}
			

		private void RenderLoginView(WebView webView)
		{
			// Render the view from the type generated from RazorView.cshtml
			var model = new LoginDetails () { Username = "", Password = "" };
			var template = new LoginView () { Model = model };
			var page = template.GenerateString ();	
			webView.LoadDataWithBaseURL ("file:///android_asset/login", page, "text/html", "UTF-8", null);
		}


		private void RenderMainView(WebView webView, string json)
		{

			//Read Jobs.json file for existing list of jobs
			var baseDir = Helpers.GetBaseDirectory (Environment.ExternalStorageDirectory);
			var jobsJson = System.IO.File.ReadAllText (baseDir.Path + "/jobs.json");

			// Render the view from the type generated from RazorView.cshtml
			var model = new Model1 () { Text = "Lead List", VehicleId = App.vehicleId, JobsJSON = jobsJson, JSON = json };
			var template = new MainView () { Model = model };
			var page = template.GenerateString ();		
			webView.LoadDataWithBaseURL ("file:///android_asset/Main", page, "text/html", "UTF-8", null);

			var jsHandler = new JavaScriptHandler (this);
			webView.AddJavascriptInterface (jsHandler, "callMainActivity");
			/*LocationManager lm = null;
			Boolean gps_enabled = false,network_enabled = false;

			if(lm==null)
				lm = (LocationManager) GetSystemService(Context.LocationService);
			//try{
				gps_enabled = lm.IsProviderEnabled(LocationManager.GpsProvider);
			//}catch(Exception ex){}
			//try{
				network_enabled = lm.IsProviderEnabled(LocationManager.NetworkProvider);
			//}catch(Exception ex){}


			Intent gpsOptionsIntent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);  
			this.StartActivity (gpsOptionsIntent);*/
		}

		private void RenderJobDetailsView(WebView webView, String jobId, String _id, string json)
		{
			// Render the view from the type generated from RazorView.cshtml
			var model = new JobData () { JobID = jobId, _id = _id, JSON = json };
			var template = new JobDetails () { Model = model };
			var page = template.GenerateString ();	
			webView.LoadDataWithBaseURL ("file:///android_asset/Job", page, "text/html", "UTF-8", null);
		}

		private void RenderCompleteJobView(WebView webView, String jobId, String _id, String signLabel, String json)
		{
			// Render the view from the type generated from RazorView.cshtml
			var model = new JobData () { JobID = jobId, _id = _id, SignatureLabel = signLabel, JSON =  json};
			var template = new CompleteJobView () { Model = model };
			var page = template.GenerateString ();	
			webView.LoadDataWithBaseURL ("file:///android_asset/Sign", page, "text/html", "UTF-8", null);
		}

		public void RenderMethods(WebView webView, String method,  System.Collections.Specialized.NameValueCollection parameters) {
			if (method == "LoginSuccess") {
				var vId = parameters ["vehicleId"];
				App.vehicleId = vId;
				var act = (MainActivity)webView.Context;
				act.RenderMainView (webView, "");
			}  else if (method == "openJob") {
				var act = (MainActivity)webView.Context;
				act.RenderJobDetailsView (webView, parameters ["jobId"], parameters ["_id"], parameters ["json"]);
				//dispatchTakePictureIntent (webView);
			} else if (method == "OkJob") {
				var act = (MainActivity)webView.Context;
				act.RenderMainView (webView, parameters ["json"]);
			} else if (method == "CompleteJob") {
				var act = (MainActivity)webView.Context;
				//act.RenderCompleteJobView (webView, parameters ["jobId"], parameters ["_id"], "Installer", parameters ["json"]);
				App.historyList.Clear ();
				act.RenderMainView (webView, parameters ["json"]);
			} else if (method == "GotSignature") {
				var finalDir = Helpers.GetJobDirectory (Environment.ExternalStorageDirectory, parameters ["_id"]);				
				var data = HttpUtility.UrlDecode (parameters ["sign"]);
				var base64Data = Regex.Match(data, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
				//base64Data = base64Data.Replace ("|", "=");
				base64Data = base64Data.Replace (" ", "+");
				var binData = Convert.FromBase64String(base64Data);
				var signLabel = parameters ["signatureLabel"];
				/*var image = Java.IO.File.CreateTempFile(
					signLabel + "_sign",  // prefix 
					".jpg",         // suffix 
					finalDir       //directory 
				);
				System.IO.File.WriteAllBytes (image.Path, binData);*/
				using (var imageFile = new System.IO.FileStream(finalDir.Path + "/" + signLabel + "_sign.jpeg", System.IO.FileMode.OpenOrCreate))
					{
						imageFile.Write(binData ,0, binData.Length);
						imageFile.Flush();
					}
				var act = (MainActivity)webView.Context;
				if (signLabel == "Installer")
					act.RenderCompleteJobView (webView, parameters ["jobId"], parameters ["_id"], "Customer", parameters ["json"]);
				else {
					//act.RenderMainView (webView);
					act.RenderMainView (webView, parameters ["json"]);
				}
			}
		}

		private class HybridWebViewClient : WebViewClient
		{
		
			//public void Openfile
			public override bool ShouldOverrideUrlLoading (WebView webView, string url)
			{

				// If the URL is not our own custom scheme, just let the webView load the URL as usual
				var scheme = "hybrid:";

				if (!url.StartsWith (scheme))
					return false;
				//dispatchTakePictureIntent (webView);

				// This handler will treat everything between the protocol and "?"
				// as the method name.  The querystring has all of the parameters.
				var resources = url.Substring (scheme.Length).Split ('?');
				var method = resources [0];
				var parameters = System.Web.HttpUtility.ParseQueryString (resources [1]);
				if (method == "LoginSuccess" || method == "openJob" || method == "OkJob"
				    || method == "CompleteJob" || method == "GotSignature") {
					App.historyList.Push (new HistoryData{ Method = method, Parameters = parameters });
					var act = (MainActivity)webView.Context;
					act.RenderMethods (webView, method, parameters);
				} else if (method == "saveJSON") {
					var baseDir = Helpers.GetBaseDirectory (Environment.ExternalStorageDirectory);
					System.IO.File.WriteAllText (baseDir.Path + "/jobs.json", parameters ["json"]);
				} else if (method == "BeforePicture") {
					dispatchTakePictureIntent (webView, parameters ["_id"], BEFORECAPTURE);
				} else if (method == "DuringPicture") {
					dispatchTakePictureIntent (webView, parameters ["_id"], DURINGCAPTURE);
				} else if (method == "AfterPicture") {
					dispatchTakePictureIntent (webView, parameters ["_id"], AFTERCAPTURE);
				} else if (method == "BeforeDialog") {
					var id = parameters ["_id"];
					sendImagesforDialog (webView, id, BEFORECAPTURE, "SetImages");
				} else if (method == "AfterDialog") {
					var id = parameters ["_id"];
					sendImagesforDialog (webView, id, AFTERCAPTURE, "SetImages");
				} else if (method == "DuringDialog") {
					var id = parameters ["_id"];
					sendImagesforDialog (webView, id, DURINGCAPTURE, "SetImages");
				} else if (method == "GetImagesToPost") {
					var id = parameters ["_id"];
					sendAllImagesforJob (webView, id, "PostImages");
				}

				return true;

			}	

			private string getFileNames(File finalDir, String name) {
				String names = "";
				if (finalDir.Exists()) {
					foreach (File f in finalDir.ListFiles()) {
						names += f.AbsolutePath + "?" + name + ";";
					}
				}
				return names;
			}


			private void sendAllImagesforJob(WebView webView, String id, string methodName) {
				var jobDir = Helpers.GetJobDirectory (Environment.ExternalStorageDirectory, id);
				var finalDir = new File (jobDir, BEFORECAPTURE);
				var names = getFileNames (finalDir, BEFORECAPTURE);
				finalDir = new File (jobDir, DURINGCAPTURE);
				names += getFileNames (finalDir, DURINGCAPTURE);
				finalDir = new File (jobDir, AFTERCAPTURE);
				names += getFileNames (finalDir, AFTERCAPTURE);
				names += jobDir.Path + "/Installer_sign.jpeg?InstallerSign;";
				names += jobDir.Path + "/Customer_sign.jpeg?CustomerSign;";
				if (names.Length > 1)
					names = names.Remove (names.Length - 1);
				var js = string.Format (methodName + "('{0}', '{1}');", names, id);
				webView.LoadUrl ("javascript:" + js);
			}

			private void sendImagesforDialog(WebView webView, String id, String captureStage, string methodName) {
				var finalDir = Helpers.GetJobDirectory (Environment.ExternalStorageDirectory, id);
				finalDir = new File (finalDir, captureStage);

				String names = "";
				if (finalDir.Exists()) {
					foreach (File f in finalDir.ListFiles()) {
						names += f.AbsolutePath + ";";
					}
					if (names.Length > 1)
						names = names.Remove (names.Length - 1);
				}
				var js = string.Format (methodName + "('{0}', '{1}');", names, captureStage);
				webView.LoadUrl ("javascript:" + js);
			}

			String mCurrentPhotoPath;

			private Java.IO.File createImageFile(Context context,String jobID, String captureStage) {
				// Create an image file name
				String timeStamp = new SimpleDateFormat("yyyyMMdd_HHmmss").Format(new Date());
				String imageFileName = "JPEG_" + timeStamp + "_";
				var finalDir = Helpers.GetJobDirectory (Environment.ExternalStorageDirectory, jobID);
				finalDir = new File (finalDir, captureStage);
				if (!finalDir.Exists())
					finalDir.Mkdir ();

				var image = Java.IO.File.CreateTempFile(
					imageFileName,  /* prefix */
					".jpg",         /* suffix */
					finalDir      /* directory */
				);

				// Save a file: path for use with ACTION_VIEW intents
				mCurrentPhotoPath = "file:" + image.AbsolutePath;
				return image;
			}

			private void dispatchTakePictureIntent(WebView webview, String jobID, String captureStage) {
				Intent takePictureIntent = new Intent(MediaStore.ActionImageCapture);
				if (IsThereAnAppToTakePictures(webview)) {
					File photoFile = null;
					try {
						photoFile = createImageFile(webview.Context,jobID, captureStage);
					} catch  {
						// Error occurred while creating the File
						//	...
					}
					// Continue only if the File was successfully created
					if (photoFile != null) {
						takePictureIntent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(photoFile));
						var act = (Activity)webview.Context;
						//webview.Context.StartActivity(takePictureIntent);
						App._file = photoFile;
						int req = 0;
						if (captureStage == BEFORECAPTURE)
							req = REQUESTCODEBEFORE;
						else if (captureStage == DURINGCAPTURE)
							req = REQUESTCODEDURING;
						else if (captureStage == AFTERCAPTURE)
							req = REQUESTCODEAFTER;
						act.StartActivityForResult (takePictureIntent, req);

					}
				}
			}

			private bool IsThereAnAppToTakePictures(WebView webview)
			{
				Intent intent = new Intent(MediaStore.ActionImageCapture);

				IList<ResolveInfo> availableActivities;
				availableActivities = webview.Context.PackageManager.QueryIntentActivities (intent, PackageInfoFlags.MatchDefaultOnly);
				return availableActivities != null && availableActivities.Count > 0;
			}

			//static int REQUEST_IMAGE_CAPTURE = 1;		
		}

		/**
     * WebChromeClient subclass handles UI-related calls
     * Note: think chrome as in decoration, not the Chrome browser
     */
		public class GeoWebChromeClient : WebChromeClient {
			public override void OnGeolocationPermissionsShowPrompt(String origin,
				GeolocationPermissions.ICallback callback) {
				// Always grant permission since the app itself requires location
				// permission and the user has therefore already granted it
				callback.Invoke(origin, true, false);

			}
		}


		public class JavaScriptHandler : Java.Lang.Object {

			MainActivity parentActivity;
			public JavaScriptHandler(MainActivity activity) {
				parentActivity = activity;
			}

			[JavascriptInterface()]
			public void setResult(string jobsJSON){    
				this.parentActivity.setToast("yes");

			}

			public void calcSomething(int x, int y){
				//this.parentActivity.changeText("Result is : " + (x * y));
			}
		}
						
	}
}

