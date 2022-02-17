using System;
using System.Collections.Generic;
using Xunit;

namespace PrioritzedQueue.Tests
{
    public class PrioritizedPaymentQueueTests
    {
        private PrioritizedPaymentQueue SetupQueue()
        {
            var queue = new PrioritizedPaymentQueue();
            queue.Enqueue(new ProcessPaymentQueueItem()
            {
                Priority = 2,
                Request = new ProcessPaymentDTO(),
            });
            queue.Enqueue(new ProcessPaymentQueueItem()
            {
                Priority = 1,
                Request = new ProcessPaymentDTO(),
            });
            return queue;
        }
        [Fact]
        public void Dequeue_ReturnsItemWithLowestPriorityValue()
        {
            var queue = SetupQueue();
            var result = queue.Dequeue();
            Assert.Equal(1,result.Priority);
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