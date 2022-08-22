using System;
using System.IO;
using UnityEngine;

public class JsonFileGenerator {

    string path = "Assets/Resources/";
    string fileName = "SceneStructure.json";
    StreamWriter sr;


    
    public void createFile(string expoSpaceName)
    {
        string fileUrl = path + expoSpaceName + "/" + fileName;

        if (!Directory.Exists(path + expoSpaceName))
        {
            Directory.CreateDirectory(path + expoSpaceName);
        }

        if (File.Exists(fileUrl))
        {
            Debug.Log(fileName + " already exists.");
            File.Delete(fileUrl);
        }
        
        StreamWriter newFile = File.CreateText(fileUrl);
        sr = newFile;
        //sr.WriteLine("I can write ints {0} or floats {1}, and so on.",
        //    1, 4.2);

    }

    public void addLineFile(string line)
    {
        sr.WriteLine(line);
    }

    public void endFile()
    {
        sr.Close();
    }

}