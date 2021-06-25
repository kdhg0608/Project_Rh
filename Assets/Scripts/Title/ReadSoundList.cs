using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadSoundList : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        //TODO
        DTOList data = new DTOList();
        DatasDTO dto = new DatasDTO("test DTO");
        dto.SetDatas(Keys.CreateKeys("key1"), "data1-1");
        dto.SetDatas(Keys.CreateKeys("key2"), "data1-2");
        dto.SetDatas(Keys.CreateKeys("key3"), "data1-3");
        data.Add(dto);

        dto = new DatasDTO("test DTO");
        dto.SetDatas(Keys.CreateKeys("key1"), "data2-1");
        dto.SetDatas(Keys.CreateKeys("key2"), "data2-2");
        dto.SetDatas(Keys.CreateKeys("key3"), "data2-3");
        data.Add(dto);
        DataCacheManager.instance.SetDatas(data);
    }

    private void Start()
    {
        List<DatasDTO> client = DataCacheManager.instance.GetDatas("test DTO");
        foreach(DatasDTO data in client)
        {
            Debug.Log("key1 = " + data.GetDataStruct(Keys.CreateKeys("key1")).data);
            Debug.Log("key2 = " + data.GetDataStruct(Keys.CreateKeys("key2")).data);
            Debug.Log("key3 = " + data.GetDataStruct(Keys.CreateKeys("key3")).data);
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
}
