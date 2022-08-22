using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;


public class SceneStructure : MonoBehaviour
{
    JsonFileGenerator jsonFileGenerator = new JsonFileGenerator();
    public GameObject objectContainer;
    public string expoSpaceName = "Place Holder";
    SceneStructureModel sceneStructureModel = new SceneStructureModel();

    public void generateStructureFile()
    {
        sceneStructureModel.ExpoName = expoSpaceName;
        jsonFileGenerator.createFile(expoSpaceName);

        foreach (Transform child in objectContainer.transform)
        {
            ExpoPiece expoPiece = new ExpoPiece();
            expoPiece.assetBundleName = child.gameObject.name;
            expoPiece.position = child.position.ToString();
            expoPiece.rotation = child.localRotation.ToString();
            expoPiece.scale= child.localScale.ToString();
            expoPiece.size= child.GetComponent<Renderer>().bounds.ToString();
            sceneStructureModel.expoPiecesList.Add(expoPiece);

        }
        string objSer = JsonConvert.SerializeObject(sceneStructureModel).ToString();
        jsonFileGenerator.addLineFile(objSer);
        jsonFileGenerator.endFile();

        Debug.Log("Create Structure File");
    }
}
