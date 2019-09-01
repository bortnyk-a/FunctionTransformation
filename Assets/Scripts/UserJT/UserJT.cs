using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class UserJT
{
    // Database ID
    // public string id = "<<ID_Jombo>>";
    // Plaintext name
    //public string name = "<<USER NAME Jombo>>";
    // public List<ContentEntry> contents ;
    public string IP_adress;
    public string Password;
    public string Port;
    public string PathTexture;
    public float BeltLength;
    public float BeltWidth;
    public float BeltOffset;
    //public float LenghtTexture;
    public float Window_Length;
    public float Window_Scale;
    public float Window_X_pos;
    public float Window_Y_pos;
    public float Window_Z_pos;
    public float Transparency;
    public float Position;
    public int Direction;



    public UserJT()
    {
        IP_adress = "";
        Port = "";
        PathTexture = "";
        BeltLength = 1;
        BeltWidth = 1;
        BeltOffset = 0;
        Window_Length = 1f;
        Window_Scale = 1f;
        Window_X_pos = 0;
        Window_Y_pos = 0;
        Window_Z_pos = 0;
        Password = "";
        Transparency = 0.5f;
        Position = 0;
        Direction = 1;
        //LenghtTexture = 0;
        // contents=new List<ContentEntry>();
    }
    [System.Serializable]
    public class ContentEntry
    {

        //  Constructor
        public ContentEntry(string name, string contentId)
        {
            this.name = name;
            this.contentId = contentId;
            videos = new List<ItemVideoEntry>();
        }

        // Unique database identifier.
        public string contentId;
        // Plaintext string name.
        public string name;
        public List<ItemVideoEntry> videos;



    }
    [System.Serializable]
    public class ItemVideoEntry
    {

        //  Constructor
        public ItemVideoEntry(string nameVideo, string linkImageVideo, string linkVideo, string linkLogo_1, string linkLogo_2)
        {
            this.nameVideo = nameVideo;
            this.linkImageVideo = linkImageVideo;
            this.linkVideo = linkImageVideo;
            this.linkLogo_1 = linkLogo_1;
            this.linkLogo_2 = linkLogo_2;

        }
        public string nameVideo;
        public string linkImageVideo;
        public string linkVideo;
        public string linkLogo_1;
        public string linkLogo_2;

    }
}
