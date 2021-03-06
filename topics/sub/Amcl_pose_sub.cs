﻿using ROSUnityCore.ROSBridgeLib;
using ROSUnityCore.ROSBridgeLib.geometry_msgs;
using SimpleJSON;
using UnityEngine;

namespace ROSUnityCore {
    public class Amcl_pose_sub : ROSBridgeSubscriber {

        public new static string GetMessageTopic() {
            return "/amcl_pose";
        }

        public new static string GetMessageType() {
            return "geometry_msgs/PoseWithCovarianceStamped";
        }

        public new static ROSBridgeMsg ParseMessage(JSONNode msg) {
            return new PoseWithCovarianceStampedMsg(msg);
        }

        public new static void CallBack(ROSBridgeMsg msg, string host) {
            var robot = GameObject.FindGameObjectWithTag("Robot");
            if (robot != null) {
                PoseWithCovarianceStampedMsg _transforms = (PoseWithCovarianceStampedMsg)msg;
                Vector3 position = _transforms.GetPose().GetPose().GetPositionUnity();
                Quaternion rotation = _transforms.GetPose().GetPose().GetRotationUnity();
                robot.transform.SetPositionAndRotation(position, rotation);
            } else {
                Debug.LogWarning("Can not find a gameobject with the tag Robot");
            }
        }
    }
}