using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class TestDynamicLoading
{
    //get : file with scene structure(hierarchy and models info)
    //get : expo space file exist
    //set : set file and initial scene settings.
    //set : spawn user in the scene.
    //*get : place holders data and set them in the scene.
    //set : priority loading cue
    //get : set treads and load 3d files

    [Test]
    public void TestGetFileStructureWrongAddress()
    {
        GameObject newGameObject = new GameObject();
        NetworkController networkController = newGameObject.AddComponent<NetworkController>();
        networkController.requestDataFromServer("Expo_ID_0001");
        networkController.returnNum(5);

        Assert.AreEqual(5,networkController.returnNum(5));


        Assert.AreEqual(5, networkController.returnNum(5));

        //Assert.IsNull(networkController.EpoDataModelTextAsset);

        //Assert.That(() => networkController.requestDataFromServer("WRONG_ADDRESS"),
        //         Throws.TypeOf<Exception>());

    }
}
