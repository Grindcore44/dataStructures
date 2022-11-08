public static class Program
{
    public static void Main()
    {
        var dataStructures = new Stack<string>(); // при инициализации прописывается тип данных
        dataStructures.Push("World");
        dataStructures.Push("Hello");

        Console.WriteLine(dataStructures.Pop());
        Console.WriteLine(dataStructures.Pop());
    }
}

public class Stack<T> //where T: struct //при инициалиции данного класса, пользователь сам выбирает какой тип данных
                                      //  where T: - указывает какие типы должны быть
{
    private T[] _stack;
    private int _countOnHead;

    public Stack()
    {
        _stack = new T[2];
        _countOnHead = 0;
    }

    public void Push (T data) 
    {
        if (_countOnHead >= _stack.Length)
        {
            Array.Resize(ref _stack, _stack.Length * 2);
        }

        _stack[_countOnHead] = data;
        _countOnHead += 1;
    }

    public T Pop()
    {
        T value = _stack[_countOnHead - 1];
        _countOnHead = _countOnHead - 1;
        return value;
    }

    public void Drop()
    {
        _countOnHead = _countOnHead - 1;
    }

    public void Swap()
    {
        T headValue = _stack[_countOnHead - 2];
        _stack[_countOnHead - 2] = _stack[_countOnHead - 1];
        _stack[_countOnHead - 1] = headValue;
    }

    public void Duplicate()
    {
        T value = _stack[_countOnHead - 1];
        Push(value);
    }

    public void Over()
    {
        T value = _stack[_countOnHead - 2];
        Push(value);
    }

    public void Rol()
    {
        int temp = _countOnHead / 2;
        for (int i = 0; i < temp; i++)
        {
            T beginValue = _stack[i];
            T endValue = _stack[_countOnHead - 1 - i];
            _stack[i] = endValue;
            _stack[_countOnHead - 1 - i] = beginValue;
        }
    }

    public void Nip()
    {
        Swap();
        Drop();
    }
}