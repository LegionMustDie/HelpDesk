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
    
    public partial class RequestStaff
    {
        public int IdRequest { get; set; }
        public int IdCategory { get; set; }
        public int IdStaff { get; set; }
        public string TextRequest { get; set; }
        public byte[] ImageOne { get; set; }
        public byte[] ImageTwo { get; set; }
        public byte[] ImageThree { get; set; }
        public int IdStatus { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Status Status { get; set; }
    }
}
