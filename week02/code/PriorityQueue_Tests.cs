using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following people and their priority: FirstPrio (5), SecondPrio (4), ThirdPrio (3), FourthPrio (2), FifthPrio (1), LastPrio(0)
    // run until the queue is empty
    // Expected Result: FirstPrio, SecondPrio, ThirdPrio, FourthPrio, FifthPrio, LastPrio
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var Prio1 = new PriorityItem("FirstPrio", 5);
        var Prio2 = new PriorityItem("SecondPrio", 4);
        var Prio3 = new PriorityItem("ThirdPrio", 3);
        var Prio4 = new PriorityItem("FourthPrio", 2);
        var Prio5 = new PriorityItem("FifthPrio", 1);
        var Prio6 = new PriorityItem("LastPrio", 0);
        
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(Prio1.Value, Prio1.Priority);
        priorityQueue.Enqueue(Prio2.Value, Prio2.Priority);
        priorityQueue.Enqueue(Prio3.Value, Prio3.Priority);
        priorityQueue.Enqueue(Prio4.Value, Prio4.Priority);
        priorityQueue.Enqueue(Prio5.Value, Prio5.Priority);
        priorityQueue.Enqueue(Prio6.Value, Prio6.Priority);


        PriorityItem[] expectedResult = [Prio1, Prio2, Prio3, Prio4, Prio5, Prio6];
        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
            i++;
        }

    }

    [TestMethod]
    // Scenario: Create a queue with the following people and their priority: FirstPrio (3), SecondPrio (4), ThirdPrio (2), FourthPrio (5), FifthPrio (2), LastPrio(2)
    // Expected Result: FourthPrio, SecondPrio, FirstPrio, ThirdPrio, FifthPrio, LastPrio
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var Prio1 = new PriorityItem("FirstPrio", 3);
        var Prio2 = new PriorityItem("SecondPrio", 4);
        var Prio3 = new PriorityItem("ThirdPrio", 2);
        var Prio4 = new PriorityItem("FourthPrio", 5);
        var Prio5 = new PriorityItem("FifthPrio", 2);
        var Prio6 = new PriorityItem("LastPrio", 2);
        
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(Prio1.Value, Prio1.Priority);
        priorityQueue.Enqueue(Prio2.Value, Prio2.Priority);
        priorityQueue.Enqueue(Prio3.Value, Prio3.Priority);
        priorityQueue.Enqueue(Prio4.Value, Prio4.Priority);
        priorityQueue.Enqueue(Prio5.Value, Prio5.Priority);
        priorityQueue.Enqueue(Prio6.Value, Prio6.Priority);


        PriorityItem[] expectedResult = [Prio4, Prio2, Prio1, Prio3, Prio5, Prio6];
        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
            i++;
        }
    }

    // Add more test cases as needed below.
}