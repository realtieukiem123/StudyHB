using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] brickSpawn;
    [SerializeField] int gridX;
    [SerializeField] int gridZ;
    [SerializeField] float gridSpacing = 1f;
    public Vector3 gridOrigin = Vector3.zero;

    private void Start()
    {
        Spawner();
    }

    void Spawner()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                Vector3 spawnPos = new Vector3(x * gridSpacing, 0, z * gridSpacing) + gridOrigin;
                pickSpawn(spawnPos, Quaternion.identity);
            }
            for (int z = 0; z < gridZ; z++)
            {
                Vector3 spawnPos = new Vector3(x * gridSpacing, 0, z * gridSpacing + 40f) + gridOrigin;
                pickSpawn(spawnPos, Quaternion.identity);
            }
        }
    }
    void pickSpawn(Vector3 posToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, brickSpawn.Length);
        GameObject clone = Instantiate(brickSpawn[randomIndex], posToSpawn, rotationToSpawn);
        int rd = Random.Range(0, ColorManager.instance.typeColor.newMat.Length);
        clone.gameObject.GetComponent<MeshRenderer>().material = ColorManager.instance.typeColor.newMat[rd];
        clone.GetComponent<Brick>().typeColorBrick = rd;
    }

}
