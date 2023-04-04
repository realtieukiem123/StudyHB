using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public TypeColor typeColor;

    public static ColorManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


}
