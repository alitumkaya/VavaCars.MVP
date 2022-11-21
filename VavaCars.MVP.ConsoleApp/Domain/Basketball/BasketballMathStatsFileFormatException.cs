namespace VavaCars.MVP.ConsoleApp.Domain.Basketball
{
    [Serializable]
    internal class BasketballMathStatsFileFormatException : Exception
    {
        public override string Message => "Basketball Match Stat File format is not correct!";
    }
}