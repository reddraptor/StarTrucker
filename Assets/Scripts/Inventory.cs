using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [System.Serializable]
    public class CommodityStore { public Commodity commodity; public int Amount; }

    public CommodityStore[] CommodityStorage;

    public List<Commodity> GetCommodities()
    {
        List<Commodity> commodities = new List<Commodity>();

        foreach (CommodityStore commodityStore in CommodityStorage)
        {
            commodities.Add(commodityStore.commodity);
        }

        return commodities;
    }

}
