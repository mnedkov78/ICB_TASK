using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICB_TASK.LoadData.ViewModel
{
    public class SubitemViewModel : ItemTreeViewModel
    {
        readonly SubItem _subitem;
      

        public SubitemViewModel(SubItem subitem)
            : base(null, true)
        {

            _subitem = subitem;
         
        }

        public string ItemDetails
        {
            // get { return "SubItem  ID: " + _subitem.ID + " | Subid: " + _subitem.Subid; }
            get { return _subitem.Subid; }
        }

        protected override void LoadChildren()
        {

            DataTable dt = new DataTable("ItemVersion");

            string commandtext = "select  * from ItemVersion where  (StrComp(Item_ID, '"+ _subitem.ID + "') = 0) Order by ItemReleaseDate";
            
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
                    Version = row["Version"].ToString(),
                    Item_ID = row["Item_ID"].ToString(),
                    ItemReleaseDate = row["ItemReleaseDate"].ToString()
                };
                if (string.IsNullOrEmpty(item.ID)) continue;
                base.Children.Add(new ItemVersionViewModel(item, _subitem.Subid.ToString())
                {
                });
            }

        }
    }
}
