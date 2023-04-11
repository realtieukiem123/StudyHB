using System.Collections;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private MeshRenderer brickMat;
    [SerializeField] private float followSpeed;
    public int typeColorBrick;
    //public Vector3 vtBrick;
    public Vector3 vtBrick;
    public Coroutine updateCube;
    public bool IsFollowing;

    private void Awake()
    {
        // vtBrick = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        vtBrick = this.transform.position;
    }
    public void UpdateCubePosition(Transform followedCube, bool isFollowStart)
    {
        updateCube = StartCoroutine(StartFollowingToLastCubePosition(followedCube, isFollowStart));
    }

    IEnumerator StartFollowingToLastCubePosition(Transform followedCube, bool isFollowStart)
    {

        while (IsFollowing)
        {
            yield return new WaitForEndOfFrame();
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, followedCube.position.x, followSpeed * Time.deltaTime),
                transform.position.y,
                Mathf.Lerp(transform.position.z, followedCube.position.z, followSpeed * Time.deltaTime));
        }
    }
    public void returnPositionBrick()
    {
        //(updateCube);
        this.transform.position = vtBrick;
    }
    public void RemoveCubePosition()
    {
        Destroy(this.gameObject);
    }


}
