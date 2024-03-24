using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Crafting
{
    public static class UIHelper
    {
        /// <summary>
        /// Checks if the mouse is over a slot
        /// </summary>
        /// <returns>Returns boolean with ray cast result</returns>
        public static bool IsPointerOverGameObject (GameObject obj)
        {
            // Create a new PointerEventData
            var pointerData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            // Create a list of RayCastResults
            var results = new List<RaycastResult>();
            // RayCast from the pointer data to the results
            EventSystem.current.RaycastAll(pointerData, results);
            // Return true if the slot is in the results else false
            return results.Any(result => result.gameObject == obj);
        }
    }
}
