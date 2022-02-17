public class PrioritizedPaymentQueue
{
    public List<ProcessPaymentQueueItem> Queue { get; } = new();

    public void Enqueue(ProcessPaymentQueueItem processPaymentQueueItem)
    {
        Queue.Add(processPaymentQueueItem);
    }

    public ProcessPaymentQueueItem Dequeue()
    {
        var priorityItem = Queue.OrderBy(x => x.Priority).First();
        Queue.Remove(priorityItem);
        return priorityItem;
    }
}

public class ProcessPaymentDTO
{
}

public class ProcessPaymentQueueItem
{
    public int Priority { get; set; }
    public ProcessPaymentDTO Request { get; set; }
}