using System;
using System.Collections.Generic;
using System.Text;

namespace QtasHelpDesk.Services.Contracts
{
    public interface IRandomNumberProvider
    {
        int Next();
        int Next(int max);
        int Next(int min, int max);

        string GeneratePassword();


    }
}
