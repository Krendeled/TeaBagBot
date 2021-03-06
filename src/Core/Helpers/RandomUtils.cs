﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace TeaBagBot.Helpers
{
    public static class RandomUtils
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static int GetRandom(int minimumValue, int maximumValue = int.MaxValue)
        {
            byte[] randomNumber = new byte[1];

            _generator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            // We are using Math.Max, and substracting 0.00000000001, 
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            double multiplier = Math.Max(0, asciiValueOfRandomCharacter / 255d - 0.00000000001d);

            // We need to add one to the range, to allow for the rounding done with Math.Floor
            int range = maximumValue - minimumValue + 1;

            double randomValueInRange = Math.Floor(multiplier * range);

            return (int)(minimumValue + randomValueInRange);
        }

        public static T GetRandomFrom<T>(IEnumerable<T> collection)
        {
            if (collection == null || collection.Count() == 0)
                return default;
            else if (collection.Count() == 1)
                return collection.First();
            return collection.ElementAt(GetRandom(0, collection.Count() - 1));
        }
    }
}
