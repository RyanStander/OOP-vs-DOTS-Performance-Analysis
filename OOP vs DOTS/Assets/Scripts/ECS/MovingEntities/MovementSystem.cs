using Unity.Burst;
using Unity.Entities;

namespace ECS.MovingEntities
{
    [BurstCompile]
    public partial struct MovementSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
        }
        
        public void OnDestroy(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;

            foreach (var movement in SystemAPI.Query<Movement>())
            {
                var positionAddition = movement.direction * (deltaTime * movement.speed);
                
            }
        }

        [BurstCompile]
        public partial struct MoveInDirectionJob : IJobEntity
        {
            public float deltaTime;
            public EntityCommandBuffer.ParallelWriter Ecb;

            [BurstCompile]
            /*public void Execute(
                in MovementSpeedComponent speedComponent,
                in MoveEntityInDirectionComponent direction,
                Transform transform)
            {*/
            private void Execute([ChunkIndexInQuery] int chunkIndex,Movement movement)
            {
                var positionAddition = movement.direction * (deltaTime * movement.speed);
                //Ecb.SetComponent(chunkIndex,);
                //movement.transform.position += new Vector3(positionAddition.x, positionAddition.y, positionAddition.z);
            }
        }
    }
}