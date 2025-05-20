using UdonSharp;
using UnityEngine;
using VRC.Udon;

namespace IwacchiLab.Core.Events
{
    public class InteractEvent : UdonSharpBehaviour
    {
        [SerializeField] private UdonBehaviour[] _behaviours;
        [SerializeField] private string _eventName;

        public override void Interact()
        {
            for (int i = 0, n = _behaviours.Length; i < n; i++)
            {
                _behaviours[i].SendCustomEvent(_eventName);
            }
        }
    }
}