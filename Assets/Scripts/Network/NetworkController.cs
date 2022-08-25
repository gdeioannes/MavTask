using UnityEngine;
using Newtonsoft.Json;
using System;

public class NetworkController : MonoBehaviour
{
    private TextAsset epoDataModelTextAsset;
    public string expoID = "Expo_ID_0001";

    public TextAsset EpoDataModelTextAsset { get => epoDataModelTextAsset; set => epoDataModelTextAsset = value; }

    void Start()
    {
        requestDataFromServer(expoID);
    }

    //Change this for a request to a server and retrive data
    public void requestDataFromServer(string id)
    {
        try { 
            epoDataModelTextAsset = (TextAsset)Resources.Load(id + "/ExpoDataModel");
            Debug.Log(epoDataModelTextAsset.ToString());
            parseExpoSpaceData(epoDataModelTextAsset.ToString());
        }catch(Exception e)
        {
            Debug.LogError(e);
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
        }
        
    }

    void addDataToObjectLoaderController(ExpoDataModel expoStructureModel)
    {
        
        LoadController.instance.EceneStructureModel = expoStructureModel;
        
    }

    public int returnNum(int num)
    {
        return num;
    } 

}
