using UnityEngine;

public class Column : MonoBehaviour
{
    public Bridge Bridge => _bridge;
    public Transform BridgeStartSpot => _bridgeStartSpot.transform;
    public Transform BridgeEndSpot => _bridgeEndSpot.transform;

    [SerializeField] private Transform _bridgeStartSpot;
    [SerializeField] private Transform _bridgeEndSpot;
    [SerializeField] private Transform _playerSpot;
    [SerializeField] private Transform _columnTransform;

    private Bridge _bridge;

    public void SetColumnSize(float width, float height)
    {
        _columnTransform.localScale = new Vector3(width, height);
    }

    public void SetBridge(Bridge bridge)
    {
        _bridge = bridge;
    }
}
