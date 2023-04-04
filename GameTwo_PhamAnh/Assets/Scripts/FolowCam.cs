using UnityEngine;

public class FolowCam : MonoBehaviour
{
    [SerializeField] Transform target;
    void LateUpdate()
    {
        transform.position = target.position;
    }
}
