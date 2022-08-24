using System.Collections.Generic;
using UnityEngine;

public class LoadController : MonoBehaviour
{
    
    public static LoadController instance;
    int loadCount=0;
    private ExpoDataModel expoDataModel;
    public GameObject expoObjectsContainer;
    public GameObject player;

    public List<ExpoPieceEntity> expoEntityList= new List<ExpoPieceEntity>();

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
            float distanceWithPlayer = Vector3.Distance(newObj.transform.position,player.transform.position);
            Debug.Log("Distnace" + distanceWithPlayer);

            //Create Expo entity and added to the list
            expoEntityList.Add(new ExpoPieceEntity(expoPiece.assetBundleName,newObj, distanceWithPlayer, placeHolder));
            Debug.Log("Added ExpoEntity Num:"+ expoEntityList.Count);
        }

        sortObjectByDistance();
    }

    void sortObjectByDistance()
    {
        expoEntityList.Sort((p1, p2) => p1.Distance.CompareTo(p2.Distance));
        foreach (ExpoPieceEntity expoEntity in expoEntityList)
        {
            Debug.Log(expoEntity.EntityName);
        }
        startLoadingObjects();
    }

    void startLoadingObjects()
    {
        while(loadCount<concurrentLoad)
        {
            callAPI(loadCount);
            loadCount++;
        }

    }

    void OnContentLoaded(ExpoPieceEntity content)
    {
        //do something cool here
        content.PlaceHolder.transform.Find("Cube").GetComponent<Animator>().Play("EndLoading");
        Debug.Log("Loaded: " + content.EntityName);

        if(loadCount< expoEntityList.Count)
        {
            callAPI(loadCount);
            loadCount++;
        }
    }

    private void callAPI(int num)
    {
        API.instance.GetBundleObject(expoEntityList[num], OnContentLoaded, expoObjectsContainer.transform);
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
