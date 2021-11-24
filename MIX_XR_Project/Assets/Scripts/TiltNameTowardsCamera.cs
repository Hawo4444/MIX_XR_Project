using UnityEngine;

public class TiltNameTowardsCamera : MonoBehaviour
{
    private Transform _mainCamera;

    void Start()
    {
        _mainCamera = Camera.main.transform;
    }

    void Update()
    {
        transform.LookAt(_mainCamera.position, Vector3.up);
    }
}
