using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player : MonoBehaviour {

    // fileNameのn行目の値を配列として返す
	public string[] CSVReadLine(string fileName, int n){
        StreamReader sr = new StreamReader(fileName);
        string line;
        int i = 0;
        while ((line = sr.ReadLine()) != null){
            if (i == n){
                string[] fields = line.Split(',');
                break;
            }
            i++;
        }
        return fields;
    }
}
