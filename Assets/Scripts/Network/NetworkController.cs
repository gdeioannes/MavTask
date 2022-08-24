using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class NetworkController : MonoBehaviour
{
    private TextAsset asset;
    public string expoID = "Expo_ID_0001";
    void Start()
    {
        requestDataFromServer(expoID);
    }

    //Change this for a request to a server and retrive data
    public void requestDataFromServer(string id)
    {
        try { 
            asset = (TextAsset)Resources.Load(id + "/ExpoDataModel");
            parseExpoSpaceData(asset.ToString());
        }catch(Exception e)
        {
            Debug.LogError(e);
            throw new Exception("Error parse ExpoModel");
        }
    }

    public void parseExpoSpaceData(string data)
    {
        try { 
            ExpoDataModel expoDataModel = JsonConvert.DeserializeObject<ExpoDataModel>(data);
            addDataToObjectLoaderController(expoDataModel);
        }
        catch(Exception e)
        {
            Debug.LogError(e);
            throw new Exception("Error parse ExpoModel ");
        }
        
    }

    void addDataToObjectLoaderController(ExpoDataModel expoStructureModel)
    {
        LoadController.instance.EceneStructureModel = expoStructureModel;
    }

}
