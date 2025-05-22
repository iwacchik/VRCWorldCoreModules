using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace IwacchiLab.Tools
{
    [CustomPropertyDrawer(typeof(ButtonAttribute))]
    public class ButtonDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var buttonAttribute = (ButtonAttribute)attribute;

            if (GUI.Button(position, buttonAttribute.ButtonLabel))
            {
                if (!Application.isPlaying)
                {
                    Debug.LogWarning("このボタンはプレイモード中にのみ実行できます。");
                    return;
                }
                
                var target = property.serializedObject.targetObject;
                var method = target.GetType().GetMethod(
                    buttonAttribute.MethodName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                );

                if (method != null)
                {
                    method.Invoke(target, null);
                }
                else
                {
                    Debug.LogWarning($"{buttonAttribute.MethodName} メソッドが見つかりません");
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }
    }
}