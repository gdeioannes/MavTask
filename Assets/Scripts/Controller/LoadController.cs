using System.Collections.Generic;
using UnityEngine;

public class LoadController : MonoBehaviour
{
    
    public static LoadController instance;
    private ExpoDataModel expoDataModel;
    public GameObject expoObjectsContainer;
    public GameObject player;

    public List<ExpoPieceEntity> loadExpoEntityList= new List<ExpoPieceEntity>();

    //Number defines how many loaded objects at the same time
    private int concurrentLoad = 4;

    public ExpoDataModel EceneStructureModel
    {
        get => expoDataModel;
        set {
            expoDataModel = value;
            setExpoObjects();
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void setExpoObjects()
    {
        Debug.Log("Set Object:"+ expoDataModel.expoPiecesList.Count);
        foreach (ExpoPiece expoPiece in expoDataModel.expoPiecesList)
        {
            //Parse Data from expoObjects
            Vector3 position = DataParsers.ParseVector3(expoPiece.position);
            Quaternion rotation = DataParsers.ParseQuaternion(expoPiece.rotation);
            Vector3 scale = DataParsers.ParseVector3(expoPiece.scale);

            GameObject placeHolder = createPlaceHolder(position, rotation, scale);

            GameObject newObj = new GameObject(expoPiece.assetBundleName);
            newObj.transform.position = position;
            newObj.transform.rotation= rotation;
            newObj.transform.localScale = scale;
           

            //Create Expo entity and added to the list
            loadExpoEntityList.Add(new ExpoPieceEntity(expoPiece.assetBundleName,newObj, placeHolder));
        }

        sortObjectByDistance();
        startLoadingObjects();
    }

    void sortObjectByDistance()
    {
        foreach (ExpoPieceEntity expoEntity in loadExpoEntityList) {
            expoEntity.Distance= Vector3.Distance(expoEntity.PieceGameObject.transform.position, player.transform.position);
        }

        loadExpoEntityList.Sort((p1, p2) => p1.Distance.CompareTo(p2.Distance));
        foreach (ExpoPieceEntity expoEntity in loadExpoEntityList)
        {
            Debug.Log(expoEntity.EntityName);
        }
    }

    void startLoadingObjects()
    {
        
        while (concurrentLoad>=0)
        {
            callAPI();
            concurrentLoad--;
        }

    }

    private void callAPI()
    {
        API.instance.GetBundleObject(loadExpoEntityList[0], OnContentLoaded, expoObjectsContainer.transform);
        loadExpoEntityList.RemoveAt(0);
    }

    void OnContentLoaded(ExpoPieceEntity content)
    {
        //do something cool here
        content.PlaceHolder.transform.Find("Cube").GetComponent<Animator>().Play("EndLoading");
        Debug.Log("Loaded: " + content.EntityName + "Left:"+ loadExpoEntityList.Count);

        if (loadExpoEntityList.Count>=0)
        {
            sortObjectByDistance();
            callAPI();
            
        }
    }

    private GameObject createPlaceHolder(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        //Instantiate Place Holders
        GameObject placeHolder = Instantiate(
            Resources.Load("Prefab/PlaceHolder"),
            position,
            rotation,
            expoObjectsContainer.transform
            ) as GameObject;
        placeHolder.transform.localScale = scale;
        return placeHolder;
    }
}
