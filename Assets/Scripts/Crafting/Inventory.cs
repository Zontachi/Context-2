using System;
using System.Collections.Generic;
using System.Linq;
using Itemsystem;
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
        [SerializeField] private int startingAmounts = 0;
        [SerializeField] private List<ItemData> itemsDataScriptableObjects;

        private void Start()
        {
            foreach (var item in itemsDataScriptableObjects)
            {
                AddItem(item, startingAmounts);
            }
        }
        
        public Dictionary<ItemData, int> GetDictionary => _inventoryItems;
        
        public void AddItem(ItemData item, int amount)
        {
            if(item == null) return; 
            if (!_inventoryItems.ContainsKey(item))
            {
                _inventoryItems.Add(item, amount);
                FindObjectOfType<ItemUIContainer>()?.AddNewUIItem(item);
            }
            else
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