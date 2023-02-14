namespace Derivco.Roulette.Infrastructure.Data.Scritps
{
    public static class DMLConstants
    {
        public const string INSERT_PLAYER = """
                INSERT INTO Player (Id, Name)
                VALUES (@Id, @Name)
                """;

        public const string INSERT_PLAYERBET = """
                INSERT INTO PlayerBet (Id, PlayerId, BetId, Spin, Timestamp)
                VALUES (@Id, @PlayerId, @BetId, @Spin, @Timestamp)
                """;

        public const string GET_ALL_BETS = """
            SELECT * FROM Bet
            """;

        public const string GET_ALL_PLAYERBETS = """
            SELECT * FROM PlayerBet
            """;

        public const string UPDATE_PLAYERBETS_SPIN = """
            UPDATE Users 
            SET Spin = @Spin
            WHERE Id = @Id
            """;
    }
}
