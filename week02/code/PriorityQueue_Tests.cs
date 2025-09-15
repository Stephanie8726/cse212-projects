using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities and dequeue all.
    // Expected Result: Highest priority item comes out first, then next, and so on.
    // Defect(s) Found: None after correction. Original code did not remove dequeued item.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Aaron", 1);
        pq.Enqueue("Jude", 3);
        pq.Enqueue("Nick", 2);

        Assert.AreEqual("Jude", pq.Dequeue()); // priority 3
        Assert.AreEqual("Nick", pq.Dequeue()); // priority 2
        Assert.AreEqual("Aaron", pq.Dequeue()); // priority 1
    }

    [TestMethod]
    // Scenario: Enqueue items with duplicate priorities and check dequeue order.
    // Expected Result: Among items with same priority, the one enqueued first is dequeued first.
    // Defect(s) Found: Original code compared priorities incorrectly and did not remove items.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Anne", 5);
        pq.Enqueue("Sam", 5);
        pq.Enqueue("Jane", 4);

        Assert.AreEqual("Anne", pq.Dequeue()); // Anne and Sam both 5 → Anne was enqueued first
        Assert.AreEqual("Sam", pq.Dequeue()); // Sam next
        Assert.AreEqual("Jane", pq.Dequeue()); // lowest priority
    }

    [TestMethod]
    // Scenario: Try to dequeue from empty queue.
    // Expected Result: InvalidOperationException is thrown.
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }
}