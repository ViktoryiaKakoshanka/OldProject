//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestEFDatabaseFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubscriberRelationship
    {
        public int Id { get; set; }
        public System.DateTime RelationshipDate { get; set; }
        public int SubscriberId { get; set; }
        public int RelationshipType { get; set; }
    
        public virtual Subscriber Subscriber { get; set; }
    }
}
