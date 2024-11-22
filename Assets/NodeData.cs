using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NodeData", menuName = "Roguelike/Node", order = 1)]
public class NodeData : ScriptableObject
{
    public string nodeName;  // ����� �̸�
    public NodeType type;  // ����� ���� (�Ϲ�, ����, ��ī���� ��)
    public List<NodeData> adjacentNodes;  // ���� ����

}
