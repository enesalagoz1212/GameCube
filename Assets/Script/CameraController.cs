using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 cubeOffset;
    public Transform cubeTransform;

    private void Start()
    {
        transform.position = cubeTransform.position + cubeOffset;
    }

    private void LateUpdate()
    {
        transform.position = cubeTransform.position + new Vector3(cubeOffset.x, 0f, cubeOffset.z);
        transform.position = cubeTransform.position + cubeOffset;
    }
}