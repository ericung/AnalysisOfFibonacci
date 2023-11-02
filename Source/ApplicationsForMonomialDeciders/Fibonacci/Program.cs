using Common;

#region fibonacci

int fibonacci(int n)
{
    if (n == 0)
    {
        return 0;
    }

    int y = 1;
    int y1 = 1;
    int y2 = 0;

    for (int i = 1; i < n; i++)
    {
        y = y1 + y2;
        y2 = y1;
        y1 = y;
    }

    return y;
}

#endregion fibonacci

#region fibonacciGenerator

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
        Console.WriteLine(new String("stateX: " + stateX + "\tstateY: " + stateY + "\tstateZ: " + stateY));

        cycles++;

        if (cycles > n)
        {
            return stateY;
        }

        stateY = stateX + stateZ;
        Console.WriteLine(new String("stateX: " + stateX + "\tstateY: " + stateY + "\tstateZ: " + stateY));

        cycles++;

        if (cycles > n)
        {
            return stateZ;
        }

        stateZ = stateX + stateY;
        Console.WriteLine(new String("stateX: " + stateX + "\tstateY: " + stateY + "\tstateZ: " + stateY));
    }

    return stateX;
}

#endregion fibonacciGenerator

# region main

FileStream ostrmFib;
StreamWriter writerFib;
Log.Create(out ostrmFib, out writerFib, Log.FIBONACCIPATH, Log.FIBONACCI);
Console.Out.NewLine = "\n";

Console.WriteLine("Generates fibonacci using dynamic programming");

for (int i = 0; i < 25; i++)
{
    int y = fibonacci(i);
    int eX = i % 2;
    int eY = y % 2;

    Console.WriteLine(new String("f(\t" + i + "\t) =\t\t" + y + "\t\tEx = " + eX + "\t\teY = " + eY));
}

writerFib.Close();
ostrmFib.Close();

#endregion fibonacciRun

#region fibonacciGeneratorRun

FileStream ostrmFibGen;
StreamWriter writerFibGen;
Log.Create(out ostrmFibGen, out writerFibGen, Log.FIBONACCIPATH, Log.FIBANCCIGENERATOR);

Console.Out.NewLine = "\n";
Console.WriteLine("Generates fibonacci sequence using generators");

for (int i = 0; i < 10; i++)
{
    int y = fibonacciGenerator(i);
    Console.WriteLine(new String("f(\t" + i + "\t) =\t\t" + y));
}

writerFibGen.Close();
ostrmFibGen.Close();

#endregion fibonacciGeneratorRun
