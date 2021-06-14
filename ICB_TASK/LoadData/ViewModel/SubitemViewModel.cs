using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICB_TASK.LoadData.ViewModel
{
    public class SubitemViewModel:ItemTreeViewModel
    {
        readonly SubItem _subitem;

        public SubitemViewModel(SubItem subitem)
            : base(null, false)
        {
            _subitem = subitem;
        }

        public string SubItemDetails
        {
            get { return "SubItem  ID: " + _subitem.ID+ " | Subid: " + _subitem.Subid; }
        }
    }
}
