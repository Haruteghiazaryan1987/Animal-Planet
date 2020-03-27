using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scrips.ViewSystem
{
    public class MenuView : View
    {
        [SerializeField] private RectTransform content;
        [SerializeField] private RectTransform textPrefab;
        [SerializeField] private ResourcesManager resources;
        [SerializeField] private Button update;
        [SerializeField] private Text popupText;
        [SerializeField] private GameObject loadingObject ;
        private bool loading = true;
        private float speed = 5f;

        private void Awake(){
            popupText.color= new Color(255, 0, 0, 0);
            loadingObject.SetActive(true);
        }

        public override void InitsAnimalType(List<RootObject> rootObjects){
            popupText.color= new Color(255, 0, 0, 0);
            loading = false;
            loadingObject.SetActive(false);
            if (content.childCount != 0){
                for (int i = 0; i < content.childCount; i++){
                    Destroy(content.GetChild(i).gameObject);
                }
            }
            
            if (rootObjects.Count != 0){
                for (int i = 0; i < rootObjects.Count; i++){
                    var obj = Instantiate(textPrefab, content);
                    obj.GetComponent<AnimalTypes>().Inits(rootObjects[i].type,i+1,resources.
                        GetSpriteByItemType(rootObjects[i].type),rootObjects[i]._id,this);
                }
            }
        }

        public override void OnButtonClicked(string id){
            uiManager.ButtonClicked(id);
        }

        private void UpdateRootObject(){
            uiManager.UpdateRootObject();
            loadingObject.SetActive(true);
        }

        public override void NoConnection(){
            popupText.color= new Color(255, 0, 0, 255);
        }

        protected override void SubscribeEvents(){
            update.onClick.AddListener(UpdateRootObject);
        }

        protected override void UnSubscribeEvents(){
            update.onClick.RemoveListener(UpdateRootObject);
        }
    }
}
