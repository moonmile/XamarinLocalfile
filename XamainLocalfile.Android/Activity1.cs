using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XamarinLocalfile.Core;
using System.Xml.Linq;

namespace XamainLocalfile.Android
{
    [Activity(Label = "XamainLocalfile.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        MyData _model;
        TextView textUserName, textHighScore, textUpdated;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            FindViewById<Button>(Resource.Id.buttonLoad).Click += clickLoad;
            FindViewById<Button>(Resource.Id.buttonSave).Click += clickSave;
            textUserName = FindViewById<TextView>(Resource.Id.textUserName);
            textHighScore = FindViewById<TextView>(Resource.Id.textHighScore);
            textUpdated = FindViewById<TextView>(Resource.Id.textUpdated);

            _model = new MyData();
        }

        /// <summary>
        /// ファイルロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void clickLoad(object sender, EventArgs e)
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
        /// <summary>
        /// ファイル保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void clickSave(object sender, EventArgs e)
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
    }
}

