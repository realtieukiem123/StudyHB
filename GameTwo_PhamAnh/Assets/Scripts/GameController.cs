using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int typeColorPlayer;
    public int typeColorEnemy;
    public List<GameObject> listBrick = new List<GameObject>();
    public List<GameObject> listBrickEnemy = new List<GameObject>();
    public float _x;
    public float _y;
    public float _z;
    #region singgleton

    public static GameController Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion
    private void Start()
    {
        InvokeRepeating("rdPos", 0f, 1f);
    }
    public void rdPos()
    {
        _x = Random.Range(-8f, 8f);
        _z = Random.Range(-8f, 8f);
    }
    public Vector3 getRandomPos()
    {
        Vector3 newPos = new Vector3(_x, _y, _z);
        return newPos;
    }

}
