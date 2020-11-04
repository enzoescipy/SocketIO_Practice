import 'package:flutter_android/android_hardware.dart' show Sensor, SensorEvent, SensorManager;

class Sensors {
  static List<double> rotvec;

  static startRotationVector() async
  {
    var sensor = await SensorManager.getDefaultSensor(Sensor.TYPE_ROTATION_VECTOR);

    var events = await sensor.subscribe();
    events.listen((SensorEvent event) {
      rotvec = event.values;
    });
  }
}