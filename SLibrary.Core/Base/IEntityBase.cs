using System;
namespace SLibrary.Core.Base
{
	public interface IEntityBase
	{
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}

