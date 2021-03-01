using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Item_", menuName = "Data/RPG/Item", order = 1)]
public class ItemSO : ScriptableObject
{
    public ItemInstance item; 
}

[System.Serializable]
public class ItemInstance 
{
    public enum ItemRarity {COMMON = 1, RARE = 2, EPIC = 3, LEGENDARY = 4}; 
    
    public ItemBaseSO itemBaseSO; 
    [Space]
    public string itemName; 
    public ItemRarity itemRarity; 
    [Space]
    public List<Modifier> modifiers; 

    //Use this in rpg component to instantiate itemsSO into ItemInstances
    public ItemInstance (ItemSO _itemSO)
    {
        itemBaseSO = _itemSO.item.itemBaseSO;
        itemName = _itemSO.item.itemName; 
        itemRarity = _itemSO.item.itemRarity; 
        modifiers = _itemSO.item.modifiers; 
    }

    //Use this in Generation 
    public ItemInstance (ItemBaseSO _baseSO)
    {
        //Assigne base
        itemBaseSO = _baseSO;

        //Choose rarity
        int rar = Random.Range(0, 4);

        if(rar == 0)
            itemRarity = ItemRarity.COMMON;

        else if (rar == 1)
            itemRarity = ItemRarity.RARE;

        else if (rar == 2)
            itemRarity = ItemRarity.EPIC;

        else if (rar == 3)
            itemRarity = ItemRarity.LEGENDARY;


        //Choose name 
        itemName = "Random Name";

        //Populate modifiers from modifier's grid in base item
        modifiers = itemBaseSO.itemBase.modifiersGrid.GetRandomMods(itemRarity, 1, 1, 1, 1);
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