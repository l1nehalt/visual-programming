namespace lab_1;

public static class Task6
{
    public static int CountElements(int[] m)
    {
        int count = 0;

        for (int i = 0; i < m.Length; i++)
        {
            if (m[i] > 0 && m[i] < 125)
            {
                count++;
            }
        }
        
        return count;
    }
}