using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Collections;
using System.Diagnostics;

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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //create a fixed array variable with determined capacity based on the user input length to store the data for return
        double[] results = new double[length];

        //loop the number and length input 
        for (int i = 0; i < length ; i++) {
                // each index item will be replaced with the result from the expression that would determine its muliple.
                //for each iteration of the length input, the number input is multiplied to the iteration + 1 since C# array is 0-index based which would start to 0,
                // instead of starting 0 * number, the first iteration will be (0 + 1) * number.  
                results[i] =  (i + 1) * number ;
            }

        return results; // replace this return statement with your own
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
        //Assigning a list variable for the list input data.
        List<int> currentList = data;
        
        //loop on the amount user input
        for (int i = 0; i < amount; i++){
            
            //create a loop that would move the first item in the list to the next index to the right.
            for (int j = 0; j < 1; j++) {
                //create a reference copy of the first item of the list and move it to the next index.
                currentList.Insert(1, currentList[j]);
                //the first item of the list is then replaced with the last item of the list 
                currentList[j] = currentList[currentList.Count-1];
                //removing the last item of the list to maintain the list size
                currentList.RemoveAt(currentList.Count-1);
            }
            
        }
    
    }

}
