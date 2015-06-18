using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace IEMHRDroidApp
{
	
	public class TabActivity : Activity
	{

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Tab);

			FragmentTransaction transaction = FragmentManager.BeginTransaction();
			SlidingTabsFragment fragment = new SlidingTabsFragment();
			transaction.Replace(Resource.Id.sample_content_fragment, fragment);
			transaction.Commit();

		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
			return base.OnCreateOptionsMenu(menu);
		}

	}
}