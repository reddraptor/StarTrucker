using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [System.Serializable]
    public class CommodityStore { public Commodity commodity; public int amount; }

    public CommodityStore[] commodityStorage;

    public List<Commodity> GetCommodities()
    {
        List<Commodity> commodities = new List<Commodity>();

        foreach (CommodityStore commodityStore in commodityStorage)
        {
            commodities.Add(commodityStore.commodity);
        }

        return commodities;
    }

}
