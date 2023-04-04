using UnityEngine;

[CreateAssetMenu(fileName = "gi do")]
public class TypeColor : ScriptableObject
{

    public Material[] newMat;
    public enum typeColor { green = 0, red = 1, purple = 2, yellow = 3 }

    public Material getColor(typeColor material)
    {
        return newMat[(int)material];
    }

}
