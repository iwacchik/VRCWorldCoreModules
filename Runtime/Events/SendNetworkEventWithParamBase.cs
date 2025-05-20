using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

#if !COMPILER_UDONSHARP && UNITY_EDITOR
using System;
using System.Collections.Generic;
using UdonSharpEditor;
using UnityEditor;
using UnityEditorInternal;
#endif

namespace IwacchiLab.Core.Events
{
    public enum ParamType
    {
        Bool,
        SByte,
        Byte,
        Short,
        UShort,
        Int,
        UInt,
        Long,
        ULong,
        Float,
        Double,
        Vector2,
        Vector3,
        Vector4,
        Quaternion,
        Color,
        Color32,
        Char,
        String,
        VRCUrl,
        IntArray
    }

    public abstract class SendNetworkEventWithParamBase : UdonSharpBehaviour
    {
        [SerializeField] private UdonBehaviour _targetBehavior;
        [SerializeField] private string _eventName;
        [SerializeField] private NetworkEventTarget _eventTarget;

        [SerializeField, HideInInspector] private int _paramNum;

        [SerializeField, HideInInspector] private ParamType _param1Type;
        [SerializeField, HideInInspector] private bool _param1BoolValue;
        [SerializeField, HideInInspector] private sbyte _param1SByteValue;
        [SerializeField, HideInInspector] private byte _param1ByteValue;
        [SerializeField, HideInInspector] private short _param1ShortValue;
        [SerializeField, HideInInspector] private ushort _param1UShortValue;
        [SerializeField, HideInInspector] private int _param1IntValue;
        [SerializeField, HideInInspector] private uint _param1UIntValue;
        [SerializeField, HideInInspector] private long _param1LongValue;
        [SerializeField, HideInInspector] private ulong _param1ULongValue;
        [SerializeField, HideInInspector] private float _param1FloatValue;
        [SerializeField, HideInInspector] private double _param1DoubleValue;
        
        [SerializeField, HideInInspector] private Vector2 _param1Vector2Value;
        [SerializeField, HideInInspector] private Vector3 _param1Vector3Value;
        [SerializeField, HideInInspector] private Vector4 _param1Vector4Value;
        [SerializeField, HideInInspector] private Quaternion _param1QuaternionValue;
        
        [SerializeField, HideInInspector] private Color _param1ColorValue;
        [SerializeField, HideInInspector] private Color32 _param1Color32Value;
        
        [SerializeField, HideInInspector] private char _param1CharValue;
        [SerializeField, HideInInspector] private string _param1StringValue;
        [SerializeField, HideInInspector] private VRCUrl _param1VRCUrlValue;

        [SerializeField, HideInInspector] private int[] _param1IntArrayValue;

        [SerializeField, HideInInspector] private ParamType _param2Type;
        [SerializeField, HideInInspector] private bool _param2BoolValue;
        [SerializeField, HideInInspector] private sbyte _param2SByteValue;
        [SerializeField, HideInInspector] private byte _param2ByteValue;
        [SerializeField, HideInInspector] private short _param2ShortValue;
        [SerializeField, HideInInspector] private ushort _param2UShortValue;
        [SerializeField, HideInInspector] private int _param2IntValue;
        [SerializeField, HideInInspector] private uint _param2UIntValue;
        [SerializeField, HideInInspector] private long _param2LongValue;
        [SerializeField, HideInInspector] private ulong _param2ULongValue;
        [SerializeField, HideInInspector] private float _param2FloatValue;
        [SerializeField, HideInInspector] private double _param2DoubleValue;
        
        [SerializeField, HideInInspector] private Vector2 _param2Vector2Value;
        [SerializeField, HideInInspector] private Vector3 _param2Vector3Value;
        [SerializeField, HideInInspector] private Vector4 _param2Vector4Value;
        [SerializeField, HideInInspector] private Quaternion _param2QuaternionValue;
        
