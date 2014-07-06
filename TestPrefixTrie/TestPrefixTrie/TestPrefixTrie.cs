using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using StandardTrie.cs;

namespace TestPrefixTrie
{
    class TestPrefixTrie
    {
        static void Main(string[] args)
        {
            string largeDictionaryFilename = "en_US.dic";

            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            TestSmallTrie();
            watch1.Stop();
            var elapsed1MS = watch1.ElapsedMilliseconds;
            Console.WriteLine("Small trie executes in {0} ms, one pass.\n", elapsed1MS);

            watch1.Reset();
            watch1.Start();
            TestLargeTrie(largeDictionaryFilename);
            watch1.Stop();
            elapsed1MS = watch1.ElapsedMilliseconds;
            Console.WriteLine("Large trie executes in {0} ms, one pass.\n", elapsed1MS);

            Console.Read();
        }

        public static void TestSmallTrie()
        {
            Console.WriteLine("----------------TEST SMALL TRIE SECTION STARTING----------------\n");
            long bytesallocated = GC.GetTotalMemory(false);
            Console.WriteLine("Total Memory: INIT (kB): {0}", bytesallocated/1000.0);
            PrefixTrie tree = new PrefixTrie();

            tree.Insert("flower");
            tree.Insert("fire");
            tree.Insert("goal");
            tree.Insert("seventeen");
            tree.Insert("flame");
            tree.Insert("flames");

            bytesallocated = GC.GetTotalMemory(false);

            Console.WriteLine("Total Memory: INSERT_COMPLETE (kB): {0}", bytesallocated / 1000.0);

            Console.WriteLine("Checking if tree contains 'flame'.");
            if (tree.Contains("flames"))
                Console.WriteLine("Yes, flames.");
            if (tree.Contains("flame"))
                Console.WriteLine("Yes, flame");
            if (tree.Contains("fire"))
                Console.WriteLine("Yes, fire");
            if (tree.Contains("seventeen"))
                Console.WriteLine("Yes, seventeen");

            bytesallocated = GC.GetTotalMemory(false);

            Console.WriteLine("Total Memory: CONTAINS_COMPLETE (kB): {0}\n", bytesallocated / 1000.0);
            Console.WriteLine("----------------TEST SMALL TRIE SECTION COMPLETE----------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void TestLargeTrie(string filename)
        {
            try
            {
                using (TextReader tr = new StreamReader(filename))
                {
                    Console.WriteLine("----------------TEST LARGE TRIE SECTION STARTING----------------\n");
                    long bytesallocated = GC.GetTotalMemory(false);
                    Console.WriteLine("Total Memory: INIT (kB): {0}", bytesallocated / 1000.0);

                    PrefixTrie largeTree = new PrefixTrie();
                    string line;
                    string[] pieces = new string[2];

                    while ((line = tr.ReadLine()) != null)
                    {
                        pieces = line.Split('/');
                        largeTree.Insert(pieces[0]);
                    }

                    bytesallocated = GC.GetTotalMemory(false);
                    Console.WriteLine("Total Memory: INSERTION_COMPLETE (kB): {0}", bytesallocated / 1000.0);

                    while ((line = tr.ReadLine()) != null)
                    {
                        largeTree.Contains(line);
                    }

                    bytesallocated = GC.GetTotalMemory(false);
                    Console.WriteLine("Total Memory: CONTAINS_COMPLETE (kB): {0}", bytesallocated / 1000.0);
                    Console.WriteLine("{0} unique words read and inserted.\n", largeTree.UniqueCount);
                    Console.WriteLine("----------------TEST LARGE TRIE SECTION COMPLETE----------------");
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
                Console.Read();
            }
        }
    }
}
