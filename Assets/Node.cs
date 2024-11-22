using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType
{
    Start,
    Normal,
    Elite,
    Encounter,
    Boss
}
public class Node : MonoBehaviour
{
    public string NodeName { get; private set; }
    public NodeType Type { get; private set; }
    public List<Node> AdjacentNodes { get; private set; }

    public Node(string nodeName, NodeType type)
    {
        NodeName = nodeName;
        Type = type;
        AdjacentNodes = new List<Node>();
    }

    public void AddAdjacentNode(Node node)
    {
        AdjacentNodes.Add(node);
    }
}