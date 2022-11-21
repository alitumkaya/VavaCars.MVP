namespace VavaCars.MVP.ConsoleApp.Domain.Handball
{
    [Serializable]
    internal class HandballMathStatsFileFormatException : Exception
    {
        public override string Message => "Handball Match Stat File format is not correct!";

    }
}