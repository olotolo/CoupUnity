using TMPro;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    private NetworkVariable<int> randomNumber = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public struct MyCustomData : INetworkSerializable
    {
        public int _int;
        public bool _bool;
        public FixedString128Bytes message;

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref _int);
            serializer.SerializeValue(ref _bool);
            serializer.SerializeValue(ref message);
        }
    }


    public override void OnNetworkSpawn()
    {
        randomNumber.OnValueChanged += (int previousValue, int newValiue) =>
        {
            Debug.Log(OwnerClientId + "; " + randomNumber.Value);
        };
    }


    private void Update()
    {
        if(!IsOwner) return;

        if(Input.GetKeyDown(KeyCode.T))
        {
            randomNumber.Value = Random.Range(0, 100);
        }
        Vector3 moveDir = Vector3.zero;

        if(Input.GetKey(KeyCode.W)) { moveDir.y = +1f; }
        if(Input.GetKey(KeyCode.S)) { moveDir.y = -1f; }
        if(Input.GetKey(KeyCode.A)) { moveDir.x = -1f; }
        if(Input.GetKey(KeyCode.D)) { moveDir.x = +1f; }
        float moveSpeed = 3f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
