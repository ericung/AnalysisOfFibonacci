FileStream ostrm2;
StreamWriter writer2;
TextWriter oldOut2 = Console.Out;
try
{
    ostrm2 = new FileStream("./generalMdLogs.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

    writer2 = new StreamWriter(ostrm2);
}
catch (Exception e)
{
    Console.WriteLine("Cannot open Redirect.txt for writing");

    Console.WriteLine(e.Message);
    return;
}


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

// Generates negatives from a general monomial decider represented as an algorithm so
// that we can collect data about the negatives
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
            // A simple verifier
            if (num == i)
            {
                Console.WriteLine(negatives.ToString().Replace("^M",""));
                Console.WriteLine("f(" + x + ") = " + i + "".Replace("^M",""));
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

Console.SetOut(writer2);

// Hits are the number of times the process steps on a finishing state.
Console.WriteLine("Using the general decider to get the number of hits in the monomial decider.".Replace("^M", ""));
var res = Generator(22);

// Generate some examples
Console.WriteLine("\n\nGenerator Function Output".Replace("^M",""));

for(int x = 0; x < res.Length; x++)
{
    Console.WriteLine(new String("f("+x+") = " + res[x] + "").Replace("^M", ""));
}

Console.SetOut(oldOut2);
writer2.Close();
ostrm2.Close();

// After getting some log results, we can construct a decider
bool MonomialDecider2xx(int y)
{
    var total = 0;
    var hits = 0;
    var diff = 1;
    var isEven = 0;
    var s = 0;

    while (s <= y)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    if ((i == 0)&&(j == 0 || j == 1)&&(k == 0))
                    {
                        if (hits == total)
                        {
                            if (s == y)
                            {
                                Console.WriteLine(new String(s + ": Hits: " + total + "").Replace("^M",""));
                                return true;
                            }
                            else if (s > y)
                            {
                                return false;
                            }

                            total += diff;
                            isEven++;
                            if (isEven % 3 == 2)
                            {
                                isEven = 0;
                                diff += 2;
                            }
                        }

                        hits++;
                    }
                    s++;
                }
            }
        }
    }

    return false;
}

var ys = new List<int>();

FileStream ostrm;
StreamWriter writer;
TextWriter oldOut = Console.Out;
try
{
    ostrm = new FileStream("./monomialDeciderLogs.txt", FileMode.OpenOrCreate, FileAccess.Write);

    writer = new StreamWriter(ostrm);
}
catch (Exception e)
{
    Console.WriteLine("Cannot open Redirect.txt for writing");

    Console.WriteLine(e.Message);
    return;
}

Console.SetOut(writer);

Console.WriteLine("Monomial Decider 2xx deciding.".Replace("^M", ""));

for (int i = 0; i < 1000; i++)
{
    if (MonomialDecider2xx(i))
    {
        ys.Add(i);
    }
}

Console.WriteLine(ys.Count);

Console.WriteLine(new String("2,000,000 in f(x)? " + MonomialDecider2xx(2000000) + "").Replace("^M", ""));

Console.SetOut(oldOut);
writer.Close();
ostrm.Close();

