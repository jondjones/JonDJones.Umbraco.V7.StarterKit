using System;

namespace JonDJones.Core.Helpers
{ 
    public static class Guard
    {
        public static void ValidateObject(object objecttoTest)
        {
            if (objecttoTest == null)
                throw new ArgumentException("object passed in has not been instantiated.");
        }
    }
}