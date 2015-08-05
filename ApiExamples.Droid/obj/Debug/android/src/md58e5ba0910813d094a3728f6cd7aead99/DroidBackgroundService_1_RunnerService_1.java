package md58e5ba0910813d094a3728f6cd7aead99;


public class DroidBackgroundService_1_RunnerService_1
	extends android.app.Service
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onBind:(Landroid/content/Intent;)Landroid/os/IBinder;:GetOnBind_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("ApiExamples.Droid.Services.DroidBackgroundService`1/RunnerService`1, ApiExamples.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DroidBackgroundService_1_RunnerService_1.class, __md_methods);
	}


	public DroidBackgroundService_1_RunnerService_1 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DroidBackgroundService_1_RunnerService_1.class)
			mono.android.TypeManager.Activate ("ApiExamples.Droid.Services.DroidBackgroundService`1/RunnerService`1, ApiExamples.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public android.os.IBinder onBind (android.content.Intent p0)
	{
		return n_onBind (p0);
	}

	private native android.os.IBinder n_onBind (android.content.Intent p0);

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
