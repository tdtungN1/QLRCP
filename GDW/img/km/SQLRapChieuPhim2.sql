	create database QLRapChieuPhim
	go
	use QLRapChieuPhim
	go
	--1--Phim
	create table Film 
	( 
	ID_film varchar(5) primary key not null,
	Name_film nvarchar(50) not null,
	director nvarchar(50),--đạo diễn
	producer nvarchar(30), 
	genre_film nvarchar(30),--loại phim
	running_time float, --thời lượng
	version_film nvarchar(20),--phiên bản
	release_date date,--ngày khởi chiếu
	nation nvarchar(30),--quốc gia
	cast_film nvarchar(100),--diễn viên chính
	describe nvarchar(500),-- mô tả
	rated nvarchar(100) --đánh giá
	)
	--2--loại phim
	create table Genre_film 
	(
	ID_genre varchar(5) primary key not null,
	name_genre nvarchar(30),
	ID_film varchar(5) references Film(ID_film)
	)
	--4--Loại phòng chiếu
	create table Genre_room
	(
	ID_genre varchar(5) primary key not null,
	name_genre nvarchar(30) --tên loại
	)
	--3--phòng chiếu
	create table Projection_room 
	(
	ID_room varchar(5) primary key not null,
	name_room nvarchar (20),
	ID_genre varchar(5) not null references Genre_room(ID_genre),
	number_seats int, --số ghế
	status_room nvarchar(20), --trạng thái phòng chiếu (còn-hết ghế)
	status_present nvarchar(20), --tình trạng hiện tại (đang chiếu - đang dọn- đang bảo trì)
	device_room nvarchar(30) --thiết bị phòng
	)
	--8--loại vé
	create table Genre_ticket
	( 
	ID_genre varchar(5) primary key not null,
	name_genre nvarchar(20) not null,
	)
	--7--loại ghế
	create table Genre_seat
	(
		ID_genre varchar(5) primary key not null,
		name_genre nvarchar(20)
	)	
	
	--5--Lịch chiếu phim
	create table Movie_schedule
	(
	ID_schedule varchar(5) primary key not null,
	ID_room varchar(5) not null references Projection_room (ID_room),
	date_movie date, --ngày chiếu
	time_movie time, --thời gian
	name_film nvarchar(50) --tên phim
	)
	--6--Vé
	create table Ticket
	(
		ID_ticket varchar(5) primary key not null,
		ID_film varchar(5) not null references Film(ID_film),
		ID_genre varchar(5) not null references Genre_ticket(ID_genre),
		ID_seat varchar(5) not null references Genre_seat(ID_genre),
		ID_schedule varchar(5) not null references Movie_schedule(ID_schedule)
	)
	
	
	--9--create table NhanVien
	--(
	--ID int primary key,
	--Ten nvarchar(50),
	--GioiTinh varchar(5),
	--Diachi nvarchar(100),
	--SDT varchar(11),
	--ViTri nvarchar(30),
	--TrangThai varchar(10),
	--NgayBD datetime
	--)
	--create table KhachHang
	--(
	--ID int primary key,
	--Ten nvarchar(50),
	--GioiTinh varchar(5),
	--DiaChi nvarchar(100),
	--SDT varchar(11),
	--NgayBD datetime
	--)
	

