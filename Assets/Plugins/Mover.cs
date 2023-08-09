using System.Collections;
using System.Collections.Generic;
using RuntimeHandle;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Dictionary<int, SelectionPair> oldSelectedElements = new Dictionary<int, SelectionPair>(128);
    private Dictionary<int, Transform> currentSelectedElements = new Dictionary<int, Transform>(128);
    
    private List<SelectionPair> deselectedElements = new List<SelectionPair>(128);
    private List<Transform> newSelectedElements = new List<Transform>(128);
    
    public void CheckMoveWithHandles(List<Transform> elements)
    {
        currentSelectedElements.Clear();
        deselectedElements.Clear();
        newSelectedElements.Clear();
        
        foreach (var element in elements)
        {
            var instanceID = element.GetInstanceID();

            if (!oldSelectedElements.ContainsKey(instanceID))
                newSelectedElements.Add(element);
            
            currentSelectedElements.Add(element.GetInstanceID(), element);
        }

        foreach (var pair in oldSelectedElements)
        {
            if(!currentSelectedElements.ContainsKey(pair.Key))
                deselectedElements.Add(pair.Value);
        }

        foreach (var deSelected in deselectedElements)
        {
            Destroy(deSelected.handle.gameObject);
            oldSelectedElements.Remove(deSelected.element.GetInstanceID());
        }

        foreach (var newSelected in newSelectedElements)
        {
            var runtimeHandle = // Attach runtime handle to object
                RuntimeTransformHandle.Create(newSelected, HandleType.POSITION, Move);
            
            oldSelectedElements.Add(newSelected.GetInstanceID(), new SelectionPair(newSelected, runtimeHandle));
        }
    }

    private void Move(Transform target, Vector3 oldPosition, Vector3 newPosition)
    {
        Debug.Log($"Move {target.name}: oldPos:{oldPosition} - newPos:{newPosition}", target);
        Debug.DrawLine(oldPosition, newPosition, Color.red, 3f);
    }
}

public struct SelectionPair
{
    public Transform element;
    public RuntimeTransformHandle handle;

    public SelectionPair(Transform transform, RuntimeTransformHandle runtimeHandle)
    {
        element = transform;
        handle = runtimeHandle;
    }
}
