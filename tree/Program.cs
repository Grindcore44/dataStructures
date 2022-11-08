
using tree;

public static class Program
{
    public static void Main()
    {
        var BinaryTree = new HeadManipulator<int>();


        BinaryTree.AddNewValue(666);
        BinaryTree.DeleteNode(666);


    }

}

public class BinaryNodeTree<TValue>
    where TValue : IComparable<TValue>
{
    public BinaryNodeTree(TValue value)
    {
        nodeValue = value;
    }
    public TValue nodeValue { get; }
    public BinaryNodeTree<TValue>? LeftBranch { get; set; }
    public BinaryNodeTree<TValue>? RightBranch { get; set; }

    public BinaryNodeTree<TValue> AddNewValue(TValue value)
    {
        var order = value.CompareTo(nodeValue);
        if (order >= 0)
        {
            if (RightBranch == null)
            {
                RightBranch = new BinaryNodeTree<TValue>(value);
            }
            else
            {
                RightBranch = RightBranch.AddNewValue(value);
            }
        }
        else
        {
            if (LeftBranch == null)
            {
                LeftBranch = new BinaryNodeTree<TValue>(value);
            }
            else
            {
                LeftBranch = LeftBranch.AddNewValue(value);
            }
        }

        return Balance();
    }

    public BinaryNodeTree<TValue>? DeleteNode(TValue value)
    {
        var order = value.CompareTo(nodeValue);
        if (order == 0)
        {
            if (RightBranch == null)
            {
                return LeftBranch;
            }
            else
            {
                if (RightBranch.LeftBranch == null)
                {
                    return RightBranch;
                }
                else
                {
                    var temp = RightBranch.NodeRightMostReturnAndDelite();
                    temp.RightBranch = RightBranch;
                    temp.LeftBranch = LeftBranch;
                    return temp;
                }
            }
        }
        else if (order > 0)
        {
            if (RightBranch == null)
            {
                throw new InvalidOperationException();
            }
            RightBranch = RightBranch.DeleteNode(value);
            return Balance();
        }
        else
        {
            if (LeftBranch == null)
            {
                throw new InvalidOperationException();
            }
            LeftBranch = LeftBranch.DeleteNode(value);
            return Balance();
        }

    }

    public bool SearchNode(TValue value)
    {

        var order = value.CompareTo(nodeValue);
        if (order > 0)
        {
            if (RightBranch == null)
            {
                return false;
            }
            return RightBranch.SearchNode(value);
        }
        else if (order < 0)
        {
            if (LeftBranch == null)
            {
                return false;
            }
            return LeftBranch.SearchNode(value);
        }
        else
        {
            return true;
        }
    }


    public int GetHeightMaxBranch()
    {
        if (this == null)
        {
            return 0;
        }
        int rightCount = 1;
        int leftCount = 1;

        rightCount += RightBranch?.GetHeightMaxBranch() ?? 0; // если RightBranch == null, то вернется 0

        leftCount += LeftBranch?.GetHeightMaxBranch() ?? 0; // ?? - если слева не null, то возвращаю, то что справа
                                                            // а если null, то то, что справа
        return Math.Max(rightCount, leftCount);
    }

    public BinaryNodeTree<TValue> DoubleTurnRight()
    {
        if (LeftBranch.RightBranch == null)
        {
            throw new OutOfMemoryException();
        }
        var leftBranch = LeftBranch;
        var rightBranch = RightBranch;
        var newHead = LeftBranch.RightBranch;
        var leftBranchRightRightBranch = LeftBranch.RightBranch.RightBranch;
        var leftBranchRightLeftBranch = LeftBranch.RightBranch.LeftBranch;
        newHead.RightBranch = this;
        newHead.RightBranch.LeftBranch = leftBranchRightRightBranch;
        newHead.RightBranch.RightBranch = rightBranch;
        newHead.LeftBranch = leftBranch;
        newHead.LeftBranch.RightBranch = leftBranchRightLeftBranch;

        return newHead;
    }

    public BinaryNodeTree<TValue> DoubleTurnLeft()
    {
        if (RightBranch.LeftBranch == null)
        {
            throw new OutOfMemoryException();
        }
        var leftBranch = LeftBranch;
        var rightBranch = RightBranch;
        var newHead = RightBranch.LeftBranch;
        var rightBranchLeftLeftBranch = RightBranch.LeftBranch.LeftBranch;
        var rightBranchLeftRightBranch = RightBranch.LeftBranch.RightBranch;
        newHead.LeftBranch = this;
        newHead.LeftBranch.RightBranch = rightBranchLeftLeftBranch;
        newHead.LeftBranch.LeftBranch = leftBranch;
        newHead.RightBranch = rightBranch;
        newHead.RightBranch.LeftBranch = rightBranchLeftRightBranch;

        return newHead;
    }

    private BinaryNodeTree<TValue> TurnRight()
    {
        var tempLeftBranch = LeftBranch;
        var tempLeftRightBranch = LeftBranch.RightBranch;
        LeftBranch = tempLeftRightBranch;
        tempLeftBranch.RightBranch = this;
        return tempLeftBranch;
    }

    private BinaryNodeTree<TValue> TurnLeft()
    {
        var tempRightBranch = RightBranch;
        var tempRightLeftBranch = RightBranch.LeftBranch;
        RightBranch = tempRightLeftBranch;
        tempRightBranch.LeftBranch = this;
        return tempRightBranch;
    }

    private BinaryNodeTree<TValue> Balance()
    {
        var difference = (RightBranch?.GetHeightMaxBranch() ?? 0) - (LeftBranch?.GetHeightMaxBranch() ?? 0);

        if (difference >= 2)
        {
            if ((RightBranch?.RightBranch?.GetHeightMaxBranch() ?? 0) >= (RightBranch?.LeftBranch?.GetHeightMaxBranch() ?? 0))
            {
                return TurnLeft();
            }
            else
            {
                return DoubleTurnLeft();
            }
        }
        if (difference <= -2)
        {
            if ((LeftBranch?.LeftBranch?.GetHeightMaxBranch() ?? 0) >= (LeftBranch?.RightBranch?.GetHeightMaxBranch() ?? 0))
            {
                return TurnRight();
            }
            else
            {
                return DoubleTurnRight();
            }
        }
        return this;
    }


    private BinaryNodeTree<TValue> NodeRightMostReturnAndDelite()
    {

        if (LeftBranch.LeftBranch != null)
        {
            return LeftBranch.NodeRightMostReturnAndDelite();
        }
        else if (LeftBranch.RightBranch != null)
        {
            BinaryNodeTree<TValue> temp = LeftBranch;
            LeftBranch = LeftBranch.RightBranch;
            return temp;
        }
        else
        {
            BinaryNodeTree<TValue> temp = LeftBranch;
            LeftBranch = null;
            return temp;
        }
    }

}