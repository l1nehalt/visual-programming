using System.Collections;

namespace lab_4;

public class DynamicArray<T> : IEnumerable<T>
{
    private T[] _items;
    
    public int Count { get; private set; }
    public int Capacity => _items.Length;

    public DynamicArray()
    {
        _items = new T[20];
        Count = 0;
    }

    public DynamicArray(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Емкость должна быть положительной");
        
        _items = new T[capacity];
        Count = 0;
    }

    public void Add(T element)
    {
        if (Count == Capacity)
        {
            IncreaseCapacity(1);
        }
        
        _items[Count] = element;
        Count++;
    }

    public void Add(IEnumerable<T> elements)
    {
        if (elements == null)
            throw new ArgumentNullException(nameof(elements));

        int elementsCount = 0;
        foreach (var element in elements)
        {
            elementsCount++;
        }

        if (Count + elementsCount > Capacity)
        {
            IncreaseCapacity((Count + elementsCount) - Capacity);
        }

        foreach (var element in elements)
        {
            _items[Count] = element;
            Count++;
        }
    }

    public void Insert(T element, int position)
    {
        if (position < 0 || position > Count)
            throw new IndexOutOfRangeException("Позиция вне диапазона");

        if (Count == Capacity)
        {
            IncreaseCapacity(1);
        }

        for (int i = Count; i > position; i--)
        {
            _items[i] = _items[i - 1];
        }

        _items[position] = element;
        Count++;
    }

    public void RemoveAt(int position)
    {
        if (position < 0 || position >= Count)
            throw new IndexOutOfRangeException("Позиция вне диапазона");

        for (int i = position; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[Count - 1] = default(T);
        Count--;
    }

    public void IncreaseCapacity(int n)
    {
        if (n <= 0)
            throw new ArgumentException("Количество элементов должно быть положительным");

        T[] newArray = new T[Capacity + n];
        
        for (int i = 0; i < Count; i++)
        {
            newArray[i] = _items[i];
        }

        _items = newArray;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new DynamicArrayEnumerator<T>(_items, Count);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            return _items[index];
        }
    }
}
