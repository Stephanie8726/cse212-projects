public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
  {
        // ================= PLAN =================
        // 1. Create a new array of doubles with the size equal to 'length'.
        // 2. Loop through each index i from 0 to length - 1.
        // 3. For each index, calculate the multiple as number * (i + 1).
        //    Example: number = 3, length = 5 → 
        //    i=0 → 3*1=3, i=1 → 3*2=6, i=2 → 3*3=9, i=3 → 3*4=12, i=4 → 3*5=15
        // 4. Store the calculated multiple in the array at index i.
        // 5. After the loop ends, return the filled array.
        // =======================================

        // ================== CODE ==================
        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
{
        // ================== PLAN ==================
        // 1. The task is to move elements to the right by 'amount'.
        // 2. Which means the last 'amount' elements should move to the front.
        //    Example: [1,2,3,4,5,6,7,8,9], amount=3 → last 3 → [7,8,9].
        // 3. Find the split index: data.Count - amount.
        //    Example: count=9, amount=3 → split=6.
        // 4. Use GetRange to slice the last part of the list (from split to end).
        // 5. Use GetRange to slice the first part of the list (from 0 to split-1).
        // 6. Clear the original list.
        // 7. Add the last part first, then add the first part.
        // 8. The list is now rotated in place.
        // ==========================================

        // ================== CODE ==================
        int split = data.Count - amount;
        List<int> lastPart = data.GetRange(split, amount);
        List<int> firstPart = data.GetRange(0, split);

        data.Clear();
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}
