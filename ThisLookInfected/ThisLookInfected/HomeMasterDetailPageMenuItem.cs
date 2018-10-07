using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThisLookInfected
{

    public class HomeMasterDetailPageMenuItem
    {
        private string _linkText;
        public HomeMasterDetailPageMenuItem()
        {
            TargetType = typeof(HomeMasterDetailPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string LinkText {
            get
            {
                if(string.IsNullOrEmpty(this._linkText))
                {
                    return this.Title;
                } else
                {
                    return this._linkText;
                }
            }
            set
            {
                this._linkText = value;
            }
        }
        public Type TargetType { get; set; }
    }
}