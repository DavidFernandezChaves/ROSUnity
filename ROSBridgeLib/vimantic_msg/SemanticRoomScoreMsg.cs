﻿using System;
using SimpleJSON;
using ROSUnityCore.ROSBridgeLib.std_msgs;

namespace ROSUnityCore {
    namespace ROSBridgeLib {
        namespace ViMantic_msgs {

            public class SemanticRoomScoreMsg : ROSBridgeMsg {

                private String _type;
                private double _score;


                public SemanticRoomScoreMsg(JSONNode msg) {
                    _type = msg["type"];
                    _score = double.Parse(msg["score"], System.Globalization.CultureInfo.InvariantCulture);
                }

                public SemanticRoomScoreMsg(String type, float score) {
                    _type = type;
                    _score = score;
                }

                public static string GetMessageType() {
                    return "semantic_mapping/SemanticRoomScore";
                }

                public String GetTypeObject() {
                    return _type;
                }

                public double GetAccuracyEstimation() {
                    return _score;
                }

                public override string ToString() {

                    return "Detection [ type=" + _type + ", score=" + _score + "]";
                }

                public override string ToYAMLString() {
                    return "{\"type\" : \"" + _type + "\", \"score\" : " + _score.ToString("G", System.Globalization.CultureInfo.InvariantCulture) + "}";
                }
            }
        }
    }
}