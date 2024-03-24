using Crafting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Itemsystem
{
    [RequireComponent (typeof(Image))]

    public class ItemUI: MonoBehaviour
    {
        public ItemData itemData;
        public TextMeshProUGUI amountText;
  
        private void Start()
        {
            GetComponent<Image> ().sprite = itemData.itemSprite; 
        }

        private void Update()
        {
            amountText.text = InventoryManager.Instance.GetAmount(itemData).ToString();
            
            if (!Input.GetMouseButtonDown(0)) return;
            if(InventoryManager.Instance.GetAmount(itemData) <= 0) return;
            if (UIHelper.IsPointerOverGameObject(gameObject))
                ItemManager.Instance.CurrentItem = itemData;
        }
    }
}