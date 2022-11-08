using Btree;

namespace BTree;

public class BTree<TValue>
    where TValue : IComparable<TValue>
{
    private NodeBtree<TValue>? _head;

    public BTree(int cellNum)
    {
        MaxRelationsInNode = cellNum;
    }
    public int MaxRelationsInNode { get; }

    public void AddNewValue(TValue value)
    {
        if (_head == null)
        {
            _head = new NodeBtree<TValue>(MaxRelationsInNode - 1, value);
        }
        else
        {
            var bottomNode = _head.SearchBottomNode(value);
            int count = bottomNode.CellInNodeCount;
            if (count + 1 != MaxRelationsInNode)
            {
                var tempCell = bottomNode.CellBtree;
                TValue tempCellValue = tempCell.Value;

                for (int i = 0; i < count; i++)
                {
                    if (value.CompareTo(tempCellValue) == -1 )
                    {
                        if (bottomNode.CellInNodeCount % 2 == 1)
                        {

                        }
                    }
                }
            }
        }
    }
}

