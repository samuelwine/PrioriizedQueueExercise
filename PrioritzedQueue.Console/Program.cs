public class PurchaseRequestDTO
{
}

public class TicketPurchaseQueueItem
{
    public DateTime Priority { get; set; }
    public PurchaseRequestDTO Request { get; set; }
}

public class PrioritizedQueue
{
    public List<TicketPurchaseQueueItem> Queue { get; set; }

    public void Enqueue(TicketPurchaseQueueItem ticketPurchaseQueueItem)
    {
        Queue.Add(ticketPurchaseQueueItem);
    }

    public TicketPurchaseQueueItem Dequeue()
    {
        var priorityItem = Queue.OrderBy(x => x.Priority).First();
        Queue.Remove(priorityItem);
        return priorityItem;
    }
}