using System.Collections;
using System.Collections.Generic;

public class DatasDTO{

    private Dictionary<string, DataStruct> dataDto = new Dictionary<string, DataStruct>();

    private List<string> impKeys = new List<string>();
    public List<string> keys
    {
        get
        {
            return impKeys;
        }

        private set
        {
            impKeys = value;
        }
    }

    private int impLenght = 0;
    public int lenght
    {
        get
        {
            return impLenght;
        }
        private set
        {
            impLenght = value;
        }
    }


    private string impDtoName;
    public string dtoName
    {
        get
        {
            return impDtoName;
        }

        private set
        {
            impDtoName = value;
        }
    }


    public struct DataStruct
    {
        private object impData;
        public object data
        {
            get
            {
                return impData;
            }

            private set
            {
                impData = value;
            }
        }

        public void SetData(object data)
        {
            this.data = data;
        }

    }

    public DatasDTO(string dtoName)
    {
        this.dtoName = dtoName;
    }

    public void SetDatas(Keys keys,object data)
    {
        lenght++;
        this.keys.Add(keys.key);
        dataDto.Add(keys.key,CreateDataStruct(data));
    }

    public DataStruct GetDataStruct(Keys key)
    {
        return dataDto[key.key];
    }

    public DataStruct CreateDataStruct(object data)
    {
        DataStruct dataStruct = new DataStruct();
        dataStruct.SetData(data);
        return dataStruct;
    }





}
