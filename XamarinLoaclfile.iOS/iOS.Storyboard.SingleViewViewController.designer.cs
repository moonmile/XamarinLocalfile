// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace XamarinLoaclfile.iOS
{
	[Register ("iOS_Storyboard_SingleViewViewController")]
	partial class iOS_Storyboard_SingleViewViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField textHighScore { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField textUpdated { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField textUserName { get; set; }

		[Action ("clickSave:")]
		partial void clickSave (MonoTouch.Foundation.NSObject sender);

		[Action ("clikLoad:")]
		partial void clikLoad (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (textUserName != null) {
				textUserName.Dispose ();
				textUserName = null;
			}

			if (textHighScore != null) {
				textHighScore.Dispose ();
				textHighScore = null;
			}

			if (textUpdated != null) {
				textUpdated.Dispose ();
				textUpdated = null;
			}
		}
	}
}
