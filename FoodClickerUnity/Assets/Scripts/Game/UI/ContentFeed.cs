using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContentFeed<T, DataModel> : MonoBehaviour where T : ContentFeedElement<DataModel>
{
    [SerializeField] private T _elementObject;
    [SerializeField] private Transform _feedElementContainer;
    protected T[] FeedElements;
    public void AllocateFeed(int count)
    {
        FeedElements = new T[count];
        for(int i = 0; i < count; i++)
        {
            FeedElements[i] = Instantiate(_elementObject, _feedElementContainer);
        }
    }
    public void FillFeed(DataModel[] models)
    {
        if(FeedElements == null || models.Length != FeedElements.Length) AllocateFeed(models.Length);
        for(int i = 0; i < models.Length; i++)
        {
            FeedElements[i].InsertData(models[i]);
        }
    }
}
