using UnityEngine;

public class ExpoPieceEntity : MonoBehaviour
{
    private GameObject pieceGameObject;
    private GameObject placeHolder;
    private float distance;
    private string entityName;

    public ExpoPieceEntity(string entityName,GameObject pieceGameObject,float distance, GameObject placeHolder)
    {
        this.entityName=entityName;
        this.distance= distance;
        this.pieceGameObject = pieceGameObject;
        this.placeHolder = placeHolder;
    }

    public string EntityName { get => entityName; set => entityName = value; }
    public float Distance { get => distance; set => distance = value; }
    public GameObject PieceGameObject { get => pieceGameObject; set => pieceGameObject = value; }
    public GameObject PlaceHolder { get => placeHolder; set => placeHolder = value; }
}
