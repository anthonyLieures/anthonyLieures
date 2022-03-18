using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessRecognition : MonoBehaviour
{
    // Start is called before the first frame update
    public object[] FormatTableWords(object data)
    {   
        IDictionary<string, object> dataTableWords = (IDictionary<string, object>)data;
        string[] words = (string[])dataTableWords["words"];
        List<int> confidence = (List<int>)dataTableWords["confidence"];
        float minConfidence = (float)dataTableWords["MinimumConfidence"];
        object[] result = new object[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            if(confidence[i] > minConfidence)
            {
                result[i] = AddElements(words[i], confidence[i]);
            }
        }
  
        return result;
    }

    private IDictionary<string, object> AddElements(string word, int confidence)
    {
        IDictionary<string, object> data = new Dictionary<string, object>();
        data.Add("word", word);
        data.Add("confidence", confidence);
/*        Debug.Log(word);
        Debug.Log(confidence);*/


        return data;

    }
}
