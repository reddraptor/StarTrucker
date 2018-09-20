using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeNode : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public List<Commodity> GetCommodities()
    {
        return GetComponent<Inventory>().GetCommodities();
    }

    public float GetSellPrice(int index)
    {
        return GetComponent<Inventory>().GetCommodities()[index].worth;
    }

    public float GetBuyPrice(int index)
    {
        return GetComponent<Inventory>().GetCommodities()[index].worth/2;
    }

    public int GetAmount(int index)
    {
        return GetComponent<Inventory>().commodityStorage[index].amount;
    }
}
