using System.Collections;

namespace lab_4;

public class DynamicArrayEnumerator<T> : IEnumerator<T>
{
    private T[] _array;
    private int _count;
    private int _position = -1;

    public DynamicArrayEnumerator(T[] array, int count)
    {
        _array = array;
        _count = count;
    }

    public T Current
    {
        get
        {
            if (_position < 0 || _position >= _count)
                throw new InvalidOperationException();
            return _array[_position];
        }
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        _position++;
        return _position < _count;
    }

    public void Reset()
    {
        _position = -1;
    }

    public void Dispose()
    {
    }
}