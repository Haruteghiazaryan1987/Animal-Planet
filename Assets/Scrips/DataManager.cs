using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Scrips
{
    public class DataManager: MonoBehaviour
    {
        private string webURL = "https://cat-fact.herokuapp.com/facts/random?animal_type=cat,dog,horse&amount=10";
        public event Action<List<RootObject> > OnRootObject;
        public event Action NoConnection;
        
        public void LoadRootObject(){
            StartCoroutine(LoadObject());
        }

        private IEnumerator LoadObject(){
            using (var webRequest = UnityWebRequest.Get(webURL))
            {
                yield return webRequest.SendWebRequest();
                var json = webRequest.downloadHandler.text;
                if (!string.IsNullOrEmpty(webRequest.error))
                {
                    Debug.LogError(webRequest.error);
                    NoConnection?.Invoke();
                    yield break;
                }

                var response = JsonConvert.DeserializeObject<List<RootObject>>(json);
                OnRootObject?.Invoke(response);
            }
        }
    }
}