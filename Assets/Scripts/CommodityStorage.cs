using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "commodityStorage", menuName = "Commodity Storage")]
public class CommodityStorage : ScriptableObject {

    [System.Serializable]
    public class CommodityStore { public Commodity commodity; public int  amount; }

    public List<CommodityStore> storage;


}
