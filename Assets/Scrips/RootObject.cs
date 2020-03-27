using System;
using UnityEngine;

namespace Scrips
{
    public class RootObject : MonoBehaviour
    {
        public bool used{ get; set; }
        public string source{ get; set; }
        public string type{ get; set; }
        public bool deleted{ get; set; }
        public string _id{ get; set; }
        public string user{ get; set; }
        public string text{ get; set; }
        public int __v{ get; set; }
        public DateTime updatedAt{ get; set; }
        public DateTime createdAt{ get; set; }
        public Status status{ get; set; }
    }
}