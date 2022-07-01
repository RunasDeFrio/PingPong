using System;

public interface ILevel
{
    event Action OnGameStart; 
    event Action OnGameOver; 

    void StartGame();
    
    void GameOver();
}