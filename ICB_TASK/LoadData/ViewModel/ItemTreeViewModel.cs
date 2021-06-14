using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICB_TASK.LoadData.ViewModel
{
    public class ItemTreeViewModel : INotifyPropertyChanged 
    {
    static readonly ItemTreeViewModel DummyChild = new ItemTreeViewModel();
    readonly ObservableCollection<ItemTreeViewModel> _children;
    readonly ItemTreeViewModel _parent;
    bool _isExpanded;
    bool _isSelected;

    protected ItemTreeViewModel(ItemTreeViewModel parent, bool lazyLoadChildren)
    {
        _parent = parent;

        _children = new ObservableCollection<ItemTreeViewModel>();

        if (lazyLoadChildren )
            _children.Add(DummyChild);
    }


    private ItemTreeViewModel()
    {
    }


    public ObservableCollection<ItemTreeViewModel> Children
    {
        get { return _children; }
    }


    public bool HasDummyChild
    {
        get { return this.Children.Count == 1 && this.Children[0] == DummyChild; }
    }


    public bool IsExpanded
    {
        get { return _isExpanded; }
        set
        {
            if (value != _isExpanded)
            {
                _isExpanded = value;
                this.OnPropertyChanged("IsExpanded");
            }

        
            if (_isExpanded && _parent != null)
                _parent.IsExpanded = true;

            // Lazy load the child items, if necessary.
            if (this.HasDummyChild)
            {
                this.Children.Remove(DummyChild);
                this.LoadChildren();
            }
        }
    }


    public bool IsSelected
    {
        get { return _isSelected; }
        set
        {
            if (value != _isSelected)
            {
                _isSelected = value;
                this.OnPropertyChanged("IsSelected");
            }
        }
    }


    protected virtual void LoadChildren()
    {
    }



    public ItemTreeViewModel Parent
    {
        get { return _parent; }
    }



    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

  
}
}
