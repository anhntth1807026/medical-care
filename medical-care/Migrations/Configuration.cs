using medical_care.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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
            var PasswordHash = new PasswordHasher();
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
                    Thumbnail =
                        "https://znews-photo.zadn.vn/w1024/Uploaded/qhj_yvobvhfwbv/2018_07_18/Nguyen_Huy_Binh1.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "Null",
                    Status = Models.CompanyStatus.ACTIVE,
                },
                new Models.Company
                {
                    CompanyId = 2,
                    Name = "CÔNG TY CP THIẾT BỊ Y TẾ BẢO THẠCH",
                    Description = "Công ty CP Thiết bị Y tế Bảo Thạch chuyên sản xuất khẩu trang y tế",
                    Address = "LôTổ 20 , Ấp Lai Khê Bình Dương – VIỆT NAM.",
                    Phone = "+84 (28) 3883 9869",
                    Url = "https://baothachonline",
                    Thumbnail =
                        "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRG_QGe5vtGJrj-PXqmqS2_ZRhl3VQ5OpBdsPFdm5xe_BWzeqWa",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "Null",
                    Status = Models.CompanyStatus.ACTIVE,
                },
                new Models.Company
                {
                    CompanyId = 3,
                    Name = "Công ty TNHH TM Sản Xuất Thiết Bị Y TẾ T & D",
                    Description = "thành lập đầu năm 2018, chuyên sản xuất và thương mại các sản phẩm khẩu trang y tế",
                    Address = "81/25 Huỳnh Văn Nghệ.",
                    Phone = "+84 938 84 64 58",
                    Url = "http://tdcare.com.vn",
                    Thumbnail =
                        "https://znews-photo.zadn.vn/w1024/Uploaded/qhj_yvobvhfwbv/2018_07_18/Nguyen_Huy_Binh1.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "Null",
                    Status = Models.CompanyStatus.ACTIVE,
                },
                new Models.Company
                {
                    CompanyId = 4,
                    Name = "Công Ty TNHH Xuất Nhập Khẩu Toàn Thắng",
                    Description = "trân trọng sứ mệnh mang đến những sản phẩm y tế chất lượng",
                    Address = "56 đường số 11 quận Gò VấpTp. Hồ Chí Minh.",
                    Phone = "+84 90 8957 085",
                    Url = "https://www.yellow.vn",
                    Thumbnail =
                        "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRG_QGe5vtGJrj-PXqmqS2_ZRhl3VQ5OpBdsPFdm5xe_BWzeqWa",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "Null",
                    Status = Models.CompanyStatus.ACTIVE,
                },
                new Models.Company
                {
                    CompanyId = 5,
                    Name = "Công ty TNHH TM Y tế Việt",
                    Description = "Sản phẩm chất lượng từ Nhật , Hàn",
                    Address = "số 2+4 ngõ 1160 đường Láng TP. Hà Nội.",
                    Phone = "+84 24 3683 617",
                    Url = "http://ytevietnhat.com.vn",
                    Thumbnail =
                        "https://znews-photo.zadn.vn/w1024/Uploaded/qhj_yvobvhfwbv/2018_07_18/Nguyen_Huy_Binh1.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "Null",
                    Status = Models.CompanyStatus.ACTIVE,
                },
                new Models.Company
                {
                    CompanyId = 6,
                    Name = "Công ty Cổ Phần Vinamed",
                    Description = "Tổng Công ty tập trung đẩy mạnh việc cung cấp các dịch vụ ,máy móc y tế",
                    Address = "89 Lương Định Của, Đống Đa, Hà Nội.",
                    Phone = "+84 24 3823 579",
                    Url = "http://Vinamed.com",
                    Thumbnail =
                        "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRG_QGe5vtGJrj-PXqmqS2_ZRhl3VQ5OpBdsPFdm5xe_BWzeqWa",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "Null",
                    Status = Models.CompanyStatus.ACTIVE,
                },
                new Models.Company
                {
                    CompanyId = 7,
                    Name = "Công ty TNHH Thương Mại Sản Xuất Thiết Bị Y Tế VN Pharma",
                    Description = "Công ty chuyên sản xuất thuốc, thực phẩm chức năng chất lượng cao",
                    Address = "53 Xã đàn , Hai Bà Trưng , Hà Nội.",
                    Phone = "+84 24 3788 577",
                    Url = "http://Vnpharma.com",
                    Thumbnail =
                        "https://znews-photo.zadn.vn/w1024/Uploaded/qhj_yvobvhfwbv/2018_07_18/Nguyen_Huy_Binh1.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "Null",
                    Status = Models.CompanyStatus.ACTIVE,
                },
                new Models.Company
                {
                    CompanyId = 8,
                    Name = "Công ty TNHH Memco",
                    Description = "Chuyển giao công nghệ trong lĩnh vực y dược.",
                    Address = "8103 KCN Hòa Cầm, quận Cẩm Lệ, Tp.Đà Nẵng.",
                    Phone = "+84 401 286 163",
                    Url = "http://tdcare.com.vn",
                    Thumbnail =
                        "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRG_QGe5vtGJrj-PXqmqS2_ZRhl3VQ5OpBdsPFdm5xe_BWzeqWa",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "Null",
                    Status = Models.CompanyStatus.ACTIVE,
                },
                new Models.Company
                {
                    CompanyId = 9,
                    Name = "Công ty TNHH TM Sản Xuất Thiết Bị Y TẾ SEN VIỆT",
                    Description = "chuyên SẢN XUẤT và KINH DOANH các dòng khẩu trang y tế chất lượng cao",
                    Address = "Đường D15, KDC Việt Sing,Bình Dương.",
                    Phone = "+84 65 3777 567",
                    Url = "http://SenViet.com",
                    Thumbnail =
                        "https://znews-photo.zadn.vn/w1024/Uploaded/qhj_yvobvhfwbv/2018_07_18/Nguyen_Huy_Binh1.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "Null",
                    Status = Models.CompanyStatus.ACTIVE,
                },
                new Models.Company
                {
                    CompanyId = 10,
                    Name = "Công ty TNHH Lư Gia",
                    Description = "công ty hợp tác cùng nhiều bệnh viện ,sản xuất thiết bị y tế",
                    Address = "71 - P.4 Gò Vấp, Tp.HCM.",
                    Phone = "+84 65 3777 567",
                    Url = "http://lugiamedical.com",
                    Thumbnail =
                        "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRG_QGe5vtGJrj-PXqmqS2_ZRhl3VQ5OpBdsPFdm5xe_BWzeqWa",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "Null",
                    Status = Models.CompanyStatus.ACTIVE,
                }
            );
            context.Employees.AddOrUpdate(
                p => p.Id,
                new Models.Employee
                {
                    Id = "A0011",
                    Email = "lilwayne@gmail.com",
                    EmailConfirmed = Convert.ToBoolean("False"),
                    PasswordHash = PasswordHash.HashPassword("thanh1234"),
                    SecurityStamp = "v=yAJnj6TiHCk&list=RDxB2qsCnqAXA&index=4",
                    PhoneNumber = "NULL",
                    PhoneNumberConfirmed = Convert.ToBoolean("False"),
                    AccessFailedCount = 0,
                    Firstname = "Lil",
                    Lastname = "Wayne",
                    UserName = "LilWayne001",
                    Password = "NULL",
                    Address = "3/1/2 Wall",
                    Phone = "0921212121",
                    City = "LosAngeless",
                    Country = "NULL",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "NULL",
                    UpdatedBy = 0,
                    DeletedAt = "Null",
                    EmpStatus = Models.EmpStatus.NORMAL
                },
                new Models.Employee
                {
                    Id = "A0012",
                    Email = "tuananh@gmail.com",
                    EmailConfirmed = Convert.ToBoolean("False"),
                    PasswordHash = PasswordHash.HashPassword("tanh1234"),
                    SecurityStamp = "v=yAJnj6TiHCk&list=RDxB2qsCnqAXA&index=4",
                    PhoneNumber = "NULL",
                    PhoneNumberConfirmed = Convert.ToBoolean("False"),
                    AccessFailedCount = 0,
                    Firstname = "Tuan Anh",
                    Lastname = "Nguyen",
                    UserName = "TuanAnh001",
                    Password = "NULL",
                    Address = "23 Lý Thường Kiệt",
                    Phone = "0945852000",
                    City = "Nam Dinh",
                    Country = "NULL",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "NULL",
                    UpdatedBy = 0,
                    DeletedAt = "NULL",
                    EmpStatus = Models.EmpStatus.NORMAL
                },
                new Models.Employee
                {
                    Id = "A0013",
                    Email = "thanhhoa@gmail.com",
                    EmailConfirmed = Convert.ToBoolean("False"),
                    PasswordHash = PasswordHash.HashPassword("hoa1234"),
                    SecurityStamp = "v=yAJnj6TiHCk&list=RDxB2qsCnqAXA&index=4",
                    PhoneNumber = "NULL",
                    PhoneNumberConfirmed = Convert.ToBoolean("False"),
                    AccessFailedCount = 0,
                    Firstname = "Thanh Hoa",
                    Lastname = "Pham",
                    UserName = "ThanhHoa001",
                    Password = "NULL",
                    Address = "58 Trần Bình",
                    Phone = "0394075235",
                    City = "Thai Binh",
                    Country = "NULL",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "NULL",
                    UpdatedBy = 0,
                    DeletedAt = "NULL",
                    EmpStatus = Models.EmpStatus.NORMAL
                },
                new Models.Employee
                {
                    Id = "A0014",
                    Email = "tatthanh@gmail.com",
                    EmailConfirmed = Convert.ToBoolean("False"),
                    PasswordHash = PasswordHash.HashPassword("thanh1234"),
                    SecurityStamp = "v=yAJnj6TiHCk&list=RDxB2qsCnqAXA&index=4",
                    PhoneNumber = "NULL",
                    PhoneNumberConfirmed = Convert.ToBoolean("False"),
                    AccessFailedCount = 0,
                    Firstname = "Tat Thanh",
                    Lastname = "Hoang",
                    UserName = "TatThanh001",
                    Password = "thanh1234",
                    Address = "35 Trần Hưng Đạo",
                    Phone = "0329581759",
                    City = "Thuong Tin",
                    Country = "NULL",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "NULL",
                    UpdatedBy = 0,
                    DeletedAt = "NULL",
                    EmpStatus = Models.EmpStatus.NORMAL
                },
                new Models.Employee
                {
                    Id = "A0015",
                    Email = "xuanbach@gmail.com",
                    EmailConfirmed = Convert.ToBoolean("False"),
                    PasswordHash = PasswordHash.HashPassword("bach1234"),
                    SecurityStamp = "v=yAJnj6TiHCk&list=RDxB2qsCnqAXA&index=4",
                    PhoneNumber = "NULL",
                    PhoneNumberConfirmed = Convert.ToBoolean("False"),
                    AccessFailedCount = 0,
                    Firstname = "Xuan Bach",
                    Lastname = "Luong",
                    UserName = "XuanBach001",
                    Password = "NULL",
                    Address = "11 Hoàng Cầu",
                    Phone = "0869207696",
                    City = "Thuong Tin",
                    Country = "NULL",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "NULL",
                    UpdatedBy = 0,
                    DeletedAt = "NULL",
                    EmpStatus = Models.EmpStatus.NORMAL
                },
                new Models.Employee
                {
                    Id = "A0016",
                    Email = "tieubinh@gmail.com",
                    EmailConfirmed = Convert.ToBoolean("False"),
                    PasswordHash = PasswordHash.HashPassword("binh1234"),
                    SecurityStamp = "v=yAJnj6TiHCk&list=RDxB2qsCnqAXA&index=4",
                    PhoneNumber = "NULL",
                    PhoneNumberConfirmed = Convert.ToBoolean("False"),
                    AccessFailedCount = 0,
                    Firstname = "Tieu Binh",
                    Lastname = "Dang",
                    UserName = "TieuBinh001",
                    Password = "NULL",
                    Address = "98 Song Hao",
                    Phone = "0962598165",
                    City = "Ha Dong",
                    Country = "NULL",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "NULL",
                    UpdatedBy = 0,
                    DeletedAt = "NULL",
                    EmpStatus = Models.EmpStatus.NORMAL
                },
                new Models.Employee
                {
                    Id = "A0017",
                    Email = "quangkhai@gmail.com",
                    EmailConfirmed = Convert.ToBoolean("False"),
                    PasswordHash = PasswordHash.HashPassword("khai1234"),
                    SecurityStamp = "v=yAJnj6TiHCk&list=RDxB2qsCnqAXA&index=4",
                    PhoneNumber = "NULL",
                    PhoneNumberConfirmed = Convert.ToBoolean("False"),
                    AccessFailedCount = 0,
                    Firstname = "Quang Khai",
                    Lastname = "Ho",
                    UserName = "QuangKhai001",
                    Password = "NULL",
                    Address = "654 Ba Trieu",
                    Phone = "0917388156",
                    City = "Hai Duong",
                    Country = "NULL",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "NULL",
                    UpdatedBy = 0,
                    DeletedAt = "NULL",
                    EmpStatus = Models.EmpStatus.NORMAL
                },
                new Models.Employee
                {
                    Id = "A0018",
                    Email = "thanhthao@gmail.com",
                    EmailConfirmed = Convert.ToBoolean("False"),
                    PasswordHash = PasswordHash.HashPassword("thao1234"),
                    SecurityStamp = "v=yAJnj6TiHCk&list=RDxB2qsCnqAXA&index=4",
                    PhoneNumber = "NULL",
                    PhoneNumberConfirmed = Convert.ToBoolean("False"),
                    AccessFailedCount = 0,
                    Firstname = "Thanh Thao",
                    Lastname = "Phung",
                    UserName = "ThanhThao001",
                    Password = "NULL",
                    Address = "487 Hang Bai",
                    Phone = "0721894536",
                    City = "Phu Tho",
                    Country = "NULL",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "NULL",
                    UpdatedBy = 0,
                    DeletedAt = "NULL",
                    EmpStatus = Models.EmpStatus.NORMAL
                },
                new Models.Employee
                {
                    Id = "A0019",
                    Email = "quocanh@gmail.com",
                    EmailConfirmed = Convert.ToBoolean("False"),
                    PasswordHash = PasswordHash.HashPassword("anh1234"),
                    SecurityStamp = "v=yAJnj6TiHCk&list=RDxB2qsCnqAXA&index=4",
                    PhoneNumber = "NULL",
                    PhoneNumberConfirmed = Convert.ToBoolean("False"),
                    AccessFailedCount = 0,
                    Firstname = "Quoc Anh",
                    Lastname = "Do",
                    UserName = "QuocAnh001",
                    Password = "NULL",
                    Address = "72b Quoc Tu Giam",
                    Phone = "0775867749",
                    City = "Lao Cai",
                    Country = "NULL",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "NULL",
                    UpdatedBy = 0,
                    DeletedAt = "NULL",
                    EmpStatus = Models.EmpStatus.NORMAL,
                },
                new Models.Employee
                {
                    Id = "A0020",
                    Email = "linhdat@gmail.com",
                    EmailConfirmed = Convert.ToBoolean("False"),
                    PasswordHash = PasswordHash.HashPassword("dat1234"),
                    SecurityStamp = "v=yAJnj6TiHCk&list=RDxB2qsCnqAXA&index=4",
                    PhoneNumber = "NULL",
                    PhoneNumberConfirmed = Convert.ToBoolean("False"),
                    AccessFailedCount = 0,
                    Firstname = "Linh Dat",
                    Lastname = "Nguyen",
                    UserName = "LinhDat001",
                    Password = "NULL",
                    Address = "77 Do Quan",
                    Phone = "0968753214",
                    City = "Nam Dinh",
                    Country = "NULL",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "NULL",
                    UpdatedBy = 0,
                    DeletedAt = "NULL",
                    EmpStatus = Models.EmpStatus.NORMAL
                },
                new Models.Employee
                {
                    Id = "A0021",
                    Email = "tuanminh@gmail.com",
                    EmailConfirmed = Convert.ToBoolean("False"),
                    PasswordHash = PasswordHash.HashPassword("minh1234"),
                    SecurityStamp = "v=yAJnj6TiHCk&list=RDxB2qsCnqAXA&index=4",
                    PhoneNumber = "NULL",
                    PhoneNumberConfirmed = Convert.ToBoolean("False"),
                    AccessFailedCount = 0,
                    Firstname = "Tuan Minh",
                    Lastname = "Le",
                    UserName = "TuanMinh001",
                    Password = "NULL",
                    Address = "72 Nang Tinh",
                    Phone = "0985641237",
                    City = "Thai Nguyen",
                    Country = "NULL",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "NULL",
                    UpdatedBy = 0,
                    DeletedAt = "NULL",
                    EmpStatus = Models.EmpStatus.NORMAL
                },
                new Models.Employee
                {
                    Id = "A0022",
                    Email = "quochung@gmail.com",
                    EmailConfirmed = Convert.ToBoolean("False"),
                    PasswordHash = PasswordHash.HashPassword("hung1234"),
                    SecurityStamp = "v=yAJnj6TiHCk&list=RDxB2qsCnqAXA&index=4",
                    PhoneNumber = "NULL",
                    PhoneNumberConfirmed = Convert.ToBoolean("False"),
                    AccessFailedCount = 0,
                    Firstname = "Quoc Hung",
                    Lastname = "Hoang",
                    UserName = "QuocHung001",
                    Password = "NULL",
                    Address = "1098 Hoang Minh Giam",
                    Phone = "0394587621",
                    City = "Ninh Binh",
                    Country = "NULL",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "NULL",
                    UpdatedBy = 0,
                    DeletedAt = "NULL",
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
                    Thumbnail = "Null",
                    Url = "http://thanhnhan.com",
                    Address = "42 Phố Thanh Nhàn ,Hà Nội",
                    Phone = "+84 93 2222 123",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "3/17/2020",
                    DeletedAt = "Null",
                    UpdatedBy = 1,
                    Status = Models.HospitalStatus.ACTIVE
                },
                new Models.Hospital
                {
                    HospitalId = 2,
                    Name = "Bệnh viện Bạch Mai",
                    Description = "Bệnh viên hàng đầu của TW",
                    Thumbnail = "Null",
                    Url = "http://bachmai.com",
                    Address = "78 Đường Giải Phóng,Hà Nội",
                    Phone = "+84 43 8693 731",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "3/17/2020",
                    DeletedAt = "Null",
                    UpdatedBy = 1,
                    Status = Models.HospitalStatus.ACTIVE
                },
                new Models.Hospital
                {
                    HospitalId = 3,
                    Name = "Bệnh viện Thanh Nhàn",
                    Description = "Thương hiệu Bệnh viện Nhân dân 115 là bệnh viện của nhân dân",
                    Thumbnail = "Null",
                    Url = "https://benhvien115.com",
                    Address = "Phường 12, Quận 10, Thành phố Hồ Chí Minh",
                    Phone = "+84 28 3865 139",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "3/17/2020",
                    DeletedAt = "Null",
                    UpdatedBy = 1,
                    Status = Models.HospitalStatus.ACTIVE
                },
                new Models.Hospital
                {
                    HospitalId = 4,
                    Name = "Bệnh viện Việt Đức",
                    Description = "Bợp tác hữu nghị cùng phát triển với Đức",
                    Thumbnail = "Null",
                    Url = "http://vietduc.com",
                    Address = "40 Tràng Thi, Hoàn Kiếm, Hà Nội",
                    Phone = "(84- 24) 38.253.531",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "3/17/2020",
                    DeletedAt = "Null",
                    UpdatedBy = 1,
                    Status = Models.HospitalStatus.ACTIVE
                },
                new Models.Hospital
                {
                    HospitalId = 5,
                    Name = "Bệnh viện Hồng Ngọc",
                    Description = "Hệ thống y tế tư nhân hàng đầu Việt Nam.",
                    Thumbnail = "Null",
                    Url = "http://hongngoc.com",
                    Address = "Số 55 Yên Ninh,Trúc Bạch, Ba Đình, Hà Nội",
                    Phone = "0936 2112 342",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "3/17/2020",
                    DeletedAt = "Null",
                    UpdatedBy = 1,
                    Status = Models.HospitalStatus.ACTIVE
                },
                new Models.Hospital
                {
                    HospitalId = 6,
                    Name = "Bệnh viện da liễu",
                    Description = "Chuyên trị các bệnh về da liễu",
                    Thumbnail = "Null",
                    Url = "http://dalieu.com",
                    Address = "42 Phường 6, Quận 3, TP HCM",
                    Phone = "(028).39.301.396",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "3/17/2020",
                    DeletedAt = "Null",
                    UpdatedBy = 1,
                    Status = Models.HospitalStatus.ACTIVE
                },
                new Models.Hospital
                {
                    HospitalId = 7,
                    Name = "Bệnh viện Hoàn Mỹ",
                    Description = "Bệnh viện Hoàn Mỹ Sài Gòn gia nhập Tập Đoàn Quốc Tế Fortis.",
                    Thumbnail = "Null",
                    Url = "http://hoanmy.com",
                    Address = "Phường 3, Quận Bình Thạnh, TP HCM",
                    Phone = "(028) 3990 2468",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "3/17/2020",
                    DeletedAt = "Null",
                    UpdatedBy = 1,
                    Status = Models.HospitalStatus.ACTIVE
                },
                new Models.Hospital
                {
                    HospitalId = 8,
                    Name = "Bệnh viện K",
                    Description = "Bệnh viện ung bướu trung ương được thành lập từ năm 1969",
                    Thumbnail = "Null",
                    Url = "http://vienK.com",
                    Address = "Tựu Liệt, Tam Hiệp, Hà Nội",
                    Phone = "028 3865 4139",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "3/17/2020",
                    DeletedAt = "Null",
                    UpdatedBy = 1,
                    Status = Models.HospitalStatus.ACTIVE
                },
                new Models.Hospital
                {
                    HospitalId = 9,
                    Name = "Bệnh viện Hanh Phúc",
                    Description = "Nhà cung cấp dịch vụ chăm sóc sức khỏe dành cho phụ nữ và trẻ em",
                    Thumbnail = "Null",
                    Url = "http://hanhphuc.com",
                    Address = "Số 18 Đại lộ Bình Dương",
                    Phone = "1900 6765",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "3/17/2020",
                    DeletedAt = "Null",
                    UpdatedBy = 1,
                    Status = Models.HospitalStatus.ACTIVE
                },
                new Models.Hospital
                {
                    HospitalId = 10,
                    Name = "Bệnh viện Việt Pháp",
                    Description = "Hợp tác hữu nghị với Pháp",
                    Thumbnail = "Null",
                    Url = "http://VietPhap.com",
                    Address = "Số 01 Đường Phương Mai, Quận Đống Đa, Hà Nội",
                    Phone = "(028).39.666.396",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "3/17/2020",
                    DeletedAt = "NULL",
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
                    UpdatedAt = "NUll",
                    DeletedAt = "NULL",
                    CreatedBy = 1,
                    UpdatedBy = 1,
                    Status = Models.PolicyStatus.NORMAL,
                    CompanyId = 5,
                    HospitalId = 5,
                },
                new Models.Policy
                {
                    PolicyId = 2,
                    Name = "Bảo hiểm nhân thọ",
                    Description = "là loại nghiệp vụ bảo hiểm cho người được bảo hiểm sống hoặc chết",
                    Amount = 16000.000M,
                    Emi = 1500.000M,
                    AmountOfYear = 16000.000M,
                    Duration = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "Null",
                    CreatedBy = 1,
                    UpdatedBy = 1,
                    Status = Models.PolicyStatus.NORMAL,
                    CompanyId = 1,
                    HospitalId = 1,
                },
                new Models.Policy
                {
                    PolicyId = 3,
                    Name = "Bảo hiểm phi nhân thọ",
                    Description =
                        "là loại nghiệp vụ bảo hiểm tài sản, trách nhiệm dân sự và các nghiệp vụ bảo hiểm khác",
                    Amount = 120000.000M,
                    Emi = 1000.000M,
                    AmountOfYear = 12000.000M,
                    Duration = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "Null",
                    CreatedBy = 1,
                    UpdatedBy = 1,
                    Status = Models.PolicyStatus.NORMAL,
                    CompanyId = 2,
                    HospitalId = 2,
                },
                new Models.Policy
                {
                    PolicyId = 4,
                    Name = "Bảo hiểm y tế",
                    Description = "là sự bảo đảm thay thế hoặc bù đắp một phần thu nhập của người lao động",
                    Amount = 2400.000M,
                    Emi = 200.000M,
                    AmountOfYear = 2400.000M,
                    Duration = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "Null",
                    CreatedBy = 1,
                    UpdatedBy = 1,
                    Status = Models.PolicyStatus.NORMAL,
                    CompanyId = 3,
                    HospitalId = 3,
                }
            );
            context.PolicyRequests.AddOrUpdate(
                p => p.RequestId,
                new Models.PolicyRequest
                {
                    RequestId = 1,
                    RequestDate = Convert.ToDateTime("3/25/2020"),
                    Amount = 80000.000M,
                    Emi = 10000.000M,
                    CompanyName = "Công ty TNHH TM Y tế Việt",
                    PolicyName = "Bảo hiểm y tế",
                    Status = PolicyRequestStatus.DEACTIVE,
                    Id = "A0011",
                    PolicyId = 1,
                },
                new Models.PolicyRequest
                {
                    RequestId = 2,
                    RequestDate = Convert.ToDateTime("3/27/2020"),
                    Amount = 120000.000M,
                    Emi = 30000.000M,
                    CompanyName = "CÔNG TY CP THIẾT BỊ Y TẾ BẢO THẠCH",
                    PolicyName = "Bảo hiểm sức khỏe",
                    Status = PolicyRequestStatus.DEACTIVE,
                    Id = "A0012",
                    PolicyId = 3,
                },
                new Models.PolicyRequest
                {
                    RequestId = 3,
                    RequestDate = Convert.ToDateTime("3/26/2020"),
                    Amount = 90000.000M,
                    Emi = 1500.000M,
                    CompanyName = "Công ty TNHH TM Sản Xuất Thiết Bị Y TẾ T & D",
                    PolicyName = "Bảo hiểm phi nhân thọ",
                    Status = PolicyRequestStatus.DEACTIVE,
                    Id = "A0013",
                    PolicyId = 4,
                },
                new Models.PolicyRequest
                {
                    RequestId = 4,
                    RequestDate = Convert.ToDateTime("3/29/2020"),
                    Amount = 400000.000M,
                    Emi = 50000.000M,
                    CompanyName = "Tập đoàn Phương Đông",
                    PolicyName = "NULL",
                    Status = PolicyRequestStatus.DEACTIVE,
                    Id = "A0014",
                    PolicyId = 2,
                }
            );
            context.PolicyOnEmps.AddOrUpdate(
                p => p.Id,
                new Models.PolicyOnEmp
                {
                    Id = 1,
                    PolicyName = "Bảo hiểm sức khỏe",
                    PolicyAmount = 6000.000M,
                    PolicyDuration = 0,
                    Emi = 0,
                    PolicyStart = Convert.ToDateTime("3/25/2020"),
                    PolicyEnd = Convert.ToDateTime("3/25/2021"),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "NULL",
                    CreatedBy = 1,
                    UpdatedBy = 0,
                    Status = PolOnEmpStatus.ACTIVE,
                    EmployeeId = "A0011",
                    PolicyId = 1,
                },
                new Models.PolicyOnEmp
                {
                    Id = 2,
                    PolicyName = "Bảo hiểm sức khỏe",
                    PolicyAmount = 6000.000M,
                    PolicyDuration = 0,
                    Emi = 0,
                    PolicyStart = Convert.ToDateTime("3/26/2020"),
                    PolicyEnd = Convert.ToDateTime("3/26/2021"),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "NULL",
                    CreatedBy = 1,
                    UpdatedBy = 0,
                    Status = PolOnEmpStatus.ACTIVE,
                    EmployeeId = "A0012",
                    PolicyId = 3,
                },
                new Models.PolicyOnEmp
                {
                    Id = 3,
                    PolicyName = "Bảo hiểm sức khỏe",
                    PolicyAmount = 6000.000M,
                    PolicyDuration = 0,
                    Emi = 0,
                    PolicyStart = Convert.ToDateTime("3/28/2020"),
                    PolicyEnd = Convert.ToDateTime("3/28/2021"),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "NULL",
                    CreatedBy = 1,
                    UpdatedBy = 0,
                    Status = PolOnEmpStatus.ACTIVE,
                    EmployeeId = "A0013",
                    PolicyId = 4,
                },
                new Models.PolicyOnEmp
                {
                    Id = 4,
                    PolicyName = "Bảo hiểm sức khỏe",
                    PolicyAmount = 6000.000M,
                    PolicyDuration = 0,
                    Emi = 0,
                    PolicyStart = Convert.ToDateTime("3/26/2020"),
                    PolicyEnd = Convert.ToDateTime("3/26/2022"),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = "Null",
                    DeletedAt = "NULL",
                    CreatedBy = 1,
                    UpdatedBy = 0,
                    Status = PolOnEmpStatus.ACTIVE,
                    EmployeeId = "A0014",
                    PolicyId = 2,
                }
            );
            context.Roles.AddOrUpdate(
                p => p.Id,
                new IdentityRole()
                {
                    Id = "Ad",
                    Name = "admin",
                },
                new IdentityRole()
                {
                    Id = "User",
                    Name = "employee",
                }
            );
            //context.Users.AddOrUpdate(
            //    p => p.Id,
            //      new IdentityUserRole
            //      {
            //          UserId = "A0011",
            //          RoleId = "User"
            //      },
            //      new IdentityUserRole
            //      {
            //          UserId = "A0012",
            //          RoleId = "Ad"
            //      },
            //      new IdentityUserRole
            //      {
            //          UserId = "A0013",
            //          RoleId = "Ad"
            //      },
            //      new IdentityUserRole
            //      {
            //          UserId = "A0014",
            //          RoleId = "User"
            //      },
            //      new IdentityUserRole
            //      {
            //          UserId = "A0015",
            //          RoleId = "User"
            //      },
            //      new IdentityUserRole
            //      {
            //          UserId = "A0016",
            //          RoleId = "User"
            //      },
            //      new IdentityUserRole
            //      {
            //          UserId = "A0017",
            //          RoleId = "User"
            //      },
            //      new IdentityUserRole
            //      {
            //          UserId = "A0018",
            //          RoleId = "User"
            //      },
            //      new IdentityUserRole
            //      {
            //          UserId = "A0019",
            //          RoleId = "User"
            //      },
            //      new IdentityUserRole
            //      {
            //          UserId = "A0020",
            //          RoleId = "User"
            //      },
            //      new IdentityUserRole
            //      {
            //          UserId = "A0021",
            //          RoleId = "User"
            //      },
            //      new IdentityUserRole
            //      {
            //          UserId = "A0022",
            //          RoleId = "User"
            //      }
            //);
        }

    }
}
