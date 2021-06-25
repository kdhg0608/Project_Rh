using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTOList : List<DatasDTO> {

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

    public void SetDtoName(string dtoName)
    {
        this.dtoName = dtoName;
    }

    new public void Add(DatasDTO item)
    {
        if(dtoName == null || dtoName == item.dtoName)
        {
            dtoName = item.dtoName;
            base.Add(item);
        }
    }
}
