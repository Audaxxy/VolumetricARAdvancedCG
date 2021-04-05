//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor.Animations;
//
//public class SimpleRecordAnimation : MonoBehaviour
//{
//    [SerializeField]
//    public AnimationClip clipToWriteTo;
//
//    private GameObjectRecorder gor;
//
//    private void Start()
//    {
//        clipToWriteTo.ClearCurves();
//
//        gor = new GameObjectRecorder(gameObject);
//        gor.BindComponent(transform);
//    }
//
//    private void LateUpdate()
//    {
//        if (clipToWriteTo == null)
//        {
//            Debug.LogError("ERROR! NO CLIP!");
//            return;
//        }
//
//        gor.TakeSnapshot(Time.deltaTime);
//    }
//
//    private void OnDestroy()
//    {
//        if (gor.isRecording)
//        {
//            gor.SaveToClip(clipToWriteTo);
//        }
//
//        Destroy(gor);
//    }
//}
