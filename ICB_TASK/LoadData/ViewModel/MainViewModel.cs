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
    public class MainViewModel
    {



        private ObservableCollection<ItemViewModel> _items;//= new ObservableCollection<ItemViewModel>();
        public  MainViewModel()
        {
            _items = new ObservableCollection<ItemViewModel>();
            DataTable dt = new DataTable("Item");

            string commandtext = "select  * from Item";
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
                var item = new Item
                {
                    ID = row["ID"].ToString(),
                    Item_id = row["Item_id"].ToString(),
                    item_name = row["Item_id"].ToString()
                };
                if (string.IsNullOrEmpty(item.ID)) continue;
                ItemViewModel newitem = new ItemViewModel(item);
                _items.Add(newitem);
            }

        }

       

        public ObservableCollection<ItemViewModel> Items
        {
            get { return _items; }
        }

    }
}
