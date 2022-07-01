using System;

/// <summary>
/// Общий интерфейс уровня.
/// </summary>
public interface ILevel
{
    event Action OnGameStart; 
    event Action OnGameOver; 

    void StartGame();
    
    void GameOver();
}