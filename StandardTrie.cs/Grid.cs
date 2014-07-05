using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardTrie.cs
{
    /// <summary>
    /// A helper class for the search functionality.
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// The alphabet will be stored as a dictionary, such that one can
        /// lookup by character and get an int value. I'm trying to avoid 
        /// foreach loops by using this method.
        /// </summary>
        Dictionary<char, int> Alphabet { get; set; }

        /// <summary>
        /// Public, non-default constructor. Takes an array of characters representing
        /// an alphabet, creates a dictionary for them, and then stores their key/value
        /// pairs in said dictionary. 
        /// </summary>
        /// <param name="values"></param>
        public Grid(char[] values)
        {
            int i = 0;
            Alphabet = new Dictionary<char, int>(values.Length);
            foreach (char c in values)
            {
                Alphabet.Add(c, i++);
            }
        }

        /// <summary>
        /// Overload the Grid[] so that passing an int will cause the
        /// associated character to be returned.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public char this[int i]
        {
            get
            {
                return Alphabet.ElementAt(i).Key;
            }
        }

        /// <summary>
        /// Overload the Grid[] so that passing in a character will
        /// cause the index of that character to be returned.
        /// If the character is not found, throw an ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int this[char c]
        {
            get
            {
                int i = -1;
                if (Alphabet.TryGetValue(c, out i))
                {
                    return i;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("This element does not exist");
                }
            }
        }
    }
}
