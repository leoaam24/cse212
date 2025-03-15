public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }


    /// <summary>
    /// Removes a value from the array
    /// However, the value with the highest priority number is removed first regardless of their position in the array
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public string Dequeue()
    {
        if (_queue.Count == 0) // Verify the queue is not empty
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority to remove
        // Assign variables to determine the highest priorty index and it's accompanying number/value
        var highPriorityIndex = 0;
        var highPriorityNumber = 0;
        var duplicatePriorityIndex = 0;
        var duplicatePriorityNumber = 0;
        for (int index = 0; index < _queue.Count - 1; index++)
        {
            if (_queue[index].Priority > highPriorityNumber)
            {
                highPriorityNumber = _queue[index].Priority;
                highPriorityIndex = index;
            }
            if (_queue[index].Priority == highPriorityNumber)
            {
                duplicatePriorityNumber = _queue[index].Priority;
                duplicatePriorityIndex = index;
            }
                
        }

        // Remove and return the item with the highest priority
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}