        [SerializeField, HideInInspector] private Color _param2ColorValue;
        [SerializeField, HideInInspector] private Color32 _param2Color32Value;
        
        [SerializeField, HideInInspector] private char _param2CharValue;
        [SerializeField, HideInInspector] private string _param2StringValue;
        [SerializeField, HideInInspector] private VRCUrl _param2VRCUrlValue;

        [SerializeField, HideInInspector] private int[] _param2IntArrayValue;
        
        [SerializeField, HideInInspector] private ParamType _param3Type;
        [SerializeField, HideInInspector] private bool _param3BoolValue;
        [SerializeField, HideInInspector] private sbyte _param3SByteValue;
        [SerializeField, HideInInspector] private byte _param3ByteValue;
        [SerializeField, HideInInspector] private short _param3ShortValue;
        [SerializeField, HideInInspector] private ushort _param3UShortValue;
        [SerializeField, HideInInspector] private int _param3IntValue;
        [SerializeField, HideInInspector] private uint _param3UIntValue;
        [SerializeField, HideInInspector] private long _param3LongValue;
        [SerializeField, HideInInspector] private ulong _param3ULongValue;
        [SerializeField, HideInInspector] private float _param3FloatValue;
        [SerializeField, HideInInspector] private double _param3DoubleValue;
        
        [SerializeField, HideInInspector] private Vector2 _param3Vector2Value;
        [SerializeField, HideInInspector] private Vector3 _param3Vector3Value;
        [SerializeField, HideInInspector] private Vector4 _param3Vector4Value;
        [SerializeField, HideInInspector] private Quaternion _param3QuaternionValue;
        
        [SerializeField, HideInInspector] private Color _param3ColorValue;
        [SerializeField, HideInInspector] private Color32 _param3Color32Value;
        
        [SerializeField, HideInInspector] private char _param3CharValue;
        [SerializeField, HideInInspector] private string _param3StringValue;
        [SerializeField, HideInInspector] private VRCUrl _param3VRCUrlValue;

        [SerializeField, HideInInspector] private int[] _param3IntArrayValue;
        
        [SerializeField, HideInInspector] private ParamType _param4Type;
        [SerializeField, HideInInspector] private bool _param4BoolValue;
        [SerializeField, HideInInspector] private sbyte _param4SByteValue;
        [SerializeField, HideInInspector] private byte _param4ByteValue;
        [SerializeField, HideInInspector] private short _param4ShortValue;
        [SerializeField, HideInInspector] private ushort _param4UShortValue;
        [SerializeField, HideInInspector] private int _param4IntValue;
        [SerializeField, HideInInspector] private uint _param4UIntValue;
        [SerializeField, HideInInspector] private long _param4LongValue;
        [SerializeField, HideInInspector] private ulong _param4ULongValue;
        [SerializeField, HideInInspector] private float _param4FloatValue;
        [SerializeField, HideInInspector] private double _param4DoubleValue;
        
        [SerializeField, HideInInspector] private Vector2 _param4Vector2Value;
        [SerializeField, HideInInspector] private Vector3 _param4Vector3Value;
        [SerializeField, HideInInspector] private Vector4 _param4Vector4Value;
        [SerializeField, HideInInspector] private Quaternion _param4QuaternionValue;
        
        [SerializeField, HideInInspector] private Color _param4ColorValue;
        [SerializeField, HideInInspector] private Color32 _param4Color32Value;
        
        [SerializeField, HideInInspector] private char _param4CharValue;
        [SerializeField, HideInInspector] private string _param4StringValue;
        [SerializeField, HideInInspector] private VRCUrl _param4VRCUrlValue;

        [SerializeField, HideInInspector] private int[] _param4IntArrayValue;

