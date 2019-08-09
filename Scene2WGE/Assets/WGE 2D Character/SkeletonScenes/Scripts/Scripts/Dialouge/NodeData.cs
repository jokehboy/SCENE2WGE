using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

[System.Serializable]
public class NodeData
{
    [XmlAttribute("NodeID")]
    public int ID;
    [XmlAttribute("NPCText")]
    public string NPCText;
    [XmlArray("PlayerResponse"), XmlArrayItem("Response")]
    public List<string> responses;
    [XmlArray("ResponseDestinationNode"), XmlArrayItem("ResponseDestinationID")]
    public List<int> responseDestinationNodeID;

    
    
    

    

    

    

}



