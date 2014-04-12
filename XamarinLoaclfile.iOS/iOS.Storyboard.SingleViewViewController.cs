using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using XamarinLocalfile.Core;
using System.Xml.Linq;

namespace XamarinLoaclfile.iOS
{
    public partial class iOS_Storyboard_SingleViewViewController : UIViewController
    {
        public iOS_Storyboard_SingleViewViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }
        MyData _model;

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            _model = new MyData();

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
		partial void clickSave (MonoTouch.Foundation.NSObject sender)
		{
            _model.UserName = textUserName.Text;
            _model.HighScore = int.Parse(textHighScore.Text);
            _model.Updated = DateTime.Parse(textUpdated.Text);
            var doc = _model.ToXDoc();
            var documents =
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var file = System.IO.Path.Combine(documents, "MyData.xml");
            using (var stream = System.IO.File.OpenWrite(file))
            {
                doc.Save(stream);
            }
        }

        /// <summary>
        /// ファイル読み込み
        /// </summary>
        /// <param name="sender"></param>
		partial void clikLoad (MonoTouch.Foundation.NSObject sender)
		{
            var documents =
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var file = System.IO.Path.Combine(documents, "MyData.xml");
            using (var stream = System.IO.File.OpenRead(file))
            {
                var doc = XDocument.Load(stream);
                _model.FromXDoc(doc);
            }
            textUserName.Text = _model.UserName;
            textHighScore.Text = _model.HighScore.ToString();
            textUpdated.Text = _model.Updated.ToString();
        }
    }
}

