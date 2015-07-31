package md58e5ba0910813d094a3728f6cd7aead99;


public class DroidBatteryService
	extends android.content.BroadcastReceiver
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("ApiExamples.Droid.Services.DroidBatteryService, ApiExamples.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DroidBatteryService.class, __md_methods);
	}


	public DroidBatteryService () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DroidBatteryService.class)
			mono.android.TypeManager.Activate ("ApiExamples.Droid.Services.DroidBatteryService, ApiExamples.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

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
