using System;
using System.Collections.Generic;
using System.Text;

namespace NapoleonNotes.DAL
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
            :base("The entity not found")
        {

        }

        public NotFoundException SetId(Guid guid)
        {
            Data.Add("id", guid);
            return this;
        }
    }
}
