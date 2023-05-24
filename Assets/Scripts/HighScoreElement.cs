using System;
[Serializable] //needed for saving and reading to/from JSON
public class HighScoreElement
{
    public string playerName;
    public int score;

    public HighScoreElement(string name, int score)
    {
        playerName = name;
        this.score = score;
    }
}
