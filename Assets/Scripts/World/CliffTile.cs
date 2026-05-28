using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace World
{
    [CreateAssetMenu]
    public class CliffTile : RuleTile<CliffTile.Neighbor> {
        public TileBase sandTile;
        public TileBase grassTile;
        public TileBase waterTile;

        public class Neighbor : RuleTile.TilingRule.Neighbor {
            public const int Sand = 3;
            public const int Grass = 4;
        }
        
        public override bool RuleMatch(int neighbor, TileBase tile) {
            switch (neighbor) {
                case Neighbor.Sand: return tile == sandTile || tile == waterTile;
                case Neighbor.Grass: return tile == grassTile;
            }
            return base.RuleMatch(neighbor, tile);
        }
    }
}
