using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetMenu : MonoBehaviour {

    public Planet planet;
    public Dropdown dropdownTradeNodes;
    public Dropdown dropdownCommodities;
    public Button button_buy;
    public Button button_sell;
    public Text text_buyPrice;
    public Text text_sellPrice;

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
        priceText.text = planet.tradeNodes[dropdownTradeNodes.value].GetSellPrice(dropdownCommodities.value).ToString() + " Cr.";
    }

    public void OnPressBuy()
    {

    }

    public void OnPressSell()
    {

    }
}
