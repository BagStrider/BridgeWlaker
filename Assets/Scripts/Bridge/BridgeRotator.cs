using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class BridgeRotator : MonoComponent
{
    public event Action Rotated;


    [Inject] private BridgeRotatorConfig _config;

    public void Rotate(Quaternion angle)
    {
        StartCoroutine(RotateLerp(angle));
    }

    private IEnumerator RotateLerp(Quaternion angle)
    {
        var startRotation = transform.rotation;
        for (float timer = 0; timer < _config.RotationDuration; timer += Time.deltaTime)
        {
            transform.rotation = Quaternion.Slerp(startRotation, angle, timer / _config.RotationDuration);
            yield return 0;
        }

        Rotated?.Invoke();
    }
}