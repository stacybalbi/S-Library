using System;
namespace Base.Core.Base
{
	public interface IEntityBase
	{
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}

