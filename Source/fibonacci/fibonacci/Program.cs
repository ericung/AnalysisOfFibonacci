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

for (int i = 0; i < 50; i++)
{
    int y = fibonacci(i);
    int eX = i % 2;
    int eY = y % 2;

    Console.WriteLine("f(\t" + i + "\t) =\t\t" + y + "\t\tEx = " + eX + "\t\teY = " + eY);
}
