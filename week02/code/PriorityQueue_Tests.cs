using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with distinct priorities and dequeue until empty.
    // Expected Result: Items come out highest → lowest priority: "High", "Medium", "Low".
    // Defect(s) Found: Dequeue loop excluded last element; item was not removed from list, so order was wrong and queue never emptied.
    public void TestPriorityQueue_DequeueHighestToLowest()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Two items share the same highest priority; the earliest one enqueued should dequeue first (FIFO tie-break).
    // Expected Result: "A" then "B".
    // Defect(s) Found: Code used >= comparison, so the most recently inserted max-priority item was returned first.
    public void TestPriorityQueue_TieBreaksFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: (No defect once the main Dequeue logic was fixed.)
    public void TestPriorityQueue_DequeueFromEmpty()
    {
        var priorityQueue = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    // Additional test cases could be added here if desired.
}
