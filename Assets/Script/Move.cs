using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public int steps;
    public int coin;

    public GameObject currentNode;
    public GameObject wheelObject;
    public Text coinText;
    public List<GameObject> nodeList;

    public IEnumerator MoveTo()
    {
        steps = wheelObject.GetComponent<Spin>().stepNumber;

        for (int i = 0; i < steps; i++)
        {
            if(nodeList.Count != (nodeList.IndexOf(currentNode))+1) 
            { 
                transform.position = new Vector3(
                    nodeList[(nodeList.IndexOf(currentNode))+1].transform.position.x,
                    transform.position.y,
                    nodeList[(nodeList.IndexOf(currentNode))+1].transform.position.z);
                currentNode = nodeList[(nodeList.IndexOf(currentNode)) + 1];
            }
            else if(nodeList.Count == (nodeList.IndexOf(currentNode)) + 1)
            { 
                transform.position = new Vector3(nodeList[0].transform.position.x,
                    transform.position.y, 
                    nodeList[0].transform.position.z);
                currentNode = nodeList[0];
            }
            coin += 10;
            coinText.text = coin.ToString(); 
            yield return new WaitForSeconds(0.7f);
        }

    }
}
