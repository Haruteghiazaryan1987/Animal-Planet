using System.Collections.Generic;
using UnityEngine;

namespace Scrips
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private DataManager dataManager;
        [SerializeField] private UiManager uiManager;
        [SerializeField] private ResourcesManager resources;
        private void OnLoadRootObject(List<RootObject>  rootObject){
            uiManager.InitsAnimalType(rootObject);
        }

        public void LoadRootObject(){
            dataManager.LoadRootObject();
            dataManager.OnRootObject += OnLoadRootObject;
            dataManager.NoConnection += NoConnection;
        }

        private void OnEnable(){
            LoadRootObject();
        }

        private void NoConnection(){
            uiManager.NoConnection();
        }

        private void OnDisable(){
            dataManager.OnRootObject -= OnLoadRootObject;
            dataManager.NoConnection -= NoConnection;
        }
    }
}