        [SerializeField, HideInInspector] private ParamType _param5Type;
        [SerializeField, HideInInspector] private bool _param5BoolValue;
        [SerializeField, HideInInspector] private sbyte _param5SByteValue;
        [SerializeField, HideInInspector] private byte _param5ByteValue;
        [SerializeField, HideInInspector] private short _param5ShortValue;
        [SerializeField, HideInInspector] private ushort _param5UShortValue;
        [SerializeField, HideInInspector] private int _param5IntValue;
        [SerializeField, HideInInspector] private uint _param5UIntValue;
        [SerializeField, HideInInspector] private long _param5LongValue;
        [SerializeField, HideInInspector] private ulong _param5ULongValue;
        [SerializeField, HideInInspector] private float _param5FloatValue;
        [SerializeField, HideInInspector] private double _param5DoubleValue;
        
        [SerializeField, HideInInspector] private Vector2 _param5Vector2Value;
        [SerializeField, HideInInspector] private Vector3 _param5Vector3Value;
        [SerializeField, HideInInspector] private Vector4 _param5Vector4Value;
        [SerializeField, HideInInspector] private Quaternion _param5QuaternionValue;
        
        [SerializeField, HideInInspector] private Color _param5ColorValue;
        [SerializeField, HideInInspector] private Color32 _param5Color32Value;
        
        [SerializeField, HideInInspector] private char _param5CharValue;
        [SerializeField, HideInInspector] private string _param5StringValue;
        [SerializeField, HideInInspector] private VRCUrl _param5VRCUrlValue;

        [SerializeField, HideInInspector] private int[] _param5IntArrayValue;
        
        private string GetParamFieldName( int index )
        {
            var paramType = ParamType.Int;
            switch (index)
            {
                case 1:
                    paramType = _param1Type;
                    break;
                case 2:
                    paramType = _param2Type;
                    break;
                case 3:
                    paramType = _param3Type;
                    break;
                case 4:
                    paramType = _param4Type;
                    break;
                case 5:
                    paramType = _param5Type;
                    break;
            }
            
            
            switch (paramType)
            {
                case ParamType.Bool: return $"_param{index}BoolValue";
                case ParamType.SByte: return $"_param{index}SByteValue";
                case ParamType.Byte: return $"_param{index}ByteValue";
                case ParamType.Short: return $"_param{index}ShortValue";
                case ParamType.UShort: return $"_param{index}UShortValue";
                case ParamType.Int: return $"_param{index}IntValue";
                case ParamType.UInt: return $"_param{index}UIntValue";
                case ParamType.Long: return $"_param{index}LongValue";
                case ParamType.ULong: return $"_param{index}ULongValue";
                case ParamType.Float: return $"_param{index}FloatValue";
                case ParamType.Double: return $"_param{index}DoubleValue";
                case ParamType.Vector2: return $"_param{index}Vector2Value";
                case ParamType.Vector3: return $"_param{index}Vector3Value";
                case ParamType.Vector4: return $"_param{index}Vector4Value";
                case ParamType.Quaternion: return $"_param{index}QuaternionValue";
                case ParamType.Color: return $"_param{index}ColorValue";
                case ParamType.Color32: return $"_param{index}Color32Value";
                case ParamType.Char: return $"_param{index}CharValue";
                case ParamType.String: return $"_param{index}StringValue";
                case ParamType.VRCUrl: return $"_param{index}VRCUrlValue";
                case ParamType.IntArray: return $"_param{index}IntArrayValue";
                default: return $"_param{index}Unknown";
            }
        }

