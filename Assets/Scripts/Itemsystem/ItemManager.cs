using UnityEngine;

namespace Itemsystem
{
    public class ItemManager: MonoBehaviour
    {
        public static ItemManager Instance { get; private set; }
        public ItemData CurrentItem;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                //DontDestroyOnLoad(gameObject);
            }

            else
            {
                Destroy(this); 
            }
        }

        private void Start()
        {
            CurrentItem = null;
        }
    }

    
}
