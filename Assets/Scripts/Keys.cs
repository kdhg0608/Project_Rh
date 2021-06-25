using System.Collections;
using System.Collections.Generic;

public class Keys {

    private string impKey;

    public string key
    {
        get
        {
            return impKey.GetHashCode().ToString();
        }
        private set
        {
            impKey = value;
        }
    }

    public Keys(string key)
    {
        this.key = key;
    }

    public static Keys CreateKeys(params string[] keys)
    {
        return new Keys(CreateKey(keys));
    }

    private static string CreateKey(string[] keys)
    {
        var returnKey = "";
        foreach(string key in keys)
        {
            returnKey += key;
        }
        return returnKey;

    }

}
