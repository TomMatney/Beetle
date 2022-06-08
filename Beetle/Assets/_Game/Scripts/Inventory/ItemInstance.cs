using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance //: INetworkSerializable
{
    public ItemInstance(int Id, int Amount)
    {
        this.Id = Id;
        this.Amount = Amount;
    }

    public int Id;
    public int Amount;

    //public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    //{
    //    serializer.SerializeValue(ref Id);
    //    serializer.SerializeValue(ref Count);
    //}
}
