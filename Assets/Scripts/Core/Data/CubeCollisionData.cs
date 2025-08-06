using UnityEngine;

namespace Core.Data
{
    public readonly struct CubeCollisionData
    {
        public readonly GameObject parent;
        public readonly CubeData parentData;        
        public readonly GameObject other;
        public readonly CubeData otherData;
        public readonly Collision collision;

        public CubeCollisionData(GameObject parent,
                                 CubeData parentData,
                                 GameObject other,
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