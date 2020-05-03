using System;
using System.IO;
using System.Threading;

namespace Threads
{

    class Program
    {
        public static Boolean process = true;

        static void Main   (string[] args) 
        {   

                // having access to main thread 
                Thread mainThread = Thread.CurrentThread;
                 mainThread.Name = "main";


            while (process)
            {
                Thread thrA = new Thread(() => ReadFile("document1.txt"));
                thrA.Name = "1";
                thrA.Start();

                Thread thrB = new Thread(() => ReadFile("document2.txt"));
                thrB.Name = "2";
                Thread.Sleep(2000);
                thrB.Start();


                Thread thrC = new Thread(() => ReadFile("document3.txt"));
                thrC.Name = "3";
                Thread.Sleep(2000);
                thrC.Start();


                Thread thrD = new Thread(() => ReadFile("document4.txt"));
                thrD.Name = "4";
                Thread.Sleep(2000);
                thrD.Start();
            }

            throw new System.PlatformNotSupportedException("main thread stopped");

            /*abort is deprecated 
             * this algorithm works 
             * but throws exception 
             * mainThread.Abort();  */


        }


/* read whole document in one string named text */
        static void ReadFile(String address)
        {
            String text = File.ReadAllText(address);

            if (text.Contains("key"))
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Console.WriteLine("We found key in this file ");
                Terminate();


            }
            else
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Console.WriteLine("No such a word");
            }

                       
        }

        // set flag false for killing the nain thread
        public static void Terminate()
        {
            process = false;
            Console.WriteLine("sasas");
           
        }
    }



}
