﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieNet
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MovieDataModelContainer : DbContext
    {
        public MovieDataModelContainer()
            : base("name=MovieDataModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User> UserSet { get; set; }
        public virtual DbSet<Movie> MovieSet { get; set; }
        public virtual DbSet<Note> NoteSet { get; set; }
        public virtual DbSet<Type> TypeSet { get; set; }
        public virtual DbSet<Comment> CommentSet { get; set; }
    }
}
