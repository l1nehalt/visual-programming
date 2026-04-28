namespace lab_9;

public static class CollectionExtensions
{
    public static IEnumerable<TResult> SelectProperty<TSource, TResult>(this IEnumerable<TSource> source, 
        Func<TSource, TResult> selector)
    {
        foreach (var item in source)
        {
            yield return selector(item);
        }
    }
    
    public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, 
        Func<TSource, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<TSource> FindByLetter<TSource>(this IEnumerable<TSource> source, 
        Func<TSource, string> predicate, char targetLetter)
    {
        foreach (var item in source)
        {
            if (predicate(item).Contains(targetLetter))
            {
                yield return item;
            }
        }
    }
    
    public static IEnumerable<TSource> ExecuteAction<TSource>(this IEnumerable<TSource> source, 
        Action<TSource> action)
    {
        foreach (var item in source)
        {
            action(item);
            yield return item;
        }
    }

    public static IEnumerable<TSource> TakeByRange<TSource>(this IEnumerable<TSource> source,
        Func<TSource, int> selector, int start, int end)
    {
        foreach (var item in source)
        {
            var value = selector(item);
            
            if (value >= start && value <= end)
            {
                yield return item;
            }
        }
    }
}