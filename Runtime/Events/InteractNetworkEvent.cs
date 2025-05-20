using UdonSharp;
using UnityEditor;

namespace IwacchiLab.Core.Events
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class InteractNetworkEvent : SendNetworkEventWithParamBase
    {
        public override void Interact()
        {
            SendNetworkEvent();
        }
    }

#if !COMPILER_UDONSHARP && UNITY_EDITOR
    [CustomEditor(typeof(InteractNetworkEvent))]
    public sealed class InteractNetworkEventEditor : SendNetworkParamEditor
    {
    }
#endif
}