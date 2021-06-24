using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class CSVWriter : MonoBehaviour
{
    public void WriteCSV(List<List<string>> csv, string path)
    {
        var filePath = Application.dataPath + " /" + path + " .csv";
        var fi = new FileInfo(filePath);
        StreamWriter sw = null; 
        
        try
        {
            sw = fi.AppendText();
            for (var i = 0; i < csv.Count; i++)
            {
                string list = "";
                for (var j = 0; j < csv[i].Count; j++)
                {
                    if (list == "")
                    {
                        list += csv[i][j];
                    }
                    else
                    {
                        list += " , " + csv[i][j];
                    }
                }
                sw.WriteLine(list);
            }
        }catch(Exception e)
        {
            Debug.LogError(e);
        }finally
        {
            if(sw != null)
            {
                sw.Close();
            }
        }
    }
}