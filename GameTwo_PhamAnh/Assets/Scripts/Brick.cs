using System.Collections;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private MeshRenderer brickMat;
    public int typeColorBrick;

    [SerializeField] private float followSpeed;

    public void UpdateCubePosition(Transform followedCube, bool isFollowStart)
    {
        StartCoroutine(StartFollowingToLastCubePosition(followedCube, isFollowStart));
    }

    IEnumerator StartFollowingToLastCubePosition(Transform followedCube, bool isFollowStart)
    {

        while (isFollowStart)
        {
            yield return new WaitForEndOfFrame();
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, followedCube.position.x, followSpeed * Time.deltaTime),
                transform.position.y,
                Mathf.Lerp(transform.position.z, followedCube.position.z, followSpeed * Time.deltaTime));
        }
    }
    public void RemoveCubePosition()
    {
        Destroy(this.gameObject);
    }

}