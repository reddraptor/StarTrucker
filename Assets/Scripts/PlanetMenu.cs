using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetMenu : MonoBehaviour {

    public Planet planet;
    public Dropdown dropdownTradeNodes;
    public Dropdown dropdownCommodities;
    public GameObject panelBuy;
    public GameObject panelSell;
    public Button buttonBuy;
    public Button buttonSell;
    public Text textBuyPrice;
    public Text textSellPrice;

    private void Start()
    {
        RefreshDropdownTradeNodes();
    }

    private void RefreshDropdownTradeNodes()
    {
        dropdownTradeNodes.ClearOptions();

        foreach (TradeNode tradeNode in planet.tradeNodes)
        {
            dropdownTradeNodes.options.Add(new Dropdown.OptionData(tradeNode.name));
        }

        dropdownTradeNodes.RefreshShownValue();

        RefreshDropdownCommodities();
    }

    private void RefreshDropdownCommodities()
    {
        dropdownCommodities.ClearOptions();

        foreach (Commodity commodity in planet.tradeNodes[dropdownTradeNodes.value].GetCommodities())
        {
            dropdownCommodities.options.Add(new Dropdown.OptionData(commodity.name));
        }


        dropdownCommodities.RefreshShownValue();

        OnCommoditiesSelection();
    }

    public void OnTradeNodeSelection()
    {
        RefreshDropdownCommodities();
    }

    public void OnCommoditiesSelection()
    {
        textBuyPrice.text = PriceString(GetBuyPrice());
        textSellPrice.text = PriceString(GetSellPrice());
    }

    public void OnPressBuy()
    {
        buttonBuy.interactable = false;
        buttonSell.interactable = true;

        panelSell.SetActive(false);
        panelBuy.SetActive(true);
    }

    public void OnPressSell()
    {
        buttonSell.interactable = false;
        buttonBuy.interactable = true;

        panelBuy.SetActive(false);
        panelSell.SetActive(true);
    }

    public int GetSellPrice()
    {
        return planet.tradeNodes[dropdownTradeNodes.value].GetSellPrice(dropdownCommodities.value);
    }

    public int GetBuyPrice()
    {
        return planet.tradeNodes[dropdownTradeNodes.value].GetBuyPrice(dropdownCommodities.value);
    }

    public string PriceString(int price)
    {
        return price.ToString() + " Cr.";
    }
}
