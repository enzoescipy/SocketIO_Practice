import 'package:fluttersocketioexample/config.dart' as config;
import 'package:socket_io_client/socket_io_client.dart' as IO;
import 'dart:async';
import 'package:flutter_android/android_hardware.dart' show Sensor, SensorEvent, SensorManager;



class SocketService {
  IO.Socket socket;
  Timer timer;

  createSocketConnection() async {
    socket = IO.io(config.socketURl, <String, dynamic>{
      'transports': ['websocket'],
    });

    this.socket.on("requestyourname", (data){
      print(data);
      this.socket.emit("myname", "0000-0001:Flutter");
      print("name sended.");
    });

    var sensor = await SensorManager.getDefaultSensor(Sensor.TYPE_ROTATION_VECTOR);

    var events = await sensor.subscribe(samplingPeriodUs: 1);
    events.listen((SensorEvent event) {
      var t = event.values;
      this.socket.emit("Rotationsender", t[0].toString() +':'+t[1].toString() +':'+ t[2].toString() +':'+t[3].toString());
    });
  }
}