﻿namespace CampusSystem.Services.Data
{
    using System;
    using System.Linq;

    using CampusSystem.Data.Common;
    using CampusSystem.Data.Models;
    using Contracts;

    public class StudentService : IStudentService
    {
        private readonly IRepository<User> students;

        public StudentService(IRepository<User> students)
        {
            this.students = students;
        }

        public IQueryable<User> GetAllStudents()
        {
            return this.students.All();
        }

        public User GetById(string id)
        {
            return this.students.GetById(id);
        }
    }
}
