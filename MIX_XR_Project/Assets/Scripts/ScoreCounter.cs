using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] Canvas _scoreBoard;
    public List<BowlingPlayer> Players { get; private set; }

    public void SetNumberOfPlayers(int numberOfPlayers)
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            Players.Add(new BowlingPlayer());
        }
    }

    public void ClearPlayers()
    {
        Players.Clear();
    }
}

public class BowlingPlayer
{
    public int RoundScore { get; set; }
    public List<int> Rolls { get; set; }

    public BowlingPlayer()
    {

    }

    public int GetScore()
    {
        var score = 0;
        foreach (var roll in Rolls)
        {
            score += roll;
        }

        return score;
    }
}