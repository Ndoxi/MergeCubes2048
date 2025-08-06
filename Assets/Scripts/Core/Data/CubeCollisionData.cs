using Core.Gameplay;
using UnityEngine;

namespace Core.Data
{
    public readonly struct CubeCollisionData
    {
        public readonly Cube parent;
        public readonly CubeData parentData;        
        public readonly Cube other;
        public readonly CubeData otherData;
        public readonly Collision collision;

        public CubeCollisionData(Cube parent,
                                 CubeData parentData,
                                 Cube other,
                                 CubeData otherData,
                                 Collision collision)
        {
            this.parent = parent;
            this.parentData = parentData;
            this.other = other;
            this.otherData = otherData;
            this.collision = collision;
        }
    }
}