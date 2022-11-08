namespace Btree;
public class NodeBtree<TValue>
    where TValue : IComparable<TValue>
{
    public NodeBtree(int maxRelationsOfNode, TValue value)
    {
        MaxRelationsOfNode = maxRelationsOfNode;
        CellBtree = new CellBTree<TValue>(value);
    }

    public NodeBtree(int maxRelationsOfNode, CellBTree<TValue> cell)
    {
        MaxRelationsOfNode = maxRelationsOfNode;
        CellBtree = cell;
    }
    public int MaxRelationsOfNode { get; }
    public CellBTree<TValue> CellBtree { get; private set; }
    public int CellInNodeCount => CellCount();
    public NodeBtree<TValue>? ParentNode;


    public NodeBtree<TValue> AddNewValueInNode(CellBTree<TValue> newCell)
    {
        if (CellInNodeCount < MaxRelationsOfNode - 1)
        {
            AddNewCellInNotFullNode(newCell);
            return this;
        }

        else
        {
            CellBTree<TValue> cell = DivideNode(newCell);
            if (ParentNode == null)
            {
                NodeBtree<TValue> newNode = new NodeBtree<TValue>(MaxRelationsOfNode, cell);
                cell.LeftNode.ParentNode = newNode;
                cell.RightNode.ParentNode = newNode;
                return newNode;
            }

            ParentNode = ParentNode.AddNewValueInNode(newCell);
        }

        return this;
    }

    public CellBTree<TValue> DivideNode(CellBTree<TValue> medianCell)
    {
        CellBTree<TValue> cell = CellBtree.NextCell;

        NodeBtree<TValue> leftNode = new NodeBtree<TValue>(MaxRelationsOfNode, CellBtree.Value);
        NodeBtree<TValue> rightNode = new NodeBtree<TValue>(MaxRelationsOfNode, GetCellByIndex(MaxRelationsOfNode - 2).Value);

        while (cell != null)
        {
            if (medianCell.Value.CompareTo(cell.Value) == 1)
            {
                leftNode.AddNewCellInNotFullNode(cell);
            }
            else
            {
                if (cell.NextCell == null)
                {
                    break;
                }
                rightNode.AddNewCellInNotFullNode(cell);
            }
            cell = cell.NextCell;
        }
        medianCell.LeftNode = leftNode;
        medianCell.RightNode = rightNode;
        return medianCell;
    }

    public int CellCount()
    {
        var tempNodeBtree = CellBtree;
        int count = 0;
        while (tempNodeBtree != null)
        {
            count += 1;
            tempNodeBtree = tempNodeBtree.NextCell;
        }

        return count;
    }
    public CellBTree<TValue> GetCellByIndex(int index)
    {
        if (index < 0 || index >= MaxRelationsOfNode - 1)
        {
            throw new ArgumentOutOfRangeException();
        }

        CellBTree<TValue> cell = CellBtree;

        for (int i = 0; i < index; i++)
        {
            cell = cell.NextCell;
        }

        return cell;
    }

    public CellBTree<TValue> GetMedianValue(CellBTree<TValue> newCell)
    {
        if (CellInNodeCount % 2 == 0)
        {
            if (newCell.Value.CompareTo(CellBtree.Value) == -1)
            {
                int indexNode = (CellInNodeCount / 2) - 1;
                CellBTree<TValue> cell = GetCellByIndex(indexNode);
                CellBtree = DeleteCellInNode(cell.Value);
                CellBtree = AddNewCellInNotFullNode(newCell);
                return cell;
            }

            else if (newCell.Value.CompareTo(GetCellByIndex(CellInNodeCount - 1).Value) == 1 ||
                newCell.Value.CompareTo(GetCellByIndex(CellInNodeCount - 1).Value) == 0)
            {
                int indexNode = (CellInNodeCount / 2) + 1;
                CellBTree<TValue> cell = GetCellByIndex(indexNode);
                CellBtree = DeleteCellInNode(cell.Value);
                CellBtree = AddNewCellInNotFullNode(newCell);
                return cell;
            }

            else
            {
                int leftMiddleIndex = CellInNodeCount / 2 - 1;
                int rightMiddleIndex = CellInNodeCount / 2 + 1;
                if (newCell.Value.CompareTo(GetCellByIndex(leftMiddleIndex).Value) == -1)
                {
                    CellBTree<TValue> cell = GetCellByIndex(leftMiddleIndex);
                    CellBtree = DeleteCellInNode(cell.Value);
                    CellBtree = AddNewCellInNotFullNode(newCell);
                    return cell;
                }
                else if ((newCell.Value.CompareTo(GetCellByIndex(rightMiddleIndex).Value) == 1) || 
                    (newCell.Value.CompareTo(GetCellByIndex(rightMiddleIndex).Value) == 0))
                {
                    CellBTree<TValue> cell = GetCellByIndex(rightMiddleIndex);
                    CellBtree = DeleteCellInNode(cell.Value);
                    CellBtree = AddNewCellInNotFullNode(newCell);
                    return cell;
                }
                else
                {
                    return newCell;
                }
            }
        }
        else
        {
            if (newCell.Value.CompareTo(GetCellByIndex((CellInNodeCount / 2) - 1).Value) == 1 &&
                newCell.Value.CompareTo(GetCellByIndex((CellInNodeCount / 2) + 1).Value) == -1)
            {
                return newCell;
            }
            else
            {
                int indexNode = (CellInNodeCount / 2); // CellInNodeCount = 3, return cell index 1 ( second cell)
                CellBTree<TValue> cell = GetCellByIndex(indexNode);
                CellBtree = DeleteCellInNode(cell.Value);
                CellBtree = AddNewCellInNotFullNode(newCell);
                return cell;
            }
        }
    }

    public NodeBtree<TValue> SearchBottomNode(TValue value)
    {

        var currentCell = CellBtree;
        for (int i = 0; i < CellInNodeCount; i++)
        {
            int compareResult = value.CompareTo(currentCell.Value);

            if (currentCell.LeftNode == null && currentCell.RightNode == null)
            {
                return this;
            }

            if (compareResult == -1)
            {
                return currentCell.LeftNode.SearchBottomNode(value);
            }

            if (compareResult == 0)
            {
                return currentCell.RightNode.SearchBottomNode(value);
            }

            if (compareResult == 1 && currentCell.NextCell == null)
            {
                return currentCell.RightNode.SearchBottomNode(value);
            }

            if (compareResult == 1 && value.CompareTo(currentCell.NextCell.Value) == -1)
            {
                return currentCell.RightNode.SearchBottomNode(value);
            }

            if (compareResult == 1 && value.CompareTo(currentCell.NextCell.Value) == 1)
            {
                currentCell = currentCell.NextCell;
            }
        }

        return this;
    }

    public CellBTree<TValue> AddNewCellInNotFullNode(CellBTree<TValue> cell)
    {

        CellBTree<TValue> currentCell = CellBtree;
        int compareResult = cell.Value.CompareTo(currentCell.Value);

        if (compareResult == -1)
        {
            return CellBtree = CellBtree.AddFirstCell(cell);
        }
        else if (currentCell.NextCell != null)
        {
            
            for (int i = 1; i < CellInNodeCount; i++)
            {
                int compareNextCellResult = cell.Value.CompareTo(currentCell.NextCell.Value);
                if (compareResult == 1 && (compareNextCellResult == -1 || compareNextCellResult == 0))
                {
                    return CellBtree.AddCellByIndex(cell, i);
                }
                currentCell = currentCell.NextCell;
                compareResult = compareNextCellResult;

                if (currentCell.NextCell == null)
                {
                    return CellBtree.AddLastCell(cell);
                }
            }
        }
        return CellBtree.AddLastCell(cell);
    }
  
    public CellBTree<TValue> DeleteCellInNode(TValue value)
    {
        CellBTree<TValue> cell = CellBtree;
        int compareResult = value.CompareTo(cell.Value);
        if (compareResult == 0)
        {
            return CellBtree = CellBtree.NextCell;
        }

        int count = 0;
        while (compareResult != 0)
        {
            cell = cell.NextCell;
            compareResult = value.CompareTo(cell.Value);
            count += 1;
        }

        CellBtree.DeleteNotHeadCellByIndex(count);

        return CellBtree;
    }
}
