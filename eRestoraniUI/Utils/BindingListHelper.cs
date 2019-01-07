using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoraniUI.Utils
{
    public class BindingListHelper<T> // generic helper klasa za hendlanje bindling lista (gridovi, cmb isl...)
    {
        private BindingList<T> bindingList { get; set; }
        private BindingSource bindingSource { get; set; }
        // --
        public BindingListHelper()
        {
            bindingList = new BindingList<T>();
            bindingSource = new BindingSource();
        }
        public BindingListHelper(List<T> list)
        {
            bindingSource = new BindingSource();
            this.SetList(list);
        }
        //--
        public BindingSource Source
        {
            get { return bindingSource; }
        }


        public BindingList<T> GetList()
        {
            return bindingList;
        }

        public void SetList(List<T> list)
        {
            bindingList = new BindingList<T>(list);
            bindingSource.DataSource = bindingList;
        }

        public void Add(T obj)
        {
            this.bindingList.Add(obj);
        }
        public void Remove(T obj)
        {
            this.bindingList.Remove(obj);
        }

        public bool Contains(T obj)
        {
            return this.bindingList.Contains(obj);
        }
    }
}
