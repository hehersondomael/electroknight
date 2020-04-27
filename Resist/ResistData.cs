using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResistData
{
    public string name;
    public int timeLimitInSeconds;
    public int minimumWinningScore;
    public int pointsAddedForCorrectAnswer;
    public int minimumTrueOrFalseScoreToUnlock;
    public ResistQuestions[] questions;
}