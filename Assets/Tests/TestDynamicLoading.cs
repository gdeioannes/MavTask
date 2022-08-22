using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestDynamicLoading
{
    //get : file with scene structure(hierarchy and models info)
    //get : expo space file
    //set : set file and initial scene settings.
    //set : spawn user in the scene.
    //*get : place holders data and set them in the scene.
    //set : priority loading cue
    //get : set treads and load 3d files

    [Test]
    public void TestGetFileStructure()
    {
        //NetworkController net = new NetworkController();
        //bool response = net.parseData("");
        // Use the Assert class to test conditions
        //Assert.AreEqual(response, false);
    }


    // A Test behaves as an ordinary method
    [Test]
    public void TestDynamicLoadingSimplePasses()
    {
        // Use the Assert class to test conditions
        Assert.AreEqual("hello","hello");
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestDynamicLoadingWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
