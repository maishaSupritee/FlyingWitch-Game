using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //needed for input and output from files
using System;
using System.Linq;

public static class FileHandler
{
    //generic type, T, means it can be of any type: string, array, etc

    /* a generic file handler can be used not only with 1 specific
    script like our input one but also other scripts where we want to save/load data from our game
    making the file handler more generic by using T, 
    T is defined by the script that calls this method/function */
    public static void SaveToJSON<T>(List<T> toSave, string filename)
    {
        Debug.Log(GetPath(filename));
        //converting our list we want to save in JSON to an array first then feeding it to the ToJson function from the JsonHelper class
        string content = JsonHelper.ToJson<T>(toSave.ToArray());
        WriteFile(GetPath(filename), content);
    }

    public static void SaveToJSON<T>(T toSave, string filename) //will save 1 object and not a list to JSON
    {
        Debug.Log(GetPath(filename));
        string content = JsonUtility.ToJson(toSave);
        WriteFile(GetPath(filename), content);
    }

    public static List<T> ReadListFromJSON<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));
        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return new List<T>(); //empty string as null/empty content will lead to error
        }
        List<T> result = JsonHelper.FromJson<T>(content).ToList(); //we are getting the content in an array form so we need to convert it to list first
        return result;
    }

    public static T ReadFromJSON<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));
        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return default(T);
        }
        T result = JsonUtility.FromJson<T>(content); //we are getting the content in an array form so we need to convert it to list first
        return result;
    }
    private static string GetPath(string filename)
    {
        return Application.persistentDataPath + "/" + filename; //give just file name and get the full path on device of that filename
    }

    private static void WriteFile(string path, string content)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create); //create the file if it doesn't exist/override it if it exists

        using (StreamWriter writer = new StreamWriter(fileStream)) //writing the content in the file we just created
        {
            writer.Write(content);
        }

    }

    private static string ReadFile(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return ""; //empty string if file doesn't exist

    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint) //takes a generic array and creates a new object of type wrapper
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint); //now the array is no longer in the top level but wrapped in a key called "Items" and the value being the array
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items; //generic array
    }
}