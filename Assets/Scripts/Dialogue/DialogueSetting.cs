using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu (fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSetting : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languanges sentence;

}

[System.Serializable]
public class Languanges
{
    
    public string portuguese;
    public string english;
}

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSetting))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueSetting ds = (DialogueSetting)target;
        
        Languanges lg = new Languanges();
        lg.portuguese = ds.sentence;

        Sentences sen = new Sentences();
        sen.profile = ds.speakerSprite;
        sen.sentence = lg;
        // base.OnInspectorGUI();

        if(GUILayout.Button("Create dialogue"))
        {
            if(ds.sentence != "")
            {
                ds.dialogues.Add(sen);

                // ds.speakerSprite = null;
                ds.sentence = "";
            }
        }
    }
}

#endif