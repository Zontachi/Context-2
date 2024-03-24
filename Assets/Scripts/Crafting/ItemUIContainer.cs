using System;
using System.Collections.Generic;
using Itemsystem;
using TMPro;
using UnityEngine;

namespace Crafting
{
    public class ItemUIContainer : MonoBehaviour
    {
        private List<ItemUI> _items = new List<ItemUI>();
        [SerializeField] private GameObject itemUIPrefab;

        private void Start()
        {
            var items = InventoryManager.Instance.GetDictionary;
            foreach (var item in items)
            {
                for (var i = 0; i < item.Value; i++)
                {
                    AddNewUIItem(item.Key);
                }
            }
        }

        public void AddNewUIItem(ItemData item)
        {
            if (_items.Exists(x => x.itemData == item))
            {
                _items.Find(x => x.itemData == item).amountText.text = InventoryManager.Instance.GetAmount(item).ToString();
                return;
            }
            var itemUI = Instantiate(itemUIPrefab, transform, true);
            itemUI.GetComponent<ItemUI>().itemData = item;
            itemUI.GetComponent<ItemUI>().transform.localScale = Vector3.one;
            _items.Add(itemUI.GetComponent<ItemUI>());
        }
    }
}
