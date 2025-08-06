using System;
using UnityEngine;

namespace Core.Data
{
    [CreateAssetMenu(fileName = "CubeColorsData", menuName = "Scriptable Objects/CubeColorsData")]
    public class CubeColorsData : ScriptableObject
    {
        [SerializeField] private CubeColorEntry[] _entries;

        public Color GetColorForValue(int value)
        {
            int index = Array.FindIndex(_entries, entry => entry.value == value);
            return index >= 0 ? _entries[index].color : Color.white; 
        }


        [Serializable]
        public struct CubeColorEntry
        {
            public int value;
            public Color color;
        }
    }
}