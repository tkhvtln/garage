using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(Shelf))]
public class ShelfEditor : Editor
{
    Shelf _shelf;

    SerializedProperty _items;
    SerializedProperty _itemListConfig;

    private void OnEnable()
    {
        _shelf = (Shelf)target;

        _itemListConfig = serializedObject.FindProperty("itemListConfig");

        if (_itemListConfig.objectReferenceValue != null)
        {
            SerializedObject itemList = new SerializedObject(_itemListConfig.objectReferenceValue);
            _items = itemList.FindProperty("items");
        }
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        base.OnInspectorGUI();
        GUILayout.Space(10);

        if (_items is null)
            return;

        if (_items.arraySize == 0)
        {
            EditorGUILayout.HelpBox("The list of items in ItemListConfig is empty.", MessageType.Warning);
        }

        for (int i = 0; i < _items.arraySize; ++i) 
        {
            EditorGUILayout.BeginHorizontal();

            SerializedProperty item = _items.GetArrayElementAtIndex(i);
            string itemName = item.objectReferenceValue.name;

            GUILayout.Label(itemName);

            if (GUILayout.Button("Spawn"))
            {
                _shelf.SpawnItem(i);
                EditorUtility.SetDirty(_shelf);
            }

            EditorGUILayout.EndHorizontal();
        }

        GUILayout.Space(10);

        if (GUILayout.Button("Remove last item"))
        {
            _shelf.RemoveLastItem();
            EditorUtility.SetDirty(_shelf);
        }
        if (GUILayout.Button("Remove all items"))
        {
            _shelf.RemoveAllItems();
            EditorUtility.SetDirty(_shelf);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