        protected void SendNetworkEvent()
        {
            if (_paramNum == 0)
            {
                _targetBehavior.SendCustomNetworkEvent(_eventTarget, _eventName);
                return;
            }

            switch (_paramNum)
            {
                case 1:
                {
                    var param1 = GetProgramVariable(GetParamFieldName(1));
                    _targetBehavior.SendCustomNetworkEvent(_eventTarget, _eventName, param1);
                    break;
                }
                case 2:
                {
                    var param1 = GetProgramVariable(GetParamFieldName(1));
                    var param2 = GetProgramVariable(GetParamFieldName(2));
                    _targetBehavior.SendCustomNetworkEvent(_eventTarget, _eventName, param1, param2);
                    break;
                }
                case 3:
                {
                    var param1 = GetProgramVariable(GetParamFieldName(1));
                    var param2 = GetProgramVariable(GetParamFieldName(2));
                    var param3 = GetProgramVariable(GetParamFieldName(3));
                    _targetBehavior.SendCustomNetworkEvent(_eventTarget, _eventName, param1, param2, param3);
                    break;
                }
                case 4:
                {
                    var param1 = GetProgramVariable(GetParamFieldName(1));
                    var param2 = GetProgramVariable(GetParamFieldName(2));
                    var param3 = GetProgramVariable(GetParamFieldName(3));
                    var param4 = GetProgramVariable(GetParamFieldName(4));
                    _targetBehavior.SendCustomNetworkEvent(_eventTarget, _eventName, param1, param2, param3, param4);
                    break;
                }
                case 5:
                {
                    var param1 = GetProgramVariable(GetParamFieldName(1));
                    var param2 = GetProgramVariable(GetParamFieldName(2));
                    var param3 = GetProgramVariable(GetParamFieldName(3));
                    var param4 = GetProgramVariable(GetParamFieldName(4));
                    var param5 = GetProgramVariable(GetParamFieldName(5));
                    _targetBehavior.SendCustomNetworkEvent(_eventTarget, _eventName, param1, param2, param3, param4,
                        param5);
                    break;
                }
            }
        }
    }

#if !COMPILER_UDONSHARP && UNITY_EDITOR
    public class SendNetworkParamEditor : Editor
    {
        [Serializable]
        public class SerializedSendParams : ScriptableObject
        {
            public ParamType Type;
            public bool BoolValue;
            public sbyte SByteValue;
            public byte ByteValue;
            public short ShortValue;
            public ushort UShortValue;
            public int IntValue;
            public uint UIntValue;
            public long LongValue;
            public ulong ULongValue;
            public float FloatValue;
            public double DoubleValue;
            
            public Vector2 Vector2Value;
            public Vector3 Vector3Value;
            public Vector4 Vector4Value;
            public Quaternion QuaternionValue;

            public Color ColorValue;
            public Color Color32Value;
            
            public char CharValue;
            public string StringValue;
            public string VRCUrlValue;
            
            public List<int> IntArrayValue;
        }

        private class SendParamEditorSlot
        {
            public SerializedSendParams SendParams;
            private SerializedObject _serializedObject;

            public SendParamEditorSlot(
                ParamType type = ParamType.Int,
                bool boolValue = false,
                sbyte sbyteValue = 0,
                byte byteValue = 0,
                short shortValue = 0,
                ushort ushortValue = 0,
                int intValue = 0,
                uint uintValue = 0,
                long longValue = 0,
                ulong ulongValue = 0,
                float floatValue = 0f,
                double doubleValue = 0d,
                Vector2? vector2Value = null,
                Vector3? vector3Value = null,
                Vector4? vector4Value = null,
                Quaternion? quaternionValue = null,
                Color? colorValue = null,
                Color32? color32Value = null,
                Char charValue = '\0',
                string stringValue = "",
                string VRCUrlValue = "",
                List<int> intArrayValue = null
            )
            {
                SendParams = CreateInstance<SerializedSendParams>();
                SendParams.Type = type;
                SendParams.BoolValue = boolValue;
                SendParams.SByteValue = sbyteValue;
                SendParams.ByteValue = byteValue;
                SendParams.ShortValue = shortValue;
                SendParams.UShortValue = ushortValue;
                SendParams.IntValue = intValue;
                SendParams.UIntValue = uintValue;
                SendParams.LongValue = longValue;
                SendParams.ULongValue = ulongValue;
                SendParams.FloatValue = floatValue;
                SendParams.DoubleValue = doubleValue;
                SendParams.Vector2Value = vector2Value ?? Vector2.zero;
                SendParams.Vector3Value = vector3Value ?? Vector3.zero;
                SendParams.Vector4Value = vector4Value ?? Vector4.zero;
                SendParams.QuaternionValue = quaternionValue ?? Quaternion.identity;
                SendParams.ColorValue = colorValue ?? Color.clear;
                SendParams.Color32Value = color32Value ?? Color.clear;
                SendParams.CharValue = charValue;
                SendParams.StringValue = stringValue;
                SendParams.VRCUrlValue = VRCUrlValue;
                SendParams.IntArrayValue = intArrayValue ?? new List<int>();

                _serializedObject = new SerializedObject(SendParams);
            }

