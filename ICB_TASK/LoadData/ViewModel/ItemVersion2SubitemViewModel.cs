using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICB_TASK.LoadData.ViewModel
{
    public class ItemVersion2SubitemViewModel : ItemTreeViewModel
    {
        readonly ItemVersion2Subitem _ItemVersion2Subitem;

        public ItemVersion2SubitemViewModel(ItemVersion2Subitem itemversion2subitem)
            : base(null, true)
        {
            _ItemVersion2Subitem = itemversion2subitem;
        }

        public string ItemVersion2SubitemDetails
        {
            get { return "ItemVersion2Subitem  ID: " + _ItemVersion2Subitem.ID+ " | ItemVersionID: " + _ItemVersion2Subitem.ItemVersionID+ "  |  SubItemID:" + _ItemVersion2Subitem.SubItemID; }
        }

        protected override void LoadChildren()
        {
            DataTable dt = new DataTable("SubItem");

            string commandtext = "select  * from SubItem where ID =" + _ItemVersion2Subitem.SubItemID;
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
