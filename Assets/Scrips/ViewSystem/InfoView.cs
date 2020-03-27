using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Scrips.ViewSystem
{
    public class InfoView : View
    {
        [SerializeField] private Text title;
        [SerializeField] private Text info;
        [SerializeField] private Text source;
        [SerializeField] private Text verified;
        [SerializeField] private Text updated;
        [SerializeField] private Button buttonReturn;

        public override void GetAnimalId(string id,List<RootObject> rootObjects){
            foreach (var item in rootObjects){
                if (item._id.Equals(id)){                   
                    title.text="About"+" "+ item.type;
                    info.text = item.text;
                    source.text = item.source.ToUpper();
                    if (item.status.verified){
                        verified.text = "CHECKED";
                    }
                    else{
                        verified.text = "UNCHECKED";
                    }

                    updated.text = item.updatedAt.ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        private void ClickedReturn(){
            uiManager.ShowMenuView();
        }
        protected override void SubscribeEvents(){
            buttonReturn.onClick.AddListener(ClickedReturn);
        }
        protected override void UnSubscribeEvents(){
            buttonReturn.onClick.RemoveListener(ClickedReturn);
        }
    }
}
