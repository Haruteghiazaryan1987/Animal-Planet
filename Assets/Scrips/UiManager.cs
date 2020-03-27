using System.Collections.Generic;
using Scrips.ViewSystem;
using UnityEngine;

namespace Scrips
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private View menuView;
        [SerializeField] private View infoView;
        [SerializeField] private AnimalTypes animalTypes;
        private List<RootObject> _rootObjects;
    

        private View _activeView;

        private void Awake(){
            InitsView();
            ShowView(menuView);
            animalTypes.OnButtonClicked += ButtonClicked;
        }

        public void UpdateRootObject(){
            gameManager.LoadRootObject();
        }

        public void ButtonClicked(string id){
            ShowView(infoView);
            infoView.GetAnimalId(id,_rootObjects);
        }
    
        private void InitsView(){
            menuView.Setup(this);
            infoView.Setup(this);
        }

        public void InitsAnimalType(List<RootObject> rootObjects){
            _rootObjects = rootObjects;
            menuView.InitsAnimalType(rootObjects);
        }

        public void ShowMenuView(){
            ShowView(menuView);
        }

        private void ShowView(View view){
            if (_activeView != null){
                _activeView.HideView();
            }

            _activeView = view;
            _activeView.ShowView();
        }

        public void NoConnection(){
            menuView.NoConnection();
        }
    }
}
