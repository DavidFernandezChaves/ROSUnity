﻿using SimpleJSON;

namespace ROSUnityCore {
	namespace ROSBridgeLib {
		namespace std_msgs {

			public class Float32Msg : ROSBridgeMsg {
				private float _data;

				public Float32Msg(JSONNode msg) {
					_data = msg["data"].AsFloat;
				}

				public Float32Msg(float data) {
					_data = data;
				}

				public static string GetMessageType() {
					return "std_msgs/Float32";
				}

				public float GetData() {
					return _data;
				}

				public override string ToString() {
					return "Float32 [data=" + _data.ToString("G", System.Globalization.CultureInfo.InvariantCulture) + "]";
				}

				public override string ToYAMLString() {
					return "{\"data\" : " + _data.ToString("G", System.Globalization.CultureInfo.InvariantCulture) + "}";
				}
			}
		}
	}
}