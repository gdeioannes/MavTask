using System.IO;
using UnityEngine;

public class JsonFileGenerator {

    string path = "Assets/Resources/";
    string fileName = "ExpoDataModel.json";
    StreamWriter sr;
    
    public void createFile(string expoSpaceName)
    {
        string fileUrl = path + expoSpaceName + "/" + fileName;

        //Create Folder qith name of scene
        if (!Directory.Exists(path + expoSpaceName))
        {
            Directory.CreateDirectory(path + expoSpaceName);
        }

        //Create File
        if (File.Exists(fileUrl))
        {
            Debug.Log(fileName + " already exists.");
            File.Delete(fileUrl);
        }
        
        StreamWriter newFile = File.CreateText(fileUrl);
        sr = newFile;

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