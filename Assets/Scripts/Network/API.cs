using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class API : MonoBehaviour
{

    public static API instance;

    const string BundleFolder = "http://sallymolly.com/mav/AssetBundles/";

    void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    public void GetBundleObject(ExpoPieceEntity expoEntity, UnityAction<ExpoPieceEntity> callback, Transform bundleParent)
    {
        StartCoroutine(GetDisplayBundleRoutine(expoEntity, callback, bundleParent));
    }

    IEnumerator GetDisplayBundleRoutine(ExpoPieceEntity expoEntity, UnityAction<ExpoPieceEntity> callback, Transform bundleParent)
    {
        
        string bundleURL = BundleFolder + expoEntity.EntityName.ToLower();

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
                Transform expoPieceTransform = expoEntity.PieceGameObject.transform;
                GameObject assetObject = Instantiate(bundle.LoadAsset(rootAssetPath) as GameObject, expoPieceTransform.position, expoPieceTransform.rotation, bundleParent);
                assetObject.transform.localScale = expoPieceTransform.localScale;
                Destroy(expoEntity.PieceGameObject);
                expoEntity.PieceGameObject = assetObject;
                bundle.Unload(false);
                callback(expoEntity);
            }
            else
            {
                Debug.Log("Not a valid asset bundle");
            }
        }
    }
}