using System.Collections.Generic;
using Itemsystem;
using UnityEngine;

namespace Crafting
{
    [CreateAssetMenu(menuName = ("Recipe/Recipe Data"))]
    public class RecipeData : ScriptableObject
    {
        public List<ItemData> data = new List<ItemData>() { null, null, null};

        public ItemData resultItem;
    }
}
