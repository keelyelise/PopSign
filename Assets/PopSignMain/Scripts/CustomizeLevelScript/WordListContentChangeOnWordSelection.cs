﻿using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordListContentChangeOnWordSelection : MonoBehaviour
{
    public UnityEngine.UI.Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Tap any word to see its video. Select 3 to 5 words to create a custom practice level.";
    }

    // Update is called once per frame
    void Update()
    {
        CustomizeLevelManager clm = CustomizeLevelManager.Instance;
        string content = "Tap any word to see its video. Select 3 to 5 words to create a custom practice level.";
        if (clm != null)
        {
            HashSet<string> set = clm.selectedWord;
            if (set.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string str in set)
                {
                    sb.Append(str + ", ");
                }

                content = "Selected " + sb.ToString() + " select " + (5 - set.Count) + " more words.";

            }
        }
        text.text = content;

    }
}
