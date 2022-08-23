using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadController : MonoBehaviour
{
    
    public static LoadController instance;
    public GameObject objectContainer;
    public LoadAssetBundle loadAssetBundle;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void setObjects(string folder,List<ExpoPiece> list)
    {
        GameObject placeHolder;
        //GameObject newPiece;
        foreach (ExpoPiece expoPiece in list)
        {
            Vector3 position = ParseVector3(expoPiece.position);
            Quaternion rotation = ParseQuaternion(expoPiece.rotation);
            Vector3 scale = ParseVector3(expoPiece.scale);
            placeHolder = Instantiate(Resources.Load("Prefab/PlaceHolder"),position ,rotation ,objectContainer.transform) as GameObject;
            placeHolder.transform.localScale = scale;
            loadAssetBundle.LoadContent(expoPiece.assetBundleName, objectContainer.transform,position,rotation,scale, placeHolder);
            //newPiece = Instantiate(Resources.Load(folder + "/" + expoPiece.assetBundleName), ParseVector3(expoPiece.position),ParseQuaternion(expoPiece.rotation), objectContainer.transform) as GameObject;
            //newPiece.transform.localScale = (ParseVector3(expoPiece.scale));
        }
    }

    public static Vector3 ParseVector3(string str)
    {
        str = str.Replace("(", "").Replace(")", " ");//Replace "(" and ")" in the string with ""
        string[] s = str.Split(',');
        return new Vector3(float.Parse(s[0]), float.Parse(s[1]), float.Parse(s[2]));
    }

    public static Quaternion ParseQuaternion(string sQuaternion)
    {
        // Remove the parentheses
        if (sQuaternion.StartsWith("(") && sQuaternion.EndsWith(")"))
        {
            sQuaternion = sQuaternion.Substring(1, sQuaternion.Length - 2);
        }

        // split the items
        string[] sArray = sQuaternion.Split(',');

        // store as a Vector3
        Quaternion result = new Quaternion(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]),
            float.Parse(sArray[3]));

        return result;
    }

}
