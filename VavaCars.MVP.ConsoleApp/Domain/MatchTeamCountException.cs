namespace VavaCars.MVP.ConsoleApp.Domain
{
    internal class MatchTeamCountException : Exception
    {
        public override string Message => "There cannot be more than 2 teams in a match.";
    }
}
