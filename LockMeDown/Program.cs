using System;
using System.IO;

namespace LockMeDown
{
    class Program
    {
        static void Main(string[] args)
        {

            if(args.Length == 0)
            {
                Console.WriteLine();
                Console.WriteLine("You need to enter 'lockmedown --help' for all commands.");
                Console.WriteLine();
            }
            else
            {
                if(args[0] == "--help")
                {
                    Console.WriteLine();
                    Console.WriteLine("lockmedown --lock <password> <file path>       | It encrypts a File");
                    Console.WriteLine("lockmedown --unlock <password> <file path>     | It decrypts a File");
                    Console.WriteLine("lockmedown --bytecount <file path>             | It counts all bytes in a File");
                    Console.WriteLine();
                }
                else if(args[0] == "--lock")
                {
                    if(args[1].Length != 0)
                    {
                        byte[] e = ByteManager.GetPasswordBytes(args[1]);

                        if(File.Exists(args[2]))
                            ByteManager.LockFile(args[2], e);
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("File is not available.");
                            Console.WriteLine();
                            return;
                        }

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Password Invalid.");
                        Console.WriteLine();
                    }
                }
                else if (args[0] == "--unlock")
                {
                    if (args[1].Length != 0)
                    {
                        byte[] e = ByteManager.GetPasswordBytes(args[1]);
                        if (File.Exists(args[2]))
                            ByteManager.UnlockFile(args[2], e);
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("File is not available.");
                            Console.WriteLine();
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please use a password to unlock.");
                        Console.WriteLine();
                    }
                }
                else if (args[0] == "--bytecount")
                {
                    if (args[1].Length != 0)
                    {
                        if(File.Exists(args[1]))
                        {
                            byte[] filebytes = File.ReadAllBytes(args[1]);

                            Console.WriteLine();
                            Console.WriteLine("This File has " + filebytes.Length + " Bytes");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please give me a actual File Path.");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
