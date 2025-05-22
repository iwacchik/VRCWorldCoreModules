using UnityEngine;

namespace IwacchiLab.Tools
{
    public class ButtonAttribute : PropertyAttribute
    {
        public string MethodName;
        public string ButtonLabel;

        public ButtonAttribute(string methodName)
        {
            MethodName = methodName;
            ButtonLabel = methodName;
        }

        public ButtonAttribute(string methodName, string buttonLabel)
        {
            MethodName = methodName;
            ButtonLabel = buttonLabel;
        }
    }
}