namespace Alpha.Reservation.Domain.Common
{
    public class EntityBase<T>
    {
        public T Id { get; }

        public EntityBase(T id)
        {
            Id = id;
        }

        public override int GetHashCode() => Id.GetHashCode();
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return obj is EntityBase<T> entity && Id.Equals(entity.Id);
        }

        public static bool operator ==(EntityBase<T> entity, EntityBase<T> otherEntity)
        {
            if (ReferenceEquals(entity, otherEntity))
                return true;

            if (ReferenceEquals(entity, null) || ReferenceEquals(otherEntity, null))
                return false;

            return entity.Equals(otherEntity);
        }

        public static bool operator !=(EntityBase<T> entity, EntityBase<T> otherEntity) =>
            !(entity == otherEntity);
    }
}