            public void Update()
            {
                _serializedObject.Update();
            }

            public void Apply()
            {
                _serializedObject.ApplyModifiedProperties();
            }

            public void Dispose()
            {
                if (SendParams != null)
                {
                    DestroyImmediate(SendParams);
                    SendParams = null;
                    _serializedObject = null;
                }
            }

            public SerializedProperty GetTypeSerializedProperty()
            {
                return _serializedObject.FindProperty("Type");
            }

            public SerializedProperty GetParamSerializedProperty() =>
                _serializedObject.FindProperty($"{SendParams.Type}Value");

            public float GetPropertyHeight()
            {
                var property = _serializedObject.FindProperty($"{SendParams.Type}Value");
                // return !property.isArray && SendParams.Type != ParamType.Vector4  ? 0f : EditorGUI.GetPropertyHeight(property, true);
                return EditorGUI.GetPropertyHeight(property, true);
            }
            
            
        }

        private List<SendParamEditorSlot> _paramEditor = new List<SendParamEditorSlot>();
        private ReorderableList _reorderableList;

        private string[] _typeLabels = new[]
        {
            "bool", 
            "sbyte", 
            "byte", 
            "short", 
            "ushort", 
            "int", 
            "uint", 
            "long", 
            "ulong", 
            "float", 
            "double", 
            "Vector2", 
            "Vector3",
            "Vector4",
            "Quaternion",
            "Color",
            "Color32",
            "char",
            "string",
            "VRCUrl",
            "int[]"
        };

        private const int MaxParams = 5;
        private SerializedProperty _paramNumProp;

        private SerializedProperty[] _typeProps;
        private SerializedProperty[] _boolValueProps;
        private SerializedProperty[] _sbyteValueProps;
        private SerializedProperty[] _byteValueProps;
        private SerializedProperty[] _shortValueProps;
        private SerializedProperty[] _ushortValueProps;
        private SerializedProperty[] _intValueProps;
        private SerializedProperty[] _uintValueProps;
        private SerializedProperty[] _longValueProps;
        private SerializedProperty[] _ulongValueProps;
        private SerializedProperty[] _floatValueProps;
        private SerializedProperty[] _doubleValueProps;
        private SerializedProperty[] _vector2ValueProps;
        private SerializedProperty[] _vector3ValueProps;
        private SerializedProperty[] _vector4ValueProps;
        private SerializedProperty[] _quaternionValueProps;
        private SerializedProperty[] _colorValueProps;
        private SerializedProperty[] _color32ValueProps;
        private SerializedProperty[] _charValueProps;
        private SerializedProperty[] _stringValueProps;
        private SerializedProperty[] _vrcUrlValueProps;
        private SerializedProperty[] _intArrayValueProps;

