using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class API : MonoBehaviour
{

    const string BundleFolder = "http://sallymolly.com/mav/AssetBundles/";

    public void GetBundleObject(string assetName, UnityAction<GameObject> callback, Transform bundleParent, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        StartCoroutine(GetDisplayBundleRoutine(assetName, callback, bundleParent,position,rotation,scale));
    }

    IEnumerator GetDisplayBundleRoutine(string assetName, UnityAction<GameObject> callback, Transform bundleParent, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        Debug.Log("BEGIN");
        assetName = assetName.ToLower();
        string bundleURL = BundleFolder + assetName;

        Debug.Log("Requesting bundle at " + bundleURL);

        //request asset bundle
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log("Network error");
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            if (bundle != null)
            {
                string rootAssetPath = bundle.GetAllAssetNames()[0];
                GameObject assetObject = Instantiate(bundle.LoadAsset(rootAssetPath) as GameObject, position,rotation,bundleParent);
                assetObject.transform.localScale = scale;
                bundle.Unload(false);
                callback(assetObject);
            }
            else
            {
                Debug.Log("Not a valid asset bundle");
            }
        }
    }
}