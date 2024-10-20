using System;
namespace SLibrary.Core.Base
{
	public class EntityBase : IEntityBase
	{
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}

