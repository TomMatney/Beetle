using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance //: INetworkSerializable
{
    public ItemInstance(int Id, int Count)
    {
        this.Id = Id;
        this.Count = Count;
    }

    public int Id;
    public int Count;

    //public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    //{
    //    serializer.SerializeValue(ref Id);
    //    serializer.SerializeValue(ref Count);
    //}
}
