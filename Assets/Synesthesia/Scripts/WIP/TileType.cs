using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TK/Tile Type", fileName = "NewTileType")]
public class TileType : ScriptableObject
{
    [TextArea(3, 6)]
    [SerializeField] string description;
    [Tooltip("Defines the aesthetic of the tile.")]
    [SerializeField] Material material;
    [Tooltip("Base point value for when a match is made with tiles of this type.")]
    [SerializeField] int pointValue = 10;
    //[Tooltip("Any special effects tied to this particular type. May be better to just use Fungus for this...")]
    //[SerializeField] List<TileEffect> effects = new List<TileEffect>();

    public virtual string Description
    {
        get { return description; }
    }

    public virtual Material Material
    {
        get { return material; }
    }

    public virtual int PointValue
    {
        get { return pointValue; }
    }

    /*public virtual List<TileEffect> Effects
    {	// custom
        get { return effects; }
    }*/

}
