using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree;

public class HeadManipulator<TValue>
    where TValue : IComparable<TValue>
{
    private BinaryNodeTree<TValue> _head;
    public void AddNewValue(TValue value)
    {
        if (_head == null)
        {
            _head = new BinaryNodeTree<TValue>(value);
        }
        else
        {
            _head = _head.AddNewValue(value);
        }
    }

    public void DeleteNode(TValue value)
    {
        _head = _head.DeleteNode(value);
    }

    public bool SearchNode(TValue value)
    { 
        return _head.SearchNode(value);
    }

}