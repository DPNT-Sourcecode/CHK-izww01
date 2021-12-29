using BeFaster.Runner.Exceptions;
using System;

namespace BeFaster.App.Solutions.HLO
{
    public static class HelloSolution
    {
        public static string Hello(string friendName)
        {
            if (String.IsNullOrWhiteSpace(friendName)) {
                return "Hello, World!";
            }
            return $"Hello, {friendName}!";
        }
    }
}
