using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
namespace XamarinLocalfile.Core
{
    /// <summary>
    /// シリアライズ可能なデータモデル
    /// </summary>
    public class MyData : BindableBase
    {
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { this.SetProperty(ref this._UserName, value); }
        }
        // 最高点
        private int _HighScore;
        public int HighScore
        {
            get { return _HighScore; }
            set { this.SetProperty(ref this._HighScore, value); }
        }
        // 更新日
        private DateTime _Updated;
        public DateTime Updated
        {
            get { return _Updated; }
            set { this.SetProperty(ref this._Updated, value); }
        }

        public MyData()
        {
            // デザイン用の初期値
            UserName = "Your name";
            HighScore = 10;
            Updated = new DateTime(2014, 4, 10);
        }

        public XDocument ToXDoc()
        {
            var doc = new XDocument();
            doc.Add(
                new XElement("MyData",
                new XElement("UserName", this.UserName),
                new XElement("HighScore", this.HighScore.ToString()),
                new XElement("Updated", this.Updated.ToString())));
            return doc;
        }
        public void FromXDoc( XDocument doc )
        {
            this.UserName = doc.Descendants("UserName").First().Value;
            this.HighScore = int.Parse( doc.Descendants("HighScore").First().Value);
            this.Updated = DateTime.Parse(doc.Descendants("Updated").First().Value);
        }
    }
}
