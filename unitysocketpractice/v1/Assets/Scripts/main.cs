using UnityEngine;
using socket.io;
public class main : MonoBehaviour 
{
    public string receivedData;
    public int count;
    void Start() 
	{
        receivedData = "n:n:n";
        // 접속 Url
        var serverUrl = "http://3.128.231.214:3001";
        var testserverUrl = "http://121.188.243.249:3001";

        // 서버로 접속 시도~
        var socket = Socket.Connect(serverUrl);

        // "news" 이벤트 처리 Receive
        socket.On("requestyourname", (string data) => 
        {

            // "my other event" 이벤트 Send
            socket.Emit("myname","0000-0001:Unity");

        });

        socket.On("Rotationgetter", (string data) => {
            receivedData = data;
            count += 1;
            Debug.Log("Received~~");
        });
    }

}