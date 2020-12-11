using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LockMeDown
{
    class ByteManager
    {

        public static byte[] GetPasswordBytes(string password)
        {
            byte[] e = System.Text.Encoding.UTF8.GetBytes(password);

            return e;
        }

        public static void LockFile(string filename, byte[] passwordBytes)
        {
            byte[] eBytes = File.ReadAllBytes(filename);

            ulong[] afterwork = new ulong[eBytes.Length];

            Console.WriteLine("Locking File");
            Console.WriteLine();
            int n = 0;
            int compn = 0;
            foreach(byte p in eBytes)
            {
                if(compn == passwordBytes.Length)
                {
                    compn = 0;
                }

                afterwork[n] = Convert.ToUInt64(eBytes[n] * passwordBytes[compn]);

                compn++;
                n++;
            }

            using (StreamWriter writer = new StreamWriter(filename + ".lmd"))
            {
                foreach(ulong e in afterwork)
                {
                    writer.Write(e + " ");
                }

                writer.Close();
            }

            Console.WriteLine("File locked with your Password!");
            Console.WriteLine();
        }

        public static void UnlockFile(string filename, byte[] passwordBytes)
        {
            string fullfilecontent = File.ReadAllText(filename);

            string[] fileparts = fullfilecontent.Split(' ');

            ulong[] lockedFileBytes = new ulong[fileparts.Length - 1];

            int pn = 0;

            Console.WriteLine("Unlocking File");
            Console.WriteLine();
            Console.WriteLine("Step 1: Reading locked bytes");

            foreach (string e in fileparts)
            {
                try
                {
                    ulong e2 = Convert.ToUInt64(e);
                    lockedFileBytes[pn] = e2;

                }
                catch
                {

                }

                pn++;
            }


            Console.WriteLine($"{lockedFileBytes.Length} locked bytes found.");

            Console.WriteLine();

            Console.WriteLine("Step 2: Unlocking the locked bytes");

            byte[] afterwork = new byte[lockedFileBytes.Length];

            
            int n = 0;
            int compn = 0;
            foreach (ulong p in lockedFileBytes)
            {
                if (compn == passwordBytes.Length)
                {
                    compn = 0;
                }

                afterwork[n] = Convert.ToByte(lockedFileBytes[n] / passwordBytes[compn]);

                compn++;
                n++;
            }

            Console.WriteLine("The locked bytes got unlocked. If you didnt put the right password, the file output will be broken and you wont be able to use the file properly.");

            string extension = ".lmd";

            string result = filename.Substring(0, filename.Length - extension.Length);

            File.WriteAllBytes(result, afterwork);

            Console.WriteLine("File unlocked with the Password you put in!");
            Console.WriteLine();
        }

    }
}
