using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item 
{
	public string itemName;
	public Sprite icon;
	public float price = 1f;
}

public class ShopScrollList : MonoBehaviour {
	public List<Item> itemList;
	public Transform contentPanel;
	public ShopScrollList otherShop;
	public Text myGoldDisplay;
	public SimpleObjectPool buttonObjectPool;
	public float gold = 20f;

	void Start () {
		RefreshDisplay();
	}

	public void RefreshDisplay()
	{
		myGoldDisplay.text = "Gold: " + gold.ToString();
		RemoveButtons();
		AddButton();
	}
	
	private void AddButton()
	{
		for(int i = 0; i < itemList.Count; i++)
		{
			Item item = itemList[i];
			GameObject newButton = buttonObjectPool.GetObject();
			newButton.transform.SetParent(contentPanel);
			newButton.transform.localScale = new Vector3(1f, 1f, 1f);

			SimpleButton simpleButton = newButton.GetComponent<SimpleButton>();
			simpleButton.Setup(item, this);
		}
	}

	private void RemoveButtons()
	{
		while(contentPanel.childCount > 0)
		{
			GameObject toRemove = transform.GetChild(0).gameObject;
			buttonObjectPool.ReturnObject(toRemove);
		}
	}

	public void TryTransferItemToOhterShop(Item item)
	{
		if(otherShop.gold >= item.price)
		{
			gold += item.price;
			otherShop.gold -= item.price;
			AddItem(item, otherShop);
			RemoveItem(item, this);

			RefreshDisplay();
			otherShop.RefreshDisplay();
		}
	}

	private void AddItem(Item itemToAdd, ShopScrollList shopList)
	{
		shopList.itemList.Add(itemToAdd);
	}

	private void RemoveItem(Item itemToRemove, ShopScrollList shopList)
	{
		for(int i = shopList.itemList.Count - 1; i >= 0; i--)
		{
			if(shopList.itemList[i] == itemToRemove)
			{
				shopList.itemList.RemoveAt(i);
			}
		}
	}
}
