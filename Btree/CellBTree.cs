using Btree;

public class CellBTree<TValue>
    where TValue : IComparable<TValue>
{
    public CellBTree(TValue? value)
    {
        Value = value;
    }
    public TValue Value { get; }
    public NodeBtree<TValue>? LeftNode { get; set; }
    public NodeBtree<TValue>? RightNode { get; set; }
    public CellBTree<TValue>? NextCell { get; private set; }

    public CellBTree<TValue> AddFirstCell(CellBTree<TValue> cell)
    {
        cell.NextCell = this;
        return cell;
    }

    public CellBTree<TValue> AddLastCell(CellBTree<TValue> cell)
    {
        if (NextCell != null)
        {
           return NextCell.AddLastCell(cell);
        }

        return NextCell = cell;
    }



    public CellBTree<TValue> AddCellByIndex(CellBTree<TValue> cell, int index)
    {
        if (index == 0)
        {
            return AddFirstCell(cell);
        }

        CellBTree<TValue> currentCell = this;
        for (int i = 1; i < index; i++)
        {
            currentCell = currentCell.NextCell;
        }

        if (currentCell.NextCell == null)
        {
            return AddLastCell(cell);
        }

        CellBTree<TValue> cellAfter = currentCell.NextCell;
        currentCell.NextCell = cell;
        cell.NextCell = cellAfter;
        return this;

    }

    public void DeleteNotHeadCellByIndex(int index)
    {
        CellBTree<TValue> cell = this;
        for (int i = 1; i < index; i++)
        {
            cell = cell.NextCell;
        }

        cell.NextCell = cell.NextCell.NextCell;

    }
}

