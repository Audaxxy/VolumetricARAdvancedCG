using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ChangeSceneScript), true)]
public class ChangeSceneEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var picker = target as ChangeSceneScript;
        var oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(picker.myScene);
        var oldKey = serializedObject.FindProperty("mySceneKey").stringValue;
        var oldRegisterOnAwake = serializedObject.FindProperty("registerSceneOnAwake").boolValue;

        serializedObject.Update();

        EditorGUI.BeginChangeCheck();
        var newScene = EditorGUILayout.ObjectField("Scene", oldScene, typeof(SceneAsset), false) as SceneAsset;
        var newKey = EditorGUILayout.TextField("Key", oldKey);
        var newRegisterOnAwake = EditorGUILayout.Toggle("Register Scene On Awake", oldRegisterOnAwake);

        if (EditorGUI.EndChangeCheck())
        {
            var newPath = AssetDatabase.GetAssetPath(newScene);
            var scenePathProperty = serializedObject.FindProperty("myScene");
            var sceneKeyProperty = serializedObject.FindProperty("mySceneKey");
            var registerOnAwakeProperty = serializedObject.FindProperty("registerSceneOnAwake");

            scenePathProperty.stringValue = newPath;
            sceneKeyProperty.stringValue = newKey;
            registerOnAwakeProperty.boolValue = newRegisterOnAwake;
        }
        serializedObject.ApplyModifiedProperties();
    }
}