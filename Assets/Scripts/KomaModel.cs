using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomaModel : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Sprite[] faces;
    public Sprite komaBack;
    public Sprite[] komaNaru;

    public int cardIndex;
    public int komaBackIndex;

    public void ToggleFace(int showFace)　//外部アクセス可能なToggleFaceというメソッドの定義　引数に真偽値としてshowFaceを取る。
    {
        if (showFace == 0)
        {
            spriteRenderer.sprite = faces[cardIndex];
        }
        else
        {
            if (showFace == 1)
            {
                spriteRenderer.sprite = komaNaru[komaBackIndex];
            }
            else
            {
                spriteRenderer.sprite = komaBack;
            }
        }
    }
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
