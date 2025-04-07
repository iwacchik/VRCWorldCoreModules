
using UnityEngine;
using VRC.SDKBase;

namespace IwacchiLab.Utils
{
    public static class TransformUtility
    {
        public static string GetHierarchyPath(Transform target)
        {
            var sb = new System.Text.StringBuilder(target.name);
        
            var current = target.parent;
            while (Utilities.IsValid(current))
            {
                sb.Insert(0, $"{current.name}/");
                current = current.parent;
            }

            return sb.ToString();
        }
    }
}
