using UnityEngine;

[System.Serializable]
public class ProgressData
{
    public int Points { get; set; }
    public StateEnum StateEnum { get; set; }

    public ProgressData(Progress progress)
    {
        Points = progress.Points;
        StateEnum = progress.StateEnum;
    }
}
