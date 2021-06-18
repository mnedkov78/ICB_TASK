using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICB_TASK.LoadData.ViewModel
{
    public class ItemVersionViewModel : ItemTreeViewModel
    {

        readonly ItemVersion _ItemVersion;
        readonly string _Parent;

        public ItemVersionViewModel(ItemVersion itemversion,string  Versionparemt)
            : base(null, true)
        {
            _ItemVersion = itemversion;
            _Parent = Versionparemt;
        }

        public string ItemDetails
        {
           //get { return "ItemVersion ID: " + _ItemVersion.ID+" | Version: "+ _ItemVersion.Version + "  | Item_ID : " + _ItemVersion.Item_ID + " |  ItemReleaseDate: " + _ItemVersion.ItemReleaseDate; }
            get { return _Parent+" / "+ _ItemVersion.Version; }
        }

        protected override void LoadChildren()
        {
            /*
        
            DataTable dt = new DataTable("ItemVersion2Subitem");

            string commandtext = "select  * from ItemVersion2Subitem where ItemVersionID =" + _ItemVersion.ID;
            using (OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\PLM.TEST.mdb"))
            {
                using (OleDbCommand cmd = new OleDbCommand(commandtext, cn))
                {
                    cn.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }


            foreach (DataRow row in dt.Rows)
            {
                var item = new ItemVersion2Subitem
                {
                    ID = row["ID"].ToString(),
                    ItemVersionID = row["ItemVersionID"].ToString(),
                    SubItemID = row["SubItemID"].ToString()
                };
                if (string.IsNullOrEmpty(item.ID)) continue;
                base.Children.Add(new ItemVersion2SubitemViewModel(item));
            }
            */

            DataTable dt = new DataTable("SubItem");

            string commandtext = "select  * from SubItem where ID in (" + "select  ItemVersion2Subitem.SubItemID from ItemVersion2Subitem where ItemVersionID =" + _ItemVersion.ID +")";
            using (OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\PLM.TEST.mdb"))
            {
                using (OleDbCommand cmd = new OleDbCommand(commandtext, cn))
                {
                    cn.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }


            foreach (DataRow row in dt.Rows)
            {
                var item = new SubItem
                {
                    ID = row["ID"].ToString(),
                    Subid = row["Subid"].ToString(),

                };
                if (string.IsNullOrEmpty(item.ID)) continue;
                base.Children.Add(new SubitemViewModel(item));
            }
        }
    }
}
