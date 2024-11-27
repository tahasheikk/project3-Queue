using System;

class Program
{
    private static int[] queue = new int[5];
    private static int front = 0;
    private static int rear = -1;
    private static int size = 0;
    static int[] emptyArray = {};

    static void Main()
    {
        Enqueue(1);
        Enqueue(2);
        Enqueue(3);
        Enqueue(4);
        Enqueue(5);

        Console.WriteLine(Peek()); // 1
        Console.WriteLine(Dequeue()); // 1
        Console.WriteLine(string.Join(", ", ReverseQueue())); // [5 4 3, 2]
        // این متد یک آرایه یا مجموعه‌ای از رشته‌ها را به یک رشته واحد تبدیل می‌کند و بین هر دو عنصر، یک
        //جداکننده (در اینجا ", ") قرار می‌دهد. به عنوان مثال، اگر آرایه‌ای به شکل ["3", "2", "1"]
        //string.Join داده شود، خروجی آن "3, 2, 1" خواهد بود.
        Console.WriteLine("Is queue empty ??" +IsEmpty()); // False
        Console.WriteLine("Is queue full?" + IsFull()); // False

        
    }

    static void Enqueue(int item)
    {
        if (IsFull())
            throw new InvalidOperationException("صف پر است");

        rear = (rear + 1) % queue.Length;
        queue[rear] = item;
        size++;
    }

    static int Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("صف خالی است");

        int item = queue[front];
        front = (front + 1) % queue.Length;
        size--;
        return item;
    }

    static int Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("صف خالی است");

        return queue[front];
    }

    static int[] ReverseQueue()
    {
        if (IsEmpty())
            return emptyArray;

        int[] reversedQueue = new int[size];
        for (int i = 0; i < size; i++)
            reversedQueue[i] = queue[(front + i) % queue.Length];

        // معکوس کردن آرایه بدون استفاده از Array.Reverse
        for (int i = 0; i < size / 2; i++)
        {
            // تعویض عناصر از دو طرف آرایه
            int temp = reversedQueue[i];
            reversedQueue[i] = reversedQueue[size - 1 - i];
            reversedQueue[size - 1 - i] = temp;
        }

        return reversedQueue;
    }

    static bool IsEmpty()
    {
        return size == 0; // اگر size برابر با 0 باشد، صف خالی است
    }

    static bool IsFull()
    {
        return size == queue.Length; // اگر size برابر با طول صف باشد، صف پر است
    }
}