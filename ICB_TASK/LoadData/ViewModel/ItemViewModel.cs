using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICB_TASK.LoadData.ViewModel
{
    public class ItemViewModel: ItemTreeViewModel
    {

        readonly Item _item;
       
        public ItemViewModel(Item Item)
            : base(null, true)
        {
            _item = Item;
            
        }

        

        public string ItemDetails
        {
            get { return "Item  ID: "+_item.ID+ " | Item_id: " + _item.Item_id+ " | item_name: " + _item.item_name; }
        }

        protected override void LoadChildren()
        {

            DataTable dt = new DataTable("ItemVersion");

            string commandtext = "select  * from ItemVersion where Item_ID ="+_item.ID+" Order by ItemReleaseDate" ;
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
                
         
                var item = new ItemVersion
                {
                    ID = row["ID"].ToString(),
                    Version= row["Version"].ToString(),
                    Item_ID = row["Item_ID"].ToString(),
                    ItemReleaseDate = row["ItemReleaseDate"].ToString()
                };
                if (string.IsNullOrEmpty(item.ID)) continue;
                base.Children.Add(new ItemVersionViewModel(item) { 
            });
            }
        }
    }
}
