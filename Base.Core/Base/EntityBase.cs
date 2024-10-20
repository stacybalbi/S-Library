using System;
namespace Base.Core.Base
{
	public class EntityBase : IEntityBase
	{
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}

