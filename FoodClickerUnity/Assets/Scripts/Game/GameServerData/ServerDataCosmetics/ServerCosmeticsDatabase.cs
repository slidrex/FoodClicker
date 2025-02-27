using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerCosmeticsDatabase<T> : BaseServerCosmeticsDatabase
{
    [Serializable]
    public struct DatabaseItem
    {
        public int Id;
        public T Item;
    }
    [SerializeField] private DatabaseItem[] _items;
    protected DatabaseItem GetItem(int itemId) => _items[itemId];
}
