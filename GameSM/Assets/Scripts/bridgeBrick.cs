using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeBrick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var mesh = GetComponent<MeshRenderer>();
            mesh.enabled = true;
            var obj = GameController.Instance.listBrick[GameController.Instance.listBrick.Count - 1];
            GameController.Instance.listBrick.RemoveAt(GameController.Instance.listBrick.Count - 1);
            Destroy(obj.gameObject);
        }
    }
}
