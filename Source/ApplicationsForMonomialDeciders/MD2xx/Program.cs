using Common;

#region generalizedMD

bool generalizedMD(int y)
{
    if (y == 0)
    {
        return true;
    }

    var s = y;

    while (s >= 0)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (s == 0 && (j == 0 || j == 2) && i == 0)
                {
                    return true;
                }
                else if (s < 0)
                {
                    return false;
                }
                s -= 1;
            }
        }
    }

    return true;
}

#endregion generalizedMD

#region generator

int[] Generator(int max)
{
    int[] result = new int[max + 1];
    int x = 0;
    int negatives = 0;
    int i = 0;

    while (x < max + 1)
    {
        int num = 2 * (Convert.ToInt32(Math.Pow(x, 2)));

        if (generalizedMD(i))
        {
            if (num == i)
            {
                Console.WriteLine(negatives);
                Console.WriteLine("f(" + x + ") = " + i);
                result[x] = i;

                x++;
                negatives = 0;
            }
            else
            {
                negatives++;
            }
        }
        i++;
    }

    return result;
}

#endregion generator

#region md2xx

bool MonomialDecider2xx(int y)
{
    var totalVisits = 0;
    var currentVisits = 0;
    var diff = 1;
    var s = 0;

    while (s <= y)
    {
        // the constant 2
        for (int i = 0; i < 2; i++)
        {
            // the first pass of x in 2x^2
            for (int j = 0; j < 2; j++)
            {
                // the second pass of x in 2x^2
                for (int k = 0; k < 2; k++)
                {
                    if ((i == 0) && (j == 0 || j == 1) && (k == 0))
                    {
                        if (currentVisits == totalVisits)
                        {
                            if (s == y)
                            {
                                Console.WriteLine(new String("Deciding on: " + s + " - totalVisits: " + totalVisits));
                                return true;
                            }
                            else if (s > y)
                            {
                                return false;
                            }

                            totalVisits += diff;

                            // If the tape head is on the odd finishing
                            // state increase the diff variable by 2
                            // Do this to represent x^2 in 2x^2
                            if (i == 0 && j == 1 && k == 0)
                            {
                                diff += 2;
                            }
                        }

                        currentVisits++;
                    }
                    s++;
                }
            }
        }
    }

    return false;
}

#endregion md2xx

#region generalizedRun

FileStream ostrmGMD;
StreamWriter writerGMD;
Common.Log.Create(out ostrmGMD, out writerGMD, Log.MDXXPATH, Log.GENERALIZEDMD);

Console.WriteLine("Using the general decider to get the number of hits in the monomial decider.");
Console.WriteLine("\n\nGenerator Function Output");

var res = Generator(22);

for (int x = 0; x < res.Length; x++)
{
    Console.WriteLine(new String("f(" + x + ") = " + res[x] + ""));
}

writerGMD.Close();
ostrmGMD.Close();

#endregion generatorRun

#region mdLogRun

FileStream ostrmMD;
StreamWriter writerMD;
Common.Log.Create(out ostrmMD, out writerMD, Log.MDXXPATH, Log.MD2XX);

Console.WriteLine("Monomial Decider 2xx deciding");

var ys = 0;

for (int i = 0; i < 1000; i++)
{
    if (MonomialDecider2xx(i))
    {
        ys++;
    }
}

Console.WriteLine("y's accepted between 0 and 999: " + ys);
Console.WriteLine(new String("2,000,000 in f(x)? " + MonomialDecider2xx(2000000)));
Console.WriteLine("Is 500000000 accepted? " + MonomialDecider2xx(500000000));

writerMD.Close();
ostrmMD.Close();

#endregion mdLogRun

