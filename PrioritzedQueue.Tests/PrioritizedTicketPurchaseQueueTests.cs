using System;
using System.Collections.Generic;
using Xunit;

namespace PrioritzedQueue.Tests
{
    public class PrioritizedTicketPurchaseQueueTests
    {
        private PrioritizedTicketPurchaseQueue SetupQueue()
        {
            var queue = new PrioritizedTicketPurchaseQueue();
            queue.Enqueue(new TicketPurchaseQueueItem()
            {
                Priority = new DateTime(2022, 1, 2),
                Request = new PurchaseRequestDTO(),
            });
            queue.Enqueue(new TicketPurchaseQueueItem()
            {
                Priority = new DateTime(2022, 1, 1),
                Request = new PurchaseRequestDTO(),
            });
            return queue;
        }
        [Fact]
        public void Dequeue_ReturnsOldestItem()
        {
            var queue = SetupQueue();
            var result = queue.Dequeue();
            Assert.Equal(new DateTime(2022,1,1),result.Priority);
        }

        [Fact]
        public void Dequeue_RemovesItemFromQueue()
        {
            var queue = SetupQueue();
            var result = queue.Dequeue();
            Assert.Single(queue.Queue);
        }
    }
}