using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomDoubleLinkedList
{
    public CustomNode First;
    public CustomNode Last;
    public CustomNode Peak;

    public void Add(CustomNode newNode)
    {
        if (Peak != null && Peak != Last)
        {
            CustomNode current = Peak.Next;
            while (current != null)
            {
                CustomNode temp = current.Next;
                current.Next = null;
                current.Previous = null;
                current = temp;
            }

            Peak.Next = null;
            Last = Peak;
        }

        if (First == null)
        {
            First = newNode;
            Last = newNode;
            Peak = newNode;
        }
        else
        {
            Last.Next = newNode;
            newNode.Previous = Last;
            Last = newNode;
            Peak = newNode;
        }
    }

    public void MoveToPrevious()
    {
        if (Peak != null && Peak.Previous != null)
        {
            Peak = Peak.Previous;
        }
    }

    public void MoveToNext()
    {
        if (Peak != null && Peak.Next != null)
        {
            Peak = Peak.Next;
        }
    }

    public List<IEntity> GetCurrentEntities()
    {
        if (Peak != null && Peak.entitiesSnapshot != null)
        {
            return Peak.entitiesSnapshot;
        }

        return new List<IEntity>();
    }
    public CustomNode GetCurrent()
    {
        return Peak;
    }
}


