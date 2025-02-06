using System;

public class PointsCounter
{
    public event Action<int> OnChanged;

    private int _points;

    public void AddPoints(int value)
    {
        _points += value;

        OnChanged?.Invoke(_points);
    }
}
