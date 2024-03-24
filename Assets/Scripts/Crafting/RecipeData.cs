using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Crafting
{
    [CreateAssetMenu(menuName = ("Recipe/Recipe Data"))]
    public class RecipeData : ScriptableObject
    {
        public List<ItemData> data = new List<ItemData>() { null, null, null};

        public ItemData resultItem;
    }
}
