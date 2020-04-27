using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrueOrFalseData
{
    public string name;
    public int timeLimitInSeconds;
    public int minimumWinningScore;
    public int pointsAddedForCorrectAnswer;
    public TrueOrFalseQuestions[] questions;
}