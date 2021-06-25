using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

public class CSVWriter : MonoBehaviour {

    /// <summary>
    /// データパスの指定したパスにcsvファイルを作成する
    /// </summary>
    /// <param name="csv">出力するcsvファイル</param>
    /// <param name="path">出力するパス(ファイル名を含む)</param>
    public void writeCSV(List<List<string>>csv,string path)
    {
        var filePath = Application.dataPath + "/" + path+".csv";
        var fi = new FileInfo(filePath);
        StreamWriter sw = null;
        try
        {
            sw = fi.AppendText();
            write(csv, sw);
        }
        catch(Exception e)
        {
            Debug.LogError(e);
        }
        finally
        {
            if(sw != null) {
                sw.Close();
            }
        }
    }

    private StreamWriter write(List<List<string>>csv,StreamWriter sw)
    {

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
                    list += "," + csv[i][j];
                }
            }
            sw.WriteLine(list);
        }
        return sw;
    }
}
