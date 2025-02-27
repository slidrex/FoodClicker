using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ServerIDDataHandler<Data> : ScriptableObject
{
    [SerializeField] protected Data[] Handlers;
    public Data GetDataByHandlerID(ushort id) => Handlers[id];
}
