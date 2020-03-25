namespace medical_care.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<medical_care.Data.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(medical_care.Data.MyDbContext context)
        {
            context.Companies.AddOrUpdate(
                  p => p.CompanyId,
                  new Models.Company
                  {
                      CompanyId = 1,
                      Name = "Tập đoàn Phương Đông",
                      Description = "Phương Đông là đơn vị tiên phong và luôn dẫn đầu tại Việt Nam",
                      Address = "Lô CN2 KĐTM Định Công, Q. Hoàng Mai.",
                      Phone = "+84 24 3573 8301",
                      Url = "https://phuongdong.com/",
                      Thumbnail = "",
                      CreatedAt = DateTime.Now,
                      UpdatedAt = "3/17/2020",
                      DeletedAt = "Null",
                      Status = Models.CompanyStatus.ACTIVE,
                  }
                );
            context.Employees.AddOrUpdate(
                  p => p.Id,
                  new Models.Employee
                  {
                      Id = "A0011",
                      Firstname = "Lil",
                      Lastname = "Wayne",
                      UserName = "LilWayne001",
                      Password = "sqwewfd1123",
                      Address = "3/1/2 Wall",
                      Phone = "0921212121",
                      City = "LosAngeless",
                      Country = "Long Beach",
                      CreatedAt = DateTime.Now,
                      UpdatedAt = "3/17/2020",
                      DeletedAt = "Null",
                      EmpStatus = Models.EmpStatus.NORMAL
                  }
                );
            context.Hospitals.AddOrUpdate(
                  p => p.HospitalId,
                  new Models.Hospital
                  {
                      HospitalId = 1,
                      Name = "Bệnh viện Thanh Nhàn",
                      Description = "Tiền thân là Bệnh xá Mai Hương được xây dựng tại đầu ngõ Mai Hương",
                      Thumbnail = "",
                      Url = "https://benhvien115.com",
                      Address = "42 Phố Thanh Nhàn ,Hà Nội",
                      Phone = "028 3865 4139",
                      CreatedAt = DateTime.Now,
                      UpdatedAt = "3/17/2020",
                      DeletedAt = "Null",
                      UpdatedBy = 1,
                      Status = Models.HospitalStatus.ACTIVE
                  }
                );
            context.Policies.AddOrUpdate(
                  p => p.PolicyId,
                  new Models.Policy
                  {
                      PolicyId = 1,
                      Name = "Bảo hiểm sức khỏe",
                      Description = "Là loại hình bảo hiểm cho trường hợp người được bảo hiểm bị thương tật, ốm đau",
                      Amount = 6000.000M,
                      Emi = 500.000M,
                      AmountOfYear = 6000.000M,
                      Duration = 1,
                      CreatedAt = DateTime.Now,
                      UpdatedAt = "3/17/2020",
                      DeletedAt = "Null",
                      CreatedBy = 1,
                      UpdatedBy = 1,
                      Status = Models.PolicyStatus.PENDING,
                      CompanyId = 1,
                      HospitalId = 1,
                  }
                );
        }
    }
}
