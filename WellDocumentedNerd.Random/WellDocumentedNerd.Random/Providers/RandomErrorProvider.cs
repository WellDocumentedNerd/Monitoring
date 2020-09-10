using System;
using System.Collections.Generic;
using System.Text;
using WellDocumentedNerd.Random.Interfaces;

namespace WellDocumentedNerd.Random.Providers
{
    public class RandomErrorProvider : IRandomErrorProvider
    {
        public bool ReturnError(int min, int max, int threshold)
        {
            System.Random r = new System.Random();
            int genRand = r.Next(min, max);

            if (genRand <= threshold)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
