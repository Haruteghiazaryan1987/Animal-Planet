using System.Collections.Generic;
using UnityEngine;

namespace Scrips.ViewSystem
{
    public abstract class View : MonoBehaviour
    {
        protected UiManager uiManager;

        public void Setup(UiManager uiManager){
            this.uiManager = uiManager;
        }

        
        public void ShowView() {
            gameObject.SetActive(true);
        }

        public void HideView() {
            gameObject.SetActive(false);
        }

        protected virtual void UnSubscribeEvents(){
            
        }

        protected virtual void SubscribeEvents(){
            
        }

        public virtual void OnButtonClicked(string id){
        }
        

        protected virtual void OnEnable(){
            SubscribeEvents();
        }

        protected virtual void OnDisable(){
            UnSubscribeEvents();
        }

        public virtual void InitsAnimalType(List<RootObject> rootObjects){
        }

        public virtual void GetAnimalId(string id,List<RootObject> rootObjects){
        }

        public virtual void NoConnection(){
        }
    }
}
