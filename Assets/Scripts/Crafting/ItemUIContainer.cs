using System.Collections.Generic;
using Crafting;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Crafting
{
    public class ItemUIContainer : MonoBehaviour
    {
        private List<ItemUI> _items = new List<ItemUI>();


        private void Start()
        {
            var _items = GetComponentsInChildren<ItemUI>();

        }

        private void ChangeAmountText(ItemData itemData)
        {
            foreach (var item in _items)
            {
                if(item.itemData == itemData)
                {
                    item.transform.GetComponentInChildren<TextMeshProUGUI>().text = InventoryManager.Instance.GetAmount(item.itemData).ToString();
                }
            }
        }
    }
}
