using KUSYS.Core.Dto;
using KUSYS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace KUSYS.Domain.DBContext
{
	public class KUSYSDbContext : DbContext
	{
		public KUSYSDbContext(DbContextOptions<KUSYSDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().HasKey(x => x.Id);
			modelBuilder.Entity<Student>().HasKey(x => x.Id);
			modelBuilder.Entity<Course>().HasKey(x => x.Id);
			modelBuilder.Entity<StudentCourse>().HasKey(x => x.Id);

			Seed(modelBuilder);
		}

		#region Seed
		/// <summary>
		/// Seed classes to be used in db creation
		/// </summary>
		/// <param name="modelBuilder"></param>
		private void Seed(ModelBuilder modelBuilder)
		{
			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}

			modelBuilder.Entity<Student>()
				.HasMany(e => e.StudentCourses)
				.WithOne(e => e.Student)
				.HasForeignKey(e => e.StudentId);

			modelBuilder.Entity<Course>()
				.HasMany(e => e.CourseStudents)
				.WithOne(e => e.Course)
				.HasForeignKey(e => e.CourseId);
			
			modelBuilder.Entity<StudentCourse>()
				.HasOne<Student>(e => e.Student)
				.WithMany(e => e.StudentCourses)
				.HasForeignKey(e => e.StudentId);

			modelBuilder.Entity<StudentCourse>()
				.HasOne<Course>(e => e.Course)
				.WithMany(e => e.CourseStudents)
				.HasForeignKey(e => e.CourseId);

			//User Seeds
			var users = new List<User>()
			{
				new User() { Id = 1, UserName = "admin", UserTypeId = (int)UserType.Admin },
				new User() { Id = 2, UserName = "student1", UserTypeId = (int)UserType.Student },
				new User() { Id = 3, UserName = "student2", UserTypeId = (int)UserType.Student },
				new User() { Id = 4, UserName = "student3", UserTypeId = (int)UserType.Student }
			};
			modelBuilder.Entity<User>().HasData(users);

			//Student Seeds
			var students = new List<Student>()
			{
				new Student(){ Id = 1, InsertUserId = 1,InsertDate= DateTime.Now,UserId = 2, FirstName = "Ali",LastName = "Korkmaz",BirthDate = new DateTime(2000, 5, 10)},
				new Student(){ Id = 2, InsertUserId = 1,InsertDate = DateTime.Now,UserId = 3,FirstName = "Selin",LastName = "Kara",BirthDate = new DateTime(2001, 7, 15)},			  
				new Student(){ Id = 3, InsertUserId = 1,InsertDate = DateTime.Now,UserId = 4, FirstName = "Kerem",LastName = "Yıldız",BirthDate = new DateTime(1999, 2, 23)}
			};
			modelBuilder.Entity<Student>().HasData(students);

			//Course Seeds
			var courses = new List<Course>()
			{
				new Course() { Id = 1, InsertUserId = 1,InsertDate= DateTime.Now, UpdateUserId = 1, UpdateDate = null,Code = "CSI101", Name = "Introduction to Computer Science"},
				new Course() { Id = 2, InsertUserId = 1,InsertDate= DateTime.Now, UpdateUserId = 1, UpdateDate = null,Code = "CSI102",Name = "Algorithms"},
				new Course() { Id = 3,  InsertUserId = 1,InsertDate= DateTime.Now, UpdateUserId = 1, UpdateDate = null, Code = "MAT101",Name = "Calculus"},
				new Course() { Id = 4,  InsertUserId = 1,InsertDate = DateTime.Now, UpdateUserId = 1, UpdateDate = null, Code = "PHY101",Name = "Physics"}
			};
			modelBuilder.Entity<Course>().HasData(courses);

			//StudentCourse Seeds
			var studentCourses = new List<StudentCourse>()
			{
				new StudentCourse() { Id = 1, CourseId = 1, StudentId = 2},
				new StudentCourse() { Id = 2, CourseId = 2, StudentId = 2},
				new StudentCourse() { Id = 3, CourseId = 3, StudentId = 2},
				new StudentCourse() { Id = 4, CourseId = 2, StudentId = 2},
				new StudentCourse() { Id = 5, CourseId = 3, StudentId = 2},
				new StudentCourse() { Id = 6, CourseId = 2, StudentId = 3},
				new StudentCourse() { Id = 7, CourseId = 3, StudentId = 3},
				new StudentCourse() { Id = 8, CourseId = 4, StudentId = 3},
				new StudentCourse() { Id = 9, CourseId = 1, StudentId = 1},
				new StudentCourse() { Id = 10, CourseId = 2, StudentId = 1}
			};
			modelBuilder.Entity<StudentCourse>().HasData(studentCourses);

		}

		#endregion

		#region DB Save
		/// <summary>
		/// The method that saves the changes made in the db
		/// </summary>
		/// <returns></returns>
		public override int SaveChanges()
		{
			InsertListener();
			UpdateListener();
			DeleteListener();
			return base.SaveChanges();
		}

		/// <summary>
		/// Intermediate step before insert action
		/// </summary>
		private void InsertListener()
		{
			foreach (var entity in ChangeTracker.Entries<EntityBase>().Where(x => x.State == EntityState.Added).ToList())
			{
				entity.Entity.InsertDate = DateTime.Now;
				entity.Entity.InsertUserId = 1;
				entity.Entity.IsDeleted = false;
			}
		}

		/// <summary>
		/// Intermediate step before update action
		/// </summary>
		private void UpdateListener()
		{
			foreach (var entity in ChangeTracker.Entries<EntityBase>().Where(x => x.State == EntityState.Modified).ToList())
			{
				entity.Entity.UpdateDate = DateTime.Now;
				entity.Entity.UpdateUserId = null;
			}
		}
		/// <summary>
		/// Intermediate step before delete action
		/// </summary>
		private void DeleteListener()
		{
			foreach (var entity in ChangeTracker.Entries<EntityBase>().Where(x => x.State == EntityState.Deleted).ToList())
			{
				entity.Entity.IsDeleted = true;
				entity.Entity.UpdateUserId = 1;
				entity.Entity.UpdateDate = DateTime.Now;
				entity.State = EntityState.Modified;
			}
		}
		#endregion

		public DbSet<User> Users { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<StudentCourse> StudentCourses { get; set; }
	}
}
