using UnityEngine;

public class LoadAssetBundle : MonoBehaviour
{

    public API api;

    public void LoadContent(string name,Transform container, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        Debug.Log("GET ASSET:"+name);
        api.GetBundleObject(name, OnContentLoaded, container,position,rotation,scale);
    }

    void OnContentLoaded(GameObject content)
    {
        //do something cool here
        Debug.Log("Loaded: " + content.name);
    }
}
