using TMPro;
using UnityEngine;

public class PointsCounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointsText;

    public void ChangePoints(int points)
    {
        _pointsText.text = points.ToString();
    }
}