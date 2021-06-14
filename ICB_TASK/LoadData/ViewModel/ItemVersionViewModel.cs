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

        public ItemVersionViewModel(ItemVersion itemversion)
            : base(null, true)
        {
            _ItemVersion = itemversion;
        }

        public string ItemVersionDetails
        {
            get { return "ItemVersion ID: " + _ItemVersion.ID+" | Version: "+ _ItemVersion.Version + "  | Item_ID : " + _ItemVersion.Item_ID + " |  ItemReleaseDate: " + _ItemVersion.ItemReleaseDate; }
        }

        protected override void LoadChildren()
        {
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
        }
    }
}
