public interface IGameCtlr
{
    void GameReStart();
    void GameOver();
    void AddScore(int value);
    void DecBlocks();
    int Score { get; }
}