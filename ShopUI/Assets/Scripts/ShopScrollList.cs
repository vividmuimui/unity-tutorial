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

	private void RefreshDisplay()
	{
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
}