        private void OnEnable()
        {
            FindProperties();
            RefreshFromBehaviorSerialized();

            _reorderableList = new ReorderableList(_paramEditor, typeof(SendParamEditorSlot), true, true,
                true, true)
            {
                drawHeaderCallback = rect => EditorGUI.LabelField(rect, "Send Params"),
                elementHeightCallback = index =>
                {
                    float height = EditorGUIUtility.singleLineHeight * 2 + 12;
                    height += _paramEditor[index].GetPropertyHeight();
                    return height;
                    //return _paramEditor[index].GetPropertyHeight();
                },
                drawElementCallback = (rect, index, isActive, isFocused) =>
                {
                    var paramEditor = _paramEditor[index];
                    paramEditor.Update();

                    var y = rect.y + 2;
                    float fullWidth = rect.width;
                    float line = EditorGUIUtility.singleLineHeight;

                    // Param1〜5 ラベルを表示
                    EditorGUI.LabelField(new Rect(rect.x, y, fullWidth, line), $"Param {index + 1}",
                        EditorStyles.boldLabel);
                    y += line + 2;

                    var enumProp = paramEditor.GetTypeSerializedProperty();
                    var currentValue = enumProp.enumValueIndex;

                    int newIndex = EditorGUI.Popup(new Rect(rect.x, y, fullWidth, line), "Type", currentValue,
                        _typeLabels);
                    //EditorGUI.PropertyField(new Rect(rect.x, y, fullWidth, line), wrapperEditor.GetTypeSerializedProperty());

                    y += line + 4;
                    var test = paramEditor.GetParamSerializedProperty();
                    EditorGUI.PropertyField(new Rect(rect.x, y, fullWidth, line),
                        paramEditor.GetParamSerializedProperty(), new GUIContent("Value"), true);

                    if (GUI.changed)
                    {
                        enumProp.enumValueIndex = newIndex;
                        paramEditor.Apply();
                    }
                },
                onAddCallback = list =>
                {
                    if (_paramEditor.Count >= MaxParams)
                    {
                        return;
                    }

                    Undo.RecordObject(target, "Add Param");
                    _paramEditor.Add(new SendParamEditorSlot());
                },
                onRemoveCallback = list =>
                {
                    if (list.index >= 0 && list.index < _paramEditor.Count)
                    {
                        Undo.RecordObject(target, "Remove Param");
                        _paramEditor[list.index].Dispose();
                        _paramEditor.RemoveAt(list.index);
                    }
                }
            };
        }

        private void OnDisable()
        {
            foreach (var e in _paramEditor)
            {
                e.Dispose();
            }

            _paramEditor.Clear();
        }

