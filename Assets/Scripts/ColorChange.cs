using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    //public RenderTexture rTexture;
    public Texture2D texture;
    public GameObject ban;
    private Color _white;
    private Color _black;
    private Color _gray;
    private Color _agray;
    void Start()
    {
        _white = new Color(1, 1, 1);
        _black = new Color(0, 0, 0);
        _gray = new Color(0.1f, 0.1f, 0.1f);
        _agray = new Color(0.03f, 0.03f, 0.03f);

        //texture = new Texture2D(GetComponent<RawImage>().texture.width, GetComponent<RawImage>().texture.height, TextureFormat.ARGB32, false);
        //texture = GetComponent<RawImage>().texture as Texture2D;

        /*texture = new Texture2D(rTexture.width, rTexture.height, TextureFormat.ARGB32, false);
        RenderTexture.active = rTexture;
        texture.ReadPixels(new Rect(0, 0, rTexture.width, rTexture.height), 0, 0);*/
        //texture.Apply();

        //string path = AssetDatabase.GetAssetPath(texture);
        // TextureImporter texImporter = AssetImporter.GetAtPath(path) as TextureImporter;
        //texImporter.isReadable = true;
        //AssetDatabase.ImportAsset(path);
        //texture.Apply();

        //CreatePng();
        //Color();
    }

    //�޸�д�µ�����ɫ
    public void Color(int id)
    {
        //AssetDatabase.Refresh();
        texture = Resources.Load("Word"+ id) as Texture2D;
        texture.Apply();
        //texture = Resources.Load("test2") as Texture2D;
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                if (texture.GetPixel(x, y).r == 1 && texture.GetPixel(x, y).g == 1 && texture.GetPixel(x, y).b == 1)
                {
                    texture.SetPixel(x, y, _black);
                }
                else
                {
                    texture.SetPixel(x, y, _white);
                }
            }
        }
        texture.Apply();
    }

    //���ĸ��Ƴ�����Word_cͼƬ��ɫ��Ϊ����MainTexture
    public void GrayColor(int id)
    {
        AssetDatabase.Refresh();
        texture = Resources.Load("Word_c" + id) as Texture2D;
        texture.Apply();
        //texture = Resources.Load("test2") as Texture2D;
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                if (texture.GetPixel(x, y).r == 1 && texture.GetPixel(x, y).g == 1 && texture.GetPixel(x, y).b == 1)
                {
                    texture.SetPixel(x, y, _gray);
                }
            }
        }
        texture.Apply();
    }

    public void AddColor()
    {
        if (!Config.flag)
        {
            Debug.Log(Config.flag);
            int count = ban.transform.childCount;
            for (int id = 0; id < count; id++)
            {
                AssetDatabase.Refresh();
                texture = ban.gameObject.transform.GetChild(id).GetComponent<MeshRenderer>().materials[1].mainTexture as Texture2D;
                //texture = Resources.Load("Word_c" + id) as Texture2D;
                texture.Apply();
                //texture = Resources.Load("test2") as Texture2D;
                for (int y = 0; y < texture.height; y++)
                {
                    for (int x = 0; x < texture.width; x++)
                    {
                        if (texture.GetPixel(x, y).r != 0 && texture.GetPixel(x, y).g != 0 && texture.GetPixel(x, y).b != 0)
                        {
                            texture.SetPixel(x, y, _agray);
                        }
                    }
                }
                texture.Apply();
            }
        }
        
    }

    public void CreatePng(int id)
    {
        texture = Resources.Load("Word" + id) as Texture2D;
        texture.Apply();

        RenderTexture renderTexture = RenderTexture.GetTemporary(texture.width, texture.height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
        Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.ARGB32, false);

        //��¼ԭRenderTexture�������Ⱦ����
        RenderTexture oldActive = RenderTexture.active;

        //λ�鴫�ͣ�����texture������renderTexture
        Graphics.Blit(texture, renderTexture);

        //�޸�RenderTexture����Ⱦ����
        RenderTexture.active = renderTexture;
        //��ȡRenderTexture����Ⱦ����������Ϣ���洢Ϊ��������(Texture2D)
        texture2D.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);

        byte[] bytes = texture2D.EncodeToPNG();
        if (!Directory.Exists(Application.dataPath))
            Directory.CreateDirectory(Application.dataPath + "/Resources");
        FileStream file = File.Open(Application.dataPath + "/Resources" + "/" + "Word_c" + id + ".png", FileMode.Create);
        BinaryWriter writer = new BinaryWriter(file);
        writer.Write(bytes);
        file.Close();
        Texture2D.Destroy(texture2D);
        texture2D = null;
        //��ԭRenderTexture��ԭ��Ⱦ����
        RenderTexture.active = oldActive;
    }

    //�����ҵ������Ѵ���ͼƬ������ɫ�޸�
    public void Carveing()
    {
        AssetDatabase.Refresh();
        /*for (int c = 1; c < Config.id+1; c++)
        {
            Color(c);
            CreatePng(c);
            AssetDatabase.Refresh();
            GrayColor(c);
        }*/
        Color(Config.id);
        CreatePng(Config.id);
        AssetDatabase.Refresh();
        GrayColor(Config.id);

        GameObject.Find("Word_" + Config.id).GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("Word_" + Config.id).GetComponent<Typesetting>().enabled = true;
        GameObject.Find("Word_" + Config.id).GetComponent<BoxCollider>().enabled = true;
        //GameObject.Find("Pos_" + Config.id).GetComponent<BoxCollider>().enabled = true;
        GameObject.Find("Word_" + Config.id).GetComponent<MeshRenderer>().materials[1].SetTexture("_MainTex", Resources.Load("Word_c" + Config.id) as Texture2D);
        
        Config.id++;
    }
}
