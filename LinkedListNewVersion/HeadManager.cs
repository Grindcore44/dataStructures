namespace LinkedListNewVersion;

public class HeadManager<TValue>
    where TValue : IComparable<TValue>
{
    public LinkedListUniversal<TValue> _head;

    public void AddFirst(TValue value)
    {
        if (_head == null)
        {
            _head = new LinkedListUniversal<TValue>(value);
        }
        else
        {
            var temp = _head;
            _head = new LinkedListUniversal<TValue>(value, temp, null);
            _head.NextNode.PreviousNode = _head;
        }
    }
    public void AddLast(TValue value)
    {
        if (_head == null)
        {
            _head = new LinkedListUniversal<TValue>(value);
        }
        else
        {
            if (_head.NextNode == null)
            {
                _head.NextNode = new LinkedListUniversal<TValue>(value, null, _head);
            }
            else
            {
                var temp = _head.NextNode;
                for (int i = _head.QuantityNode(); i > 1; i--)
                {
                    if (temp.NextNode == null)
                    {
                        temp.NextNode = new LinkedListUniversal<TValue>(value, null, temp);
                    }
                    else
                    {
                        temp = temp.NextNode;
                    }
                }
            }
        }
    }

}
