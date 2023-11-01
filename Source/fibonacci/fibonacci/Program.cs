using System.Runtime.CompilerServices;

int fibonacci(int n)
{
    if (n == 0)
    {
        return 0;
    }

    int y = 1;
    int y1 = 1;
    int y2 = 0;

    for(int i = 1; i < n; i++)
    {
        y = y1 + y2;
        y2 = y1;
        y1 = y;
    }

    return y;
}

Console.WriteLine("Generates fibonacci using dynamic programming");

for (int i = 0; i < 25; i++)
{
    int y = fibonacci(i);
    int eX = i % 2;
    int eY = y % 2;

    Console.WriteLine("f(\t" + i + "\t) =\t\t" + y + "\t\tEx = " + eX + "\t\teY = " + eY);
}

int fibonacciGenerator(int n)
{
    int stateX = 0;
    int stateY = 1;
    int stateZ = 1;
    int cycles = 0;

    while (cycles <= n)
    {
        cycles++;

        if (cycles > n)
        {
            return stateX;
        }

        stateX = stateY + stateZ;
        Console.WriteLine("stateX: " + stateX + "\tstateY: " + stateY + "\tstateZ: " + stateY);
        
        cycles++;

        if (cycles > n)
        {
            return stateY;
        }

        stateY = stateX + stateZ;
        Console.WriteLine("stateX: " + stateX + "\tstateY: " + stateY + "\tstateZ: " + stateY);

        cycles++;

        if (cycles > n)
        {
            return stateZ;
        }

        stateZ = stateX + stateY;
        Console.WriteLine("stateX: " + stateX + "\tstateY: " + stateY + "\tstateZ: " + stateY);
    }

    return stateX;
}

Console.WriteLine("\n\nGenerates fibonacci sequence using generators");

for (int i = 0; i < 25; i++)
{
    int y = fibonacciGenerator(i);

    Console.WriteLine("f(\t" + i + "\t) =\t\t" + y);
}
