using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _score;
    
    public event Action<int> ScoreChanged; 
        
    public void AddScore(int score)
    {
        _score += score;
        ScoreChanged?.Invoke(_score);
    }
}