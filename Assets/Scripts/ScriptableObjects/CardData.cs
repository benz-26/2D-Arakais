using UnityEngine;

namespace UnityRoyale
{
    [CreateAssetMenu(fileName = "NewCard", menuName = "Unity Royale/Card Data")]
    public class CardData : ScriptableObject
    {
        [Header("Card graphics")]
        public Sprite cardImage;

        [Header("List of Placeables")]
        public PlaceableData[] placeablesData; // Link to all the Placeables that this card spawns
        public Vector3[] relativeOffsets; // The relative offsets (from cursor) where the placeables will be dropped

        [Header("Splash Animation")]
        public GameObject splashAnimation; // The splash animation GameObject to be summoned
    }
}
