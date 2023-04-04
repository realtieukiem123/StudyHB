using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int typeColorPlayer;
    public int typeColorEnemy;
    public List<GameObject> listBrick = new List<GameObject>();
    public List<GameObject> listBrickEnemy = new List<GameObject>();
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

}
