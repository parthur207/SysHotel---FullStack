using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }
        public Guid Id { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        public bool IsDeleted { get; private set; } = false;

        public bool SetAsDeleted()
        {
            if (IsDeleted is false)
            {
                IsDeleted = true;
                return true;
            }
            return false;
        }

        public bool SetAsActive()
        {
            if (IsDeleted is true)
            {
                IsDeleted = false;
                return true;
            }
            return false;
        }

        public void SetUpdatedNow()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}

