using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Final : MonoBehaviour
{
    public GameObject ban;//��ȡ���������������ò�����ͼ
    Texture2D final;
    //��ȡ��дͼƬ�ϳ�һ��ͼ

    private void Start()
    {
        //��ʼ��ͼƬΪ��ɫ
        final = Resources.Load("Final") as Texture2D;
        for (int y = 0; y < final.height; y++)
        {
            for (int x = 0; x < final.width; x++)
            {
                final.SetPixel(x, y, new Color(1, 1, 1));
            }
        }
        final.Apply();
    }

    public void CreateFinal()
    {
        /*string path = Application.dataPath + "/Resources";
        DirectoryInfo folder = new DirectoryInfo(path);
        var files = folder.GetFiles(".png");
        Texture2D[] textures = new Texture2D[Config.id+1];
        int count = files.Length;
        for(int i = 0; i < files.Length; i++)
        {
            
        }*/
        //List<Texture2D> words = new List<Texture2D>();
        //Texture2D[] words = new Texture2D[24];

        //int count = ban.transform.childCount;
        //for (int i = 0; i < count; i++)
        //{
        //    Texture2D tex = ban.transform.GetChild(i).GetComponent<MeshRenderer>().materials[1].GetTexture("_DispTex") as Texture2D;
        //    words.Add(tex);

       // }

        
        Texture2D sample = Resources.Load("Word0") as Texture2D;

        RenderTexture renderTexture = RenderTexture.GetTemporary(sample.width * 14, sample.height * 14, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
        final = new Texture2D(sample.width * 14, sample.height * 14, TextureFormat.ARGB32, false) ;

        //��¼ԭRenderTexture�������Ⱦ����
        RenderTexture oldActive = RenderTexture.active;

        int count = ban.transform.childCount;
        Debug.Log(count);
        for (int c = 0; c < count; c++)
        {
            //Debug.Log(c + "config.id");
            GameObject temp = ban.transform.GetChild(c).gameObject;
            Texture2D tex = temp.GetComponent<MeshRenderer>().materials[1].GetTexture("_DispTex") as Texture2D;
            //Texture2D tex = Resources.Load("Word" + c) as Texture2D;
            Debug.Log(c + "  " + (int)Mathf.Floor((temp.GetComponent<TSID>().ID / 12)) + "  " + (13 - temp.GetComponent<TSID>().ID % 12));
            for (int y = 0; y < tex.height; y++)
            {
                
                for (int x = 0; x < tex.width; x++)
                {
                    if(tex.GetPixel(x,y).r != 0&& tex.GetPixel(x, y).g != 0&& tex.GetPixel(x, y).b != 0)
                    {
                        
                        final.SetPixel((x + 100 + (int)Mathf.Floor(( temp.GetComponent<TSID>().ID / 12 )) * tex.width), y+( 13 - temp.GetComponent<TSID>().ID%12)*tex.height, new Color(0,0,0));
                    }
                }
            }
        }

        //�޸�RenderTexture����Ⱦ����
        RenderTexture.active = renderTexture;
        byte[] bytes = final.EncodeToPNG();
        if (!Directory.Exists(Application.dataPath))
            Directory.CreateDirectory(Application.dataPath + "/Resources");
        FileStream file = File.Open(Application.dataPath + "/Resources" + "/" + "Final" + ".png", FileMode.Create);
        BinaryWriter writer = new BinaryWriter(file);
        writer.Write(bytes);
        file.Close();
        Texture2D.Destroy(final);
        final = null;
        //��ԭRenderTexture��ԭ��Ⱦ����
        RenderTexture.active = oldActive;
        
        UnityEditor.AssetDatabase.Refresh();
    }

}
