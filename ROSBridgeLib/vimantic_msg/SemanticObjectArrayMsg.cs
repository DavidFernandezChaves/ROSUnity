﻿using SimpleJSON;
using ROSUnityCore.ROSBridgeLib.std_msgs;

namespace ROSUnityCore {
    namespace ROSBridgeLib {
        namespace ViMantic_msgs {

            public class SemanticObjectArrayMsg : ROSBridgeMsg {
                private HeaderMsg _header;
                private SemanticObjectMsg[] _semanticObjects;


                public SemanticObjectArrayMsg(JSONNode msg) {
                    _header = new HeaderMsg(msg["header"]);
                    _semanticObjects = new SemanticObjectMsg[msg["semanticObjects"].Count];
                    for (int i = 0; i < _semanticObjects.Length; i++) {
                        _semanticObjects[i] = new SemanticObjectMsg(msg["semanticObjects"][i]);
                    }
                }

                public SemanticObjectArrayMsg(HeaderMsg header, SemanticObjectMsg[] semanticObjects) {
                    _header = header;
                    _semanticObjects = semanticObjects;
                }

                public static string GetMessageType() {
                    return "vimantic/SemanticObjectArray";
                }

                public HeaderMsg GetHeader() {
                    return _header;
                }

                public SemanticObjectMsg[] GetSemanticObjects() {
                    return _semanticObjects;
                }

                public override string ToString() {
                    string result = ", semanticObjects=[";
                    for (int i = 0; i < _semanticObjects.Length; i++) {
                        result += _semanticObjects[i].ToString();
                        if (i < (_semanticObjects.Length - 1))
                            result += ",";
                    }
                    return "Detection [header=" + _header.ToString() + result + "]]";
                }

                public override string ToYAMLString() {
                    string result = ",  \"semanticObjects\" : [";
                    for (int i = 0; i < _semanticObjects.Length; i++) {
                        result += _semanticObjects[i].ToYAMLString();
                        if (i < (_semanticObjects.Length - 1))
                            result += ",";
                    }
                    return "{\"header\" : " + _header.ToYAMLString() + result + "]}";
                }
            }
        }
    }
}