create database QLNhanVien
go

use QLNhanVien
go

drop table PhongBan
go

create table PhongBan(
  MaPhong nvarchar(50) not null primary key,
  TenPhong nvarchar(60) 

)
go

create table NhanVien(
  MaNV nvarchar(50) not null primary key,
  HoTen nvarchar(60) not null,
  Luong int not null,
  Thuong int not null,
  MaPhong nvarchar(50) not null,
  constraint fk_NV_PB foreign key (MaPhong) references PhongBan(MaPhong)
  on delete cascade on update cascade
)
go

