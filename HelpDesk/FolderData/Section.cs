//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelpDesk.FolderData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Section
    {
        public int IdSection { get; set; }
        public string NameSection { get; set; }
        public int IdCategoty { get; set; }
    
        public virtual Category Category { get; set; }
    }
}