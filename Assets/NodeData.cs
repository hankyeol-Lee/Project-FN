using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NodeData", menuName = "Roguelike/Node", order = 1)]
public class NodeData : ScriptableObject
{
    public string nodeName;  // 노드의 이름
    public NodeType type;  // 노드의 유형 (일반, 정예, 인카운터 등)
    public List<NodeData> adjacentNodes;  // 인접 노드들

}
