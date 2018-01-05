﻿using UnityEngine;
using UnityEngine.Playables;

namespace UniRx.Triggers {

    // ReSharper disable once PartialTypeWithSinglePart
    public static partial class TimeControlExtensions {

        public static IObservable<Unit> OnControlTimeStartAsObservable(this MonoBehaviour self) {
            self.AddObservableTimeControlTrigger();
            return self.gameObject.GetComponent<ObservableTimeControlTrigger>().OnControlTimeStartAsObservable();
        }

        public static IObservable<Unit> OnControlTimeStopAsObservable(this MonoBehaviour self) {
            self.AddObservableTimeControlTrigger();
            return self.gameObject.GetComponent<ObservableTimeControlTrigger>().OnControlTimeStopAsObservable();
        }

        public static IObservable<double> SetTimeAsObservable(this MonoBehaviour self) {
            self.AddObservableTimeControlTrigger();
            return self.gameObject.GetComponent<ObservableTimeControlTrigger>().SetTimeAsObservable();
        }

        private static void AddObservableTimeControlTrigger(this Component self) {
            if (self.gameObject.GetComponent<ObservableTimeControlTrigger>() == default(ObservableTimeControlTrigger)) {
                self.gameObject.AddComponent<ObservableTimeControlTrigger>();
            }
            foreach (PlayableDirector playableDirector in Object.FindObjectsOfType<PlayableDirector>()) {
                playableDirector.RebuildGraph();
            }
        }

    }

}