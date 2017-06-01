using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class data_game : MonoBehaviour
{

    //string file_name = "savedGamea.gd"; //tên file sẽ lưu trữ trong bộ nhớ điện thoại cùng ở thư mục mà ứng dụng lưu trữ

    void Start()
    {

    }

    //Ghi file điểm
    public void write_socer(int best_score, string file_name)
    {
        ArrayList arraySocer = new ArrayList();
        arraySocer.Add(best_score);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + file_name);
        bf.Serialize(file, arraySocer);
        file.Close();
    }
    public void write_array(int best_score, string file_name)
    {
        ArrayList arraySocer = new ArrayList();
        ArrayList temp = read_array(file_name);
        int[] phu = new int[temp.Count + 1];
        for (int i = 0; i < temp.Count - 1; i++)
        {
            phu[i] = (int)temp[i];
        }
        phu[temp.Count] = best_score;
        for (int i = 0; i < temp.Count; i++)
        {
            for (int j = i + 1; j < temp.Count + 1; j++)
            {
                if (phu[i] < phu[j])
                {
                    int tem = phu[i];
                    phu[i] = phu[j];
                    phu[j] = tem;
                }
            }
        }
        for (int i = 0; i < temp.Count + 1; i++)
        {
            arraySocer.Add(phu[i]);
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + file_name);
        bf.Serialize(file, arraySocer);
        file.Close();
    }
    //đọc file điểm
    public int read_data(string file_name)
    {
        ArrayList ps = new ArrayList();
        if (File.Exists(Application.persistentDataPath + "/" + file_name))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + file_name, FileMode.Open);
            ps = (ArrayList)bf.Deserialize(file);
            file.Close();
            return (int)ps[0];
        }
        else
        {
            return 0;
        }
    }
    public ArrayList read_array(string file_name)
    {
        ArrayList ps = new ArrayList();
        if (File.Exists(Application.persistentDataPath + "/" + file_name))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + file_name, FileMode.Open);
            ps = (ArrayList)bf.Deserialize(file);
            file.Close();
            
        }
        return ps;
    }
}