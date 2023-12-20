using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Assets.Script
{
    public class LogicGate : MonoBehaviour
    {
        [SerializeField] List<MonoBehaviour> actionnables = new List<MonoBehaviour>();
        [SerializeField] List<MonoBehaviour> actionners = new List<MonoBehaviour>();
        private bool state = false;

        private void Awake()
        {
            foreach (IActionner actionner in actionners)
            {
                actionner.OnStateUpdate += OnStatusChange;
            }
        }

        
        private void OnStatusChange()
        {
            bool isTrue = true;
            foreach (IActionner actionner in actionners)
            {
                isTrue &= actionner.State;
            }

            foreach(IActionnable actionnable in actionnables)
            {
                if(isTrue)
                {
                    actionnable.TurnOn();
                }
                else
                {
                    actionnable.TurnOff();
                }
            }
        }
        #if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Vector3 position = transform.position;

            foreach(MonoBehaviour actionner in actionners)
            {
                Vector3 actionnerPos = actionner.gameObject.transform.position;
                float halfHeight = (position.y - actionnerPos.y)*0.5f ;
                Vector3 tangentOffset = Vector3.up * halfHeight;


                Handles.DrawBezier(
                    transform.position,
                    actionner.gameObject.transform.position, 
                    position - tangentOffset, 
                    actionnerPos + tangentOffset, 
                    pickColor(actionner),
                    EditorGUIUtility.whiteTexture,
                    1
                    );

                Handles.color = Color.white;
            }

            foreach (MonoBehaviour actionnable in actionnables)
            {
                Vector3 actionnerPos = actionnable.gameObject.transform.position;
                float halfHeight = (position.y - actionnerPos.y) * 0.5f;
                Vector3 tangentOffset = Vector3.up * halfHeight;


                Handles.DrawBezier(transform.position, actionnable.gameObject.transform.position, position - tangentOffset, actionnerPos + tangentOffset, pickColor(actionnable), EditorGUIUtility.whiteTexture, 1);
                Handles.color = Color.white;
            }

        }

        private Color pickColor(MonoBehaviour target)
        {
            if(target is IActionner)
            {
                if ((target as IActionner).State)
                {
                    return Color.green;
                }
                else
                {
                    return Color.red;
                }
            }
            else if(target is IActionnable)
            {
                if (state)
                {
                    return Color.yellow;
                }
                else
                {
                    return Color.blue;
                }

            }
            return Color.black;
        }
        #endif
    }
}
