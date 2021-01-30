using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Data", menuName = "Data/RPG/Item", order = 1)]
public class ItemSO : ScriptableObject
{
    public ItemBaseSO itemBase; 
    public ItemInstance item; 
}

[System.Serializable]
public class ItemInstance 
{
    private ItemBase itemBase; 
    public ItemBase GetBase () {return itemBase;}
    
    public string itemName; 
    public Sprite itemSprite; 
    public bool isStackable = false; 
    public bool isConsumable = false; 
    public enum ItemRarity {COMMON, RARE, EPIC, LEGENDARY}; 
    public ItemRarity itemRarity; 
    public List<Modifier> modifiers; 

    public ItemInstance (string _name, Sprite _sprite, bool _stackable, bool _consumable, ItemRarity _rarity, List<Modifier> _mods = null)
    {
        itemName = _name; 
        itemSprite = _sprite;
        isStackable = _stackable;
        isConsumable = _consumable;
        itemRarity = _rarity;
        
        //Generate Mods or not 
        if(_mods == null)
            modifiers = GenerateMods();
        else
            modifiers = _mods;
    }

    public ItemInstance (ItemSO _itemSO)
    {
        itemName = _itemSO.item.itemName; 
        itemSprite = _itemSO.item.itemSprite; 
        itemRarity = _itemSO.item.itemRarity; 
        modifiers = _itemSO.item.modifiers; 
    }

    private List<Modifier> GenerateMods ()
    {
        return new List<Modifier>();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ItemSO))]
[CanEditMultipleObjects]
public class ItemSOEditor : Editor 
{
    SerializedProperty itemBaseProp;
    SerializedProperty itemProp;

    void OnEnable()
    {
        // Fetch the objects from the GameObject script to display in the inspector
        itemBaseProp = serializedObject.FindProperty("itemBase");
        itemProp = serializedObject.FindProperty("item");
    }

    public override void OnInspectorGUI()
    {
        var ie = (ItemSO)target;

        EditorGUILayout.PropertyField(itemBaseProp, new GUIContent("Item Base"));

        //Gui style for errors 
        GUIStyle errorStyle = new GUIStyle();
        errorStyle.fontStyle = FontStyle.Bold;
        errorStyle.normal.textColor = Color.red;

        if(ie.itemBase != null)
        {
            if(EditorGUILayout.Foldout(true, "Item Base"))
            {
                EditorGUILayout.LabelField("Base Name : " + ie.itemBase.itemBase.baseName);
            }
            for (int i = 0; i < ie.itemBase.itemBase.baseMods.Count; i++)
            {
                EditorGUILayout.LabelField(ie.itemBase.itemBase.baseMods[i].statSO.stat.statName + " - " + ie.itemBase.itemBase.baseMods[i].mode.ToString() + " : " + ie.itemBase.itemBase.baseMods[i].modifierValue.ToString() + " " + ie.itemBase.itemBase.baseMods[i].modeType.ToString());
            }

            EditorGUILayout.PropertyField(itemProp, new GUIContent("Item"));

            if(ie.itemBase.itemBase.baseMods.Count + ie.item.modifiers.Count > ie.itemBase.itemBase.maximumNumberOfMods)
            {
                EditorGUILayout.LabelField("Too much modifiers ! maximum number on this base is : " + ie.itemBase.itemBase.maximumNumberOfMods, errorStyle);
            }
        }
        else
        {
            EditorGUILayout.LabelField("Missing item base !", errorStyle);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif