package crc6454fa219b8be6d876;


public class EditActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("XA_SQlite_LoginApp.EditActivity, XA_SQlite_LoginApp", EditActivity.class, __md_methods);
	}


	public EditActivity ()
	{
		super ();
		if (getClass () == EditActivity.class)
			mono.android.TypeManager.Activate ("XA_SQlite_LoginApp.EditActivity, XA_SQlite_LoginApp", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
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
