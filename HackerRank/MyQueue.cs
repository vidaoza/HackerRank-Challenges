using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public sealed class MyQueue<T>
    {
        public Stack<T> QueuedStack { get; set; }

        public Stack<T> StackedStack { get; set; }

        public MyQueue()
        {
            QueuedStack = new Stack<T>();
            StackedStack = new Stack<T>();
        }

        public void Enqueue(T val) // adds value at the end of the queue
        {
            StackedStack.Push(val);
        }

        public T Dequeue()  //removes the value at the front of the queue
        {
            if (QueuedStack.Count == 0)
                MoveStackToQueue();

            return QueuedStack.Pop();
        }

        public T Peek()
        {
            if (QueuedStack.Count == 0)
                MoveStackToQueue();

            return QueuedStack.Peek();
        }

        private void MoveStackToQueue()
        {
            while (StackedStack.Count > 0)
                QueuedStack.Push(StackedStack.Pop());
        }
    }
}

