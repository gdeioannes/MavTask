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
    //*get : place holders data and set them in the scene.
    //set : priority loading cue
    //get : set treads and load 3d files

    [Test]
    public void TestGetFileStructureCorrectAddress()
    {
        GameObject networkControllerObj = new GameObject();
        NetworkController networkController = networkControllerObj.AddComponent<NetworkController>();

        GameObject loadControllerObj = new GameObject();
        LoadController loadController = loadControllerObj.AddComponent<LoadController>();

        networkController.requestDataFromServer("Expo_ID_0001");

        Assert.AreEqual(5,networkController.returnNum(5));

        //Assert.IsNull(networkController.EpoDataModelTextAsset);

        //Assert.That(() => networkController.requestDataFromServer("WRONG_ADDRESS"),
        //         Throws.TypeOf<Exception>());

    }

    [Test]
    public void TestUtilitiesCorrectParse()
    {
        string parseVector3 = "(10.29, 0.99, -0.01)";
        Vector3 vector3 =  new Vector3(10.29f, 0.99f, -0.01f);

        Assert.AreEqual(vector3, DataParsers.ParseVector3(parseVector3));

        string parseQuaternion = "(-0.70711, 0.00000, 0.00000, 0.70711)";
        Quaternion quaternion = new Quaternion(-0.70711f, 0.00000f, 0.00000f, 0.70711f);

        Assert.AreEqual(quaternion, DataParsers.ParseQuaternion(parseQuaternion));
    }

    [Test]
    public void TestUtilitiesWrongParse()
    {
        string parseVector3 = "(10.29, 0.99, -0.01)";
        Vector3 vector3 = new Vector3(10.291f, 0.99f, -0.01f);

        Assert.AreNotEqual(vector3, DataParsers.ParseVector3(parseVector3));

        string parseQuaternion = "(-0.70711, 0.00000, 0.00000, 0.70711)";
        Quaternion quaternion = new Quaternion(-0.707111f, 0.00000f, 0.00000f, 0.707111f);

        Assert.AreNotEqual(quaternion, DataParsers.ParseQuaternion(parseQuaternion));
    }
}
