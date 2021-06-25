using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DataCacheManager {

    public static readonly DataCacheManager instance = new DataCacheManager();

    private static Dictionary<string, DTOList> dtosData = new Dictionary<string, DTOList>();

    public List<DatasDTO> GetDatas(string dtoName)
    {
        return dtosData[dtoName];
    }
    
    public void SetDatas(DTOList dtos)
    {
        dtosData[dtos.dtoName] = dtos;
    }



}
