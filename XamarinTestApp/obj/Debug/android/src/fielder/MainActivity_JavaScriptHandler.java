package fielder;


public class MainActivity_JavaScriptHandler
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Fielder.MainActivity/JavaScriptHandler, Surveyor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainActivity_JavaScriptHandler.class, __md_methods);
	}


	public MainActivity_JavaScriptHandler () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainActivity_JavaScriptHandler.class)
			mono.android.TypeManager.Activate ("Fielder.MainActivity/JavaScriptHandler, Surveyor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public MainActivity_JavaScriptHandler (fielder.MainActivity p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainActivity_JavaScriptHandler.class)
			mono.android.TypeManager.Activate ("Fielder.MainActivity/JavaScriptHandler, Surveyor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Fielder.MainActivity, Surveyor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
