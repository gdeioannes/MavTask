using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpoSpaceController : MonoBehaviour
{
    public static ExpoSpaceController instance;
    List<GameObject> expoObject;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}
