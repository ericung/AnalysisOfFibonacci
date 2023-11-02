namespace Common
{
    public static class Log
    {
        public const string MD2XX = "../Logs/MD2xx/md2xx.txt";
        public const string GENERALIZEDMD = "../Logs/MD2xx/generalizedMD.txt";

        public const string FIBONACCI = "../Logs/Fibonacci/fibonacci.txt";
        public const string FIBANCCIGENERATOR = "../Logs/Fibonacci/fibonacciGenerator.txt";

        public static void Create(out FileStream ostrm, out StreamWriter writer, string fileName)
        {
            try
            {
                File.Delete(fileName);
                ostrm = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                ostrm = new FileStream("./error" + fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                writer = new StreamWriter(ostrm);
            }

            Console.SetOut(writer);
        }
    }
}
