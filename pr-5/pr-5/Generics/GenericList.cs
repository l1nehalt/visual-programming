namespace pr_5.Generics;

public class GenericList<T> where T : IComparable<T>
{
    private List<T> _list = [];

    public void Add(T item)
    {
        _list.Add(item);
    }

    public void BubbleSort()
    {
        for (int i = 0; i < _list.Count - 1; i++)
        {
            for (int j = 0; j < _list.Count - i - 1; j++)
            {
                if (_list[j].CompareTo(_list[j + 1]) > 0)
                {
                    (_list[j], _list[j + 1]) = (_list[j + 1], _list[j]);
                }
            }
        }
    }

    public void Print()
    {
        foreach (var l in _list)
        {
            Console.WriteLine(l.ToString());
        }
    }
}