public static class ChessValidator
{
    public static bool IsValidMoveFormat(string move)
    {
        if (move.Length != 5) return false;

        char fromCol = move[0];
        char fromRow = move[1];
        char toCol = move[3];
        char toRow = move[4];

        return (fromCol >= 'A' && fromCol <= 'H' &&
                fromRow >= '1' && fromRow <= '8' &&
                toCol >= 'A' && toCol <= 'H' &&
                toRow >= '1' && toRow <= '8');
    }
}
