//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zadatak_1
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCoach
    {
        public int CoachID { get; set; }
        public int TeamID { get; set; }
        public string CoachName { get; set; }
        public decimal Salary { get; set; }
    
        public virtual tblTeam tblTeam { get; set; }
    }
}
