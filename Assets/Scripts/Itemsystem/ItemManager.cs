using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Crafting;
using UnityEngine;

namespace Assets.Scripts.Itemsystem
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
                DontDestroyOnLoad(gameObject);
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
