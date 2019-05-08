using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using QtasHelpDesk.Services.Contracts;

namespace QtasHelpDesk.Services.Security
{
    public class RandomNumberProvider : IRandomNumberProvider
    {
        private readonly RandomNumberGenerator _rand = RandomNumberGenerator.Create();

        public int Next()
        {
            var randb = new byte[4];
            _rand.GetBytes(randb);
            var value = BitConverter.ToInt32(randb, 0);
            if (value < 0) value = -value;
            return value;
        }

        public int Next(int max)
        {
            var randb = new byte[4];
            _rand.GetBytes(randb);
            var value = BitConverter.ToInt32(randb, 0);
            value = value % (max + 1); // % calculates remainder
            if (value < 0) value = -value;
            return value;
        }

        public int Next(int min, int max)
        {
            var value = Next(max - min) + min;
            return value;
        }

        public string GeneratePassword()
        {
            return Next(100000,900000).ToString();
        }
    }
}
