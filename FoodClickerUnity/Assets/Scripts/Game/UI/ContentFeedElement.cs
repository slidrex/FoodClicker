using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContentFeedElement<DataModel> : MonoBehaviour
{
    public abstract void InsertData(DataModel data);
}
