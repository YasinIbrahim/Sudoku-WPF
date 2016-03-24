//
//  
// 
// 
// 
// 
//
// 
// 

using System;
using System.Diagnostics;

namespace SudokuWPF.ViewModel.GameGenerator
{
    internal class RandomClass
    {
        #region . Constructors .

        // Declared private to prevent other people from instantiating this class.
        private RandomClass()
        {
        }

        #endregion

        #region . Variables .

        private static RandomClass _instance;
        private static readonly object _instanceLock = new object();

        private Random _rnd;
        private readonly object _rndLock = new object();

        #endregion

        #region . Methods .

        #region . Methods: Public .

        /// <summary>
        ///     Gets a random integer between zero and the specified number.
        /// </summary>
        /// <param name="max">Upper bound of the random number to generate.</param>
        /// <returns></returns>
        internal static int GetRandomInt(int max)
        {
            return GetRandomInt(0, max);
        }

        /// <summary>
        ///     Get a random integer between the min and max specified.
        /// </summary>
        /// <param name="min">Lower bound of the random number to generate.</param>
        /// <param name="max">Upper bound of the random number to generate.</param>
        /// <returns></returns>
        internal static int GetRandomInt(int min, int max)
        {
            CheckInstance(); // Check if the singleton is generated.
            return _instance.GetNextInt(min, max); // Return a random integer between min and max
        }

        #endregion

        #region . Methods: Private .

        private static void CheckInstance()
        {
            if (_instance == null) // Is the instance variable null?
            {
                lock (_instanceLock) // Yes, obtain a lock on the instance object
                {
                    if (_instance == null) // Check if the instance variable is null again
                    {
                        _instance = new RandomClass(); // Instantiate a Random class
                        _instance.InitInstance(); // Initialize the instance
                    }
                }
            }
        }

        private void InitInstance()
        {
            if (_rnd == null) // Is the random variable null?
            {
                lock (_rndLock) // Yes, obtain a lock on the random object
                {
                    if (_rnd == null) // Check if the random object is null again
                    {
                        // It is so create a seed and create a new random class
                        var tsp = new TimeSpan(DateTime.Now.Ticks);
                        var seed = (int) (tsp.TotalMilliseconds*10000%int.MaxValue%10000);
                        Debug.WriteLine($@"Random seed = {seed}");
                        _rnd = new Random(seed);
                    }
                }
            }
        }

        private int GetNextInt(int min, int max)
        {
            if (_rnd == null) // If random object is null
                lock (_instance) // Lock the instance object because other thread
                {
                } // is still probably creating the instance
            lock (_rndLock) // Obtain a lock on the random object
            {
                return _rnd.Next(min, max); // Return a random number between min and max
            }
        }

        #endregion

        #endregion
    }
}