using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("NodeCollection")]
public class NodeContainer 
{
    [XmlArray("TheNodes")]
    [XmlArrayItem("Node")]

    public List<NodeData> TheNodes = GameObject.Find("DialougeManager").GetComponent<DialougeManager>().TheNodes;
    public NodeContainer nodeContainer;



    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(NodeContainer));
        FileStream stream = new FileStream(path, FileMode.Create);



        serializer.Serialize(stream, this);

        stream.Close();
    }

    public void  Load(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(NodeContainer));
        FileStream stream = new FileStream(path, FileMode.Open);
        TheNodes.Clear();
        TheNodes = serializer.Deserialize(stream) as List<NodeData>;

    }

    public static NodeContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(DialougeManager));
        return serializer.Deserialize(new StringReader(text)) as NodeContainer;
    }
}
