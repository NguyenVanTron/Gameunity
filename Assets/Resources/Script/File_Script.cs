using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class File_Script : MonoBehaviour
{

    string file_name = "savedGamea.gd"; //tên file sẽ lưu trữ trong bộ nhớ điện thoại cùng ở thư mục mà ứng dụng lưu trữ

    void Start()
    {

    }

    //Ghi file điểm
    public void write_socer(int best_score)
    {
        ArrayList arraySocer = new ArrayList();
        Player_information_Script ps = new Player_information_Script();
        ps.best_socers = best_score;
        arraySocer.Add(ps);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + file_name);
        bf.Serialize(file, arraySocer);
        file.Close();
    }

    //đọc file điểm
    public Player_information_Script read_data()
    {
        ArrayList ps = new ArrayList();
        if (File.Exists(Application.persistentDataPath + "/" + file_name))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + file_name, FileMode.Open);
            ps = (ArrayList)bf.Deserialize(file);
            file.Close();
            return (Player_information_Script)ps[0];
        }
        else
        {
            return new Player_information_Script();
        }
    }
}