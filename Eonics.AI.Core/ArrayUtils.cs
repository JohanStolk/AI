namespace Eonics.AI.Core;

public static class ArrayUtils
{
    /// <summary>
    /// Finds the maximum value in an array of comparable elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The array to search.</param>
    /// <returns>The maximum value in the array.</returns>
    public static T FindMax<T>(T[] arr) where T : IComparable<T>
    {
        // Start by assuming the first element is the largest.
        T max = arr[0];

        // Iterate through the array, comparing each element to the current maximum.
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i].CompareTo(max) > 0)
            {
                // If the current element is larger than the current maximum, update the maximum.
                max = arr[i];
            }
        }

        // Return the maximum value found.
        return max;
    }


    public static T FindMaxParallel<T>(T[] arr) where T : IComparable<T>
    {
        int numThreads = Environment.ProcessorCount;
        int chunkSize = arr.Length / numThreads;
        T[] maxs = new T[numThreads];

        Parallel.For(0, numThreads, i =>
        {
            int start = i * chunkSize;
            int end = i == numThreads - 1 ? arr.Length : start + chunkSize;

            T max = arr[start];
            for (int j = start + 1; j < end; j++)
            {
                if (arr[j].CompareTo(max) > 0)
                {
                    max = arr[j];
                }
            }

            maxs[i] = max;
        });

        T maxFinal = maxs[0];
        for (int i = 1; i < numThreads; i++)
        {
            if (maxs[i].CompareTo(maxFinal) > 0)
            {
                maxFinal = maxs[i];
            }
        }

        return maxFinal;
    }


}

