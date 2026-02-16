namespace lab_1;

public static class Task5
{
    public static int GetDifferenceMaxMin(int[] array)
    {
        int max = int.MinValue;
        int min = int.MaxValue;
            
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }

            if (array[i] < min)
            {
                min =  array[i];
            }
        }
        
        return max - min;
    }
}