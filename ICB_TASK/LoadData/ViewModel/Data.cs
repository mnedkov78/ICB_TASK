using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICB_TASK.LoadData.ViewModel
{
    class Data
    {
    }
    public class Item
    {
        public string ID { get; set; }
        public string Item_id { get; set; }
        public string item_name { get; set; }
    }

    public class ItemVersion
    {
        public string ID { get; set; }
        public string Version { get; set; }
        public string Item_ID { get; set; }
        public string ItemReleaseDate { get; set; }

    }

    public class ItemVersion2Subitem
    {
        public string ID { get; set; }
        public string ItemVersionID { get; set; }
        public string SubItemID { get; set; }
    }

    public class SubItem
    {
        public string ID { get; set; }
        public string Subid { get; set; }
    }


}
