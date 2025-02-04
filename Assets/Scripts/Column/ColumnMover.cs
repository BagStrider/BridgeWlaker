using System.Collections;
using UnityEngine;
using Zenject;

public class ColumnMover : MonoBehaviour
{
    public Transform LeftPoint => _leftPoint;
    public Transform RightPoint => _rightPoint;

    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;

    [Inject] private ColumnSpawnPointsConfig _config;

    public void MoveToPoints(Column colLeft, Column colRight)
    {
        StartCoroutine(TryMoveColumnsToPoints(colLeft, colRight));
    }

    private IEnumerator TryMoveColumnsToPoints(Column colLeft, Column colRight)
    {
        Vector3 colLeftStartPos = colLeft.transform.position;
        Vector3 colRightStartPos = colRight.transform.position;

        for (float timer = 0; timer < _config.MoveToPointsDuration; timer += Time.deltaTime)
        {
            colLeft.transform.position = Vector3.Lerp(colLeftStartPos, _leftPoint.position, timer / _config.MoveToPointsDuration);
            colRight.transform.position = Vector3.Lerp(colRightStartPos, _rightPoint.position, timer / _config.MoveToPointsDuration);
            yield return 0;
        }
    }
}