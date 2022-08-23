using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class NetworkController : MonoBehaviour
{
    private TextAsset asset;

    void Start()
    {
        requestDataFromServer();
    }

    public void requestDataFromServer()
    {
        asset = (TextAsset)Resources.Load("Expo_ID_0001/SceneStructure");
        Debug.Log(asset);
        parseExpoSpaceData(asset.ToString());
    }

    public void getDataFromServer()
    {
        string data = "";
    }

    void parseExpoSpaceData(string data)
    {
        SceneStructureModel sceneStructureModel = JsonConvert.DeserializeObject<SceneStructureModel>(data);
        LoadController.instance.setObjects("3DObjects", sceneStructureModel.expoPiecesList);
    }
}
