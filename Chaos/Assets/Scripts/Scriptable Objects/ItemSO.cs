using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Data", menuName = "Data/RPG/Item", order = 1)]
public class ItemSO : ScriptableObject
{
    public ItemInstance item; 
}

[System.Serializable]
public class ItemInstance 
{
    public enum ItemRarity {COMMON, RARE, EPIC, LEGENDARY}; 
    
    public ItemBaseSO itemBaseSO; 
    [Space]
    public string itemName; 
    public ItemRarity itemRarity; 
    [Space]
    public List<Modifier> modifiers; 

    public ItemInstance (ItemSO _itemSO)
    {
        itemBaseSO = _itemSO.item.itemBaseSO;
        itemName = _itemSO.item.itemName; 
        itemRarity = _itemSO.item.itemRarity; 
        modifiers = _itemSO.item.modifiers; 
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ItemSO), true)]
[CanEditMultipleObjects]
public class ItemSOEditor : Editor 
{
    SerializedProperty itemInstanceProp;

    void OnEnable()
    {
        // Fetch the objects from the GameObject script to display in the inspector
        itemInstanceProp = serializedObject.FindProperty("item");
    }

    public override void OnInspectorGUI()
    {
        var ie = (ItemSO)target;

        //Gui style for errors 
        GUIStyle errorStyle = new GUIStyle();
        errorStyle.fontStyle = FontStyle.Bold;
        errorStyle.normal.textColor = Color.red;

        if(ie.item.itemBaseSO == null)
        {
            EditorGUILayout.LabelField("Missing item base !", errorStyle);
        }
        else
        {
            EditorGUI.BeginDisabledGroup(true);
            SerializedObject newserobj = new SerializedObject(itemInstanceProp.FindPropertyRelative("itemBaseSO").objectReferenceValue);
            EditorGUILayout.PropertyField(newserobj.FindProperty("itemBase"));   
            newserobj.ApplyModifiedProperties();
            EditorGUI.EndDisabledGroup();
        }

        EditorGUILayout.PropertyField(itemInstanceProp, new GUIContent("item"));
        serializedObject.ApplyModifiedProperties();
    }
}
#endif