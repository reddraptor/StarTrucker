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
    public Text textBuyingPrice;
    public Text textSellingPrice;
    public Slider sliderUnitAmount;
    public InputField inputFieldUnitAmount;

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

        RefreshUnitAmountSlider();
    }

    private void RefreshUnitAmountSlider()
    {
        sliderUnitAmount.wholeNumbers = true;
        sliderUnitAmount.minValue = 0;
        sliderUnitAmount.maxValue = GetCommodityAmount();
        OnSliderChange();
    }

    public void OnTradeNodeSelection()
    {
        RefreshDropdownCommodities();
    }

    public void OnCommoditiesSelection()
    {
        textBuyingPrice.text = PriceString(GetBuyPrice());
        textSellingPrice.text = PriceString(GetSellPrice());
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

    public float GetSellPrice()
    {
        return planet.tradeNodes[dropdownTradeNodes.value].GetSellPrice(dropdownCommodities.value);
    }

    public float GetBuyPrice()
    {
        return planet.tradeNodes[dropdownTradeNodes.value].GetBuyPrice(dropdownCommodities.value);
    }

    public string PriceString(float price)
    {
        return price.ToString("N2") + " Cr.";
    }

    public int GetCommodityAmount()
    {
        return planet.tradeNodes[dropdownTradeNodes.value].GetAmount(dropdownCommodities.value);
    }

    public string UnitsString(float unitsAmount)
    {
        return ((int)unitsAmount).ToString() + " Units";
    }

    public void OnSliderChange()
    {
        inputFieldUnitAmount.text = UnitsString(sliderUnitAmount.value);
    }
}
