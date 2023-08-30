using UnityEngine;

namespace UnityRoyale
{
    public class PlaceableDataOverrides : MonoBehaviour
    {
        public PlaceableData characterToOverride; // The original character data to override
        public PlaceableData overrideCharacterData; // The character data to use as an override

        private void Start()
        {
            // Check if both the original and override characters are assigned
            if (characterToOverride != null && overrideCharacterData != null)
            {
                // Override the values of the original character data with the override character data
                characterToOverride.attackRatio = overrideCharacterData.attackRatio;
                characterToOverride.damagePerAttack = overrideCharacterData.damagePerAttack;
                characterToOverride.attackRange = overrideCharacterData.attackRange;
                characterToOverride.hitPoints = overrideCharacterData.hitPoints;

                // You can override additional properties if needed

                // Use the modified character data as needed in the current scene
                // For example, you can assign it to a script that requires the PlaceableData
            }
            else
            {
                Debug.LogError("Character data or override data is not assigned.");
            }
        }
    }
}
