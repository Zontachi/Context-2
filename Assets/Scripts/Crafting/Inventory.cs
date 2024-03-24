using System;
using System.Collections.Generic;
using UnityEngine;

namespace Crafting
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory Instance;
        
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

        private readonly Dictionary<Items, int> _inventoryItems = new Dictionary<Items, int>();

        private void Start()
        {
            foreach (Items item in Enum.GetValues(typeof(Items)))
            {
                _inventoryItems.Add(item, 0);
            }
        }

        public void AddItem(Items item, int amount)
        {
            if(!_inventoryItems.TryAdd(item, amount))
                _inventoryItems[item] += amount;
        }
        
        public void RemoveItem(Items item, int amount)
        {
            if (!_inventoryItems.ContainsKey(item)) return;
            _inventoryItems[item] -= amount;
            if (_inventoryItems[item] < 0)
                _inventoryItems[item] = 0;
        }
        
        public int GetAmount(Items item)
        {
            return _inventoryItems.GetValueOrDefault(item, 0);
        }
        
        public bool HasItem(Items item, int amount)
        {
            return _inventoryItems.GetValueOrDefault(item, 0) >= amount;
        }
    }
}