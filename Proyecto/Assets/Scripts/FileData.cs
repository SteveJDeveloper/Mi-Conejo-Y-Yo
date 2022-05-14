using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;


public class FileData
{
    string file;
    Dictionary<string, object> Data;
    
    public FileData(string file)
    {
        this.Data = new Dictionary<string, object>();
        this.file = file;
    }

    public void Set(string name, object data)
    {
        if (Data.ContainsKey(name)) Data[name] = data;
        else Data.Add(name, data);
    }

    public void Remove(string name)
    {
        Data.Remove(name);
    }

    public object Get(string name)
    {
        if (Data.ContainsKey(name)) return Data[name];
        return null;
    }

    public bool Save() { return Save(this.file); }
    public bool Save(string file)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            FileStream fs = new FileStream(file, FileMode.Create);
            try
            {
                formatter.Serialize(fs, Data);
            }
            catch
            {
                return false;
            }
            finally
            {
                fs.Close();
            }
                return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Load() { return Load(this.file); }
    public bool Load(string file)
    {
        if (!File.Exists(file)) return false;

        FileStream fs = new FileStream(file, FileMode.Open);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Data = (Dictionary<string, object>)formatter.Deserialize(fs);
        }
        catch (System.Runtime.Serialization.SerializationException e)
        {
            UnityEngine.Debug.Log("Failed to deserialize. Reason: " + e.Message);
            return false;
        }
        finally
        {
            fs.Close();
        }

        return true;
    }

    public static FileData Create(string file)
    {
        return new FileData(file);
    }

    public static FileData From(string file)
    {
        FileData fileData = new FileData(file);
        fileData.Load();
        return fileData;
    }

}