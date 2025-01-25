using UnityEngine;
using Zenject;

public class BridgeGrower : MonoComponent
{
    [Inject] private BridgeGrowerConfig _objectGrowerCfg;
    
    public void GrowUp()
    {
        Vector3 lastScale = transform.localScale;

        transform.localScale = new Vector3(lastScale.x, lastScale.y + Time.deltaTime * _objectGrowerCfg.GrowSpeed, lastScale.z);
    }
}