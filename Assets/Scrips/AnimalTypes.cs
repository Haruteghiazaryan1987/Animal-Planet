using System;
using Scrips.ViewSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Scrips
{
    public class AnimalTypes : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Text animalName;
        [SerializeField] private Text count;
        [SerializeField] private Image image;
        private View _menuView;
        private string _buttonId;
        public event Action<string> OnButtonClicked;

        public void Inits(string name,int count,Sprite image,string id,MenuView menuView){
            animalName.text = name;
            this.count.text = count.ToString();
            this.image.sprite = image;
            _buttonId = id;
            _menuView = menuView;
            AddListener();
        }

        private void OnButtonClick(){
            OnButtonClicked?.Invoke(_buttonId);
            _menuView.OnButtonClicked(_buttonId);
        }

        private void AddListener(){
            button.onClick.AddListener(OnButtonClick);
        }
    }
}
