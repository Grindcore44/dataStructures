public static class Program
{
    public static void Main()
    {

    }
}


public class LinkedListUniversal<TValue>
where TValue : IComparable<TValue>
{
    public LinkedListUniversal(TValue value)
    {
        NodeValue = value;
    }
    public LinkedListUniversal(TValue value, LinkedListUniversal<TValue>? next, LinkedListUniversal<TValue>? previous)
    {
        NodeValue = value;
        NextNode = next;
        PreviousNode = previous;
    }
    public TValue NodeValue { get; }
    public LinkedListUniversal<TValue>? NextNode { get; set; }
    public LinkedListUniversal<TValue>? PreviousNode { get; set; }


    public int QuantityNode()
    { 
        int count = 1;
        count += NextNode?.QuantityNode() ?? 0;
        return count;
    }



}




