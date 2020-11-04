import 'package:fluttersocketioexample/config.dart' as config;
import 'package:socket_io_client/socket_io_client.dart' as IO;
import 'package:fluttersocketioexample/sensors.dart';
import 'dart:async';




class SocketService {
  IO.Socket socket;
  Timer timer;

  createSocketConnection() {
    socket = IO.io(config.socketURl, <String, dynamic>{
      'transports': ['websocket'],
    });

    this.socket.on("requestyourname", (data){
      print(data);
      this.socket.emit("myname", "0000-0001:Flutter");
      print("name sended.");

    });
  }
  startSocketdataSEND()
  {
    Sensors.startRotationVector();
    const oneSec = const Duration(milliseconds: 10);
    timer = new Timer.periodic(oneSec, (Timer t) => child(Sensors.rotvec));

  }
  child(t)
  {
    this.socket.emit("Rotationsender", t[0].toString() +':'+t[1].toString() +':'+ t[2].toString());
  }

  adjustSocketdataSEND(dura)
  {
    var oneSec =  Duration(milliseconds: dura);
    timer.cancel();
    timer = new Timer.periodic(oneSec, (Timer t) => child(Sensors.rotvec));
  }
}