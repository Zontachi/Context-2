using System;
using System.Collections.Generic;
using UnityEngine;

namespace Crafting
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private readonly Dictionary<ItemData, int> _inventoryItems = new Dictionary<ItemData, int>();

        private void Start()
        {
            foreach (ItemData item in Enum.GetValues(typeof(ItemData)))
            {
                _inventoryItems.Add(item, 0);
            }
        }

        public void AddItem(ItemData item, int amount)
        {
            if(!_inventoryItems.TryAdd(item, amount))
                _inventoryItems[item] += amount;
        }
        
        public void RemoveItem(ItemData item, int amount)
        {
            if (!_inventoryItems.ContainsKey(item)) return;
            _inventoryItems[item] -= amount;
            if (_inventoryItems[item] < 0)
                _inventoryItems[item] = 0;
        }
        
        public int GetAmount(ItemData item)
        {
            return _inventoryItems.GetValueOrDefault(item, 0);
        }
        
        public bool HasItem(ItemData item, int amount)
        {
            return _inventoryItems.GetValueOrDefault(item, 0) >= amount;
        }
    }
}