        public override void OnInspectorGUI()
        {
            if (UdonSharpGUI.DrawDefaultUdonSharpBehaviourHeader(target)) return;

            serializedObject.Update();

            DrawAllSerializedFieldsExceptScript();
            EditorGUILayout.Space(4);

            if (Event.current.type == EventType.Layout)
            {
                RefreshFromBehaviorSerialized();
            }

            EditorGUI.BeginChangeCheck();
            _reorderableList.DoLayoutList();

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Modify Parameters");
                ApplyBackToBehaviorSerialized();
                EditorUtility.SetDirty(target);
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawAllSerializedFieldsExceptScript()
        {
            var iterator = serializedObject.GetIterator();
            bool enterChildren = true;

            while (iterator.NextVisible(enterChildren))
            {
                enterChildren = false;
                if (iterator.name == "m_Script") continue;

                EditorGUILayout.PropertyField(iterator, true);
            }
        }

        private void FindProperties()
        {
            _typeProps = new SerializedProperty[MaxParams];
            _boolValueProps = new SerializedProperty[MaxParams];
            _sbyteValueProps = new SerializedProperty[MaxParams];
            _byteValueProps = new SerializedProperty[MaxParams];
            _shortValueProps = new SerializedProperty[MaxParams];
            _ushortValueProps = new SerializedProperty[MaxParams];
            _intValueProps = new SerializedProperty[MaxParams];
            _uintValueProps = new SerializedProperty[MaxParams];
            _longValueProps = new SerializedProperty[MaxParams];
            _ulongValueProps = new SerializedProperty[MaxParams];
            _floatValueProps = new SerializedProperty[MaxParams];
            _doubleValueProps = new SerializedProperty[MaxParams];
            _vector2ValueProps = new SerializedProperty[MaxParams];
            _vector3ValueProps = new SerializedProperty[MaxParams];
            _vector4ValueProps = new SerializedProperty[MaxParams];
            _quaternionValueProps = new SerializedProperty[MaxParams];
            _colorValueProps = new SerializedProperty[MaxParams];
            _color32ValueProps = new SerializedProperty[MaxParams];
            _charValueProps = new SerializedProperty[MaxParams];
            _stringValueProps = new SerializedProperty[MaxParams];
            _vrcUrlValueProps = new SerializedProperty[MaxParams];
            _intArrayValueProps = new SerializedProperty[MaxParams];

            _paramNumProp = serializedObject.FindProperty("_paramNum");
            for (int i = 0; i < MaxParams; i++)
            {
                var paramIndex = i + 1;
                _typeProps[i] = serializedObject.FindProperty($"_param{paramIndex}Type");
                _boolValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}BoolValue");
                _sbyteValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}SByteValue");
                _byteValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}ByteValue");
                _shortValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}ShortValue");
                _ushortValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}UShortValue");
                _intValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}IntValue");
                _uintValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}UIntValue");
                _longValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}LongValue");
                _ulongValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}ULongValue");
                _floatValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}FloatValue");
                _doubleValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}DoubleValue");
                _vector2ValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}Vector2Value");
                _vector3ValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}Vector3Value");
                _vector4ValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}Vector4Value");
                _quaternionValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}QuaternionValue");
                _colorValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}ColorValue");
                _color32ValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}Color32Value");
                _charValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}CharValue");
                _stringValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}StringValue");
                _vrcUrlValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}VRCUrlValue");
                _intArrayValueProps[i] = serializedObject.FindProperty($"_param{paramIndex}IntArrayValue");
            }
        }

        private void RefreshFromBehaviorSerialized()
        {
            var count = _paramNumProp.intValue;

            _paramEditor.Clear();
            for (int i = 0; i < count; i++)
            {
                _paramEditor.Add(new SendParamEditorSlot(
                    type: (ParamType)_typeProps[i].enumValueIndex,
                    boolValue: _boolValueProps[i].boolValue,
                    sbyteValue: Convert.ToSByte(_sbyteValueProps[i].intValue),
                    byteValue: Convert.ToByte(_byteValueProps[i].intValue),
                    shortValue: Convert.ToInt16(_shortValueProps[i].intValue),
                    ushortValue: Convert.ToUInt16(_ushortValueProps[i].intValue),
                    intValue: _intValueProps[i].intValue,
                    uintValue: _uintValueProps[i].uintValue,
                    longValue: _longValueProps[i].longValue,
                    ulongValue: _ulongValueProps[i].ulongValue,
                    floatValue: _floatValueProps[i].floatValue,
                    doubleValue: _doubleValueProps[i].doubleValue,
                    vector2Value: _vector2ValueProps[i].vector2Value,
                    vector3Value: _vector3ValueProps[i].vector3Value,
                    vector4Value: _vector4ValueProps[i].vector4Value,
                    quaternionValue: _quaternionValueProps[i].quaternionValue,
                    colorValue: _colorValueProps[i].colorValue,
                    color32Value: ConvertToColor32(_color32ValueProps[i].colorValue),
                    charValue: Convert.ToChar(_charValueProps[i].intValue),
                    stringValue: _stringValueProps[i].stringValue,
                    VRCUrlValue: ((VRCUrl)_vrcUrlValueProps[i].boxedValue).Get(),
                    intArrayValue: ReadListFromSerializedProperty(_intArrayValueProps[i], sp => sp.intValue)
                ));
            }
        }

        private void ApplyBackToBehaviorSerialized()
        {
            _paramNumProp.intValue = _paramEditor.Count;
            for (int i = 0; i < _paramEditor.Count; i++)
            {
                var sendParams = _paramEditor[i].SendParams;
                _typeProps[i].enumValueIndex = (int)sendParams.Type;
                _boolValueProps[i].boolValue = sendParams.BoolValue;
                _sbyteValueProps[i].intValue = sendParams.SByteValue;
                _byteValueProps[i].intValue = sendParams.ByteValue;
                _shortValueProps[i].intValue = sendParams.ShortValue;
                _ushortValueProps[i].intValue = sendParams.UShortValue;
                _intValueProps[i].intValue = sendParams.IntValue;
                _uintValueProps[i].uintValue = sendParams.UIntValue;
                _longValueProps[i].longValue = sendParams.LongValue;
                _ulongValueProps[i].ulongValue = sendParams.ULongValue;
                _floatValueProps[i].floatValue = sendParams.FloatValue;
                _doubleValueProps[i].doubleValue = sendParams.DoubleValue;
                _vector2ValueProps[i].vector2Value = sendParams.Vector2Value;
                _vector3ValueProps[i].vector3Value = sendParams.Vector3Value;
                _vector4ValueProps[i].vector4Value = sendParams.Vector4Value;
                _quaternionValueProps[i].quaternionValue = sendParams.QuaternionValue;
                _colorValueProps[i].colorValue = sendParams.ColorValue;
                _color32ValueProps[i].colorValue = sendParams.Color32Value;
                _charValueProps[i].intValue = sendParams.CharValue;
                _stringValueProps[i].stringValue = sendParams.StringValue;
                _vrcUrlValueProps[i].boxedValue = new VRCUrl(sendParams.VRCUrlValue);
                WriteListToSerializedProperty(_intArrayValueProps[i], sendParams.IntArrayValue, (sp, v) => sp.intValue = v );
            }
        }

        /// <summary>
        /// SerializedProperty(配列)から読み取ってListに代入
        ///
        /// <para>使用例<br/>
        /// int の読み取り<br/>
        /// List&lt;int&gt; intList = ReadListFromSerializedProperty(arrayProp, p => p.intValue);<br/>
        /// float の読み取り<br/>
        /// List&lt;float&gt; floatList = ReadListFromSerializedProperty(arrayProp, p => p.floatValue);<br/>
        /// string の読み取り<br/>
        /// List&lt;string&gt; stringList = ReadListFromSerializedProperty(arrayProp, p => p.stringValue);</para>
        /// </summary>
        private static List<T> ReadListFromSerializedProperty<T>(SerializedProperty arrayProp,
            Func<SerializedProperty, T> valueGetter)
        {
            var result = new List<T>();

            if (arrayProp == null || !arrayProp.isArray) return result;

            for (int i = 0; i < arrayProp.arraySize; i++)
            {
                var element = arrayProp.GetArrayElementAtIndex(i);
                result.Add(valueGetter(element));
            }

            return result;
        }

        /// <summary>
        /// ListからSerializedProperty(配列データ)を反映
        ///
        /// 使用例
        /// WriteListToSerializedProperty(intArrayProp, intList, (p, v) => p.intValue = v);
        /// WriteListToSerializedProperty(floatArrayProp, floatList, (p, v) => p.floatValue = v);
        /// </summary>
        private static void WriteListToSerializedProperty<T>(SerializedProperty arrayProp, List<T> values,
            Action<SerializedProperty, T> valueSetter)
        {
            arrayProp.arraySize = values.Count;

            for (int i = 0; i < values.Count; i++)
            {
                valueSetter(arrayProp.GetArrayElementAtIndex(i), values[i]);
            }
        }
        
        private static Color32 ConvertToColor32(Color color)
        {
            return new Color32(
                (byte)(color.r * 255f),
                (byte)(color.g * 255f),
                (byte)(color.b * 255f),
                (byte)(color.a * 255f)
            );
        }
    }
#endif
}