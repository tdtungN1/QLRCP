﻿
//Click nuts xem phongf
function BtnViewRoom_Click() {
    $("#btn-add-room").css('display', 'block');
    $("#btn-edit-room").css('display', 'block');
    var max_row = $(".room-row").val();
    var max_col = $(".room-col").val();
    if (max_row > 26) {
        max_row = 26;
        $(".room-row").val(26);
    }
    if (max_row < 1) {
        max_row = 1;
        $(".room-row").val(1);
    }
    if (max_col > 50) {
        max_col = 50;
        $(".room-col").val(50);
    }
    if (max_col < 1) {
        max_col = 1;
        $(".room-col").val(1);
    }

    var html = "";
    for (var i = 1; i <= max_row; i++) {
        html += "<tr numrow = '" + i + "'>";
        html += "<td>";
        html += "<select name = 'genre-chair' class='select-genre-chair' numrow = '" + i + "'></select></td>";
        for (var j = 1; j <= max_row; j++) {
            html += "<td class='text-center view-chair normal-chair' namechair ='" + String.fromCharCode(i + 64) + j + "'><div class='glyphicon glyphicon-user'></div><div>" + String.fromCharCode(i + 64) + j + "</div></td>";
        }
        html += "</tr>";
    }
    $(".view-room").html(html);
    //Hiển thị loại ghế để chọn
    $.ajax({
        url: "/api/GenreChair",
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            var chair = "";
            $.each(res, function (i, item) {
                chair += "<option value='" + item.GenreChairID + "' > " + item.GenreChairName + "</option>";
            });
            $('.select-genre-chair').append(chair);
        }
    });
    //Khi chọn loại ghế trong select
    $('.select-genre-chair').change(function () {
        var i = $(this).attr('numrow');
        var genrechair = $(".view-room tr[numrow = '" + i + "'] .view-chair");
        if ($(this).val() == 2) {
            if (!genrechair.hasClass("vip-chair")) {
                genrechair.addClass("vip-chair");
            }
            if (genrechair.hasClass("couple-chair")) {
                genrechair.removeClass("couple-chair");
            }
            if (genrechair.hasClass("normal-chair")) {
                genrechair.removeClass("normal-chair");
            }
        }
        else if ($(this).val() == 3) {
            if (!genrechair.hasClass("couple-chair")) {
                genrechair.addClass("couple-chair");
            }
            if (genrechair.hasClass("vip-chair")) {
                genrechair.removeClass("vip-chair");
            }
            if (genrechair.hasClass("normal-chair")) {
                genrechair.removeClass("normal-chair");
            }
        }
        else {
            if (!genrechair.hasClass("normal-chair")) {
                genrechair.addClass("normal-chair");
            }
            if (genrechair.hasClass("vip-chair")) {
                genrechair.removeClass("vip-chair");
            }
            if (genrechair.hasClass("couple-chair")) {
                genrechair.removeClass("couple-chair");
            }
        }
    });
}
//Chọn loại ghế
function SelectGenreRoom() {
    $.ajax({
        url: "/api/GenreRoom",
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            var check = -1;
            if ($(".select-genre-room").attr('valuecheck')) {
                check = $(".select-genre-room").attr('valuecheck');
            };
            var option = "";
            $.each(res, function (i, item) {
                option += "<option value = '" + item.GenreRoomID + "' ";
                if (check == item.GenreRoomID) {
                    option += " selected ";
                }
                option += ">" + item.GenreRoomName + "</option>";
            });
            $(".select-genre-room").append(option);
        }
    });
}
//Định dạng ngày tháng : dd/MM/YYYY
function formatdate(date) {
    dates = new Date(date);
    var day = dates.getDate();
    var month = dates.getMonth();
    var year = dates.getFullYear();
    return day + "/" + month + "/" + year;
}

function formatFullDate(date) {
    dates = new Date(date);
    var day = dates.getDate();
    var month = dates.getMonth();
    var year = dates.getFullYear();
    var hours = dates.getHours();
    var minute = dates.getMinutes();
    return hours + ":" + minute + " - " + day + "/" + month + "/" + year;
}
//Lấy trạng thái phim
//0: Sắp chiếu
//1: Đang chiếu
//#: Ngừng chiếu
function GetStatusFilm(status) {
    if (status == 0) {
        return "Sắp chiếu";
    }
    else if (status == 1) {
        return "Đang chiếu";
    }
    else {
        return "Ngừng chiếu";
    }
}
//Lấy trạng thái phòng
//0: Không kích hoạt
//1: Kích hoạt
function GetStatusRoom(status) {
    if (status == 0) {
        return "Không kích hoạt";
    }
    else if (status == 1) {
        return "Kích hoạt";
    }
    else {
        return "Null";
    }
}

//Sửa phòng
function BtnEditRoom_Click() {
    var RoomID = $("input[name = 'RoomID']").val();
    var genreRoomID = $("select[name = 'GenreRoomID']").val();
    var roomName = $("input[name = 'RoomName']").val();
    var status = $("input[name = 'StatusRoom']");
    var statusRoom = 0;
    for (var i = 0; i < status.length; i++) {
        if (status[i].checked === true) {
            statusRoom = status[i].value;
        }
    }
    var numRow = $(".room-row").val();
    var numCol = $(".room-col").val();
    var room = { GenreRoomID: genreRoomID, RoomName: roomName, StatusRoom: statusRoom, NumRow: numRow, NumCol: numCol };
    //Sửa phòng
    $.ajax({
        type: "PUT",
        url: "/api/Rooms/" + RoomID,
        data: JSON.stringify(room),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            if (res == 0) {
                alert("Thêm thất bại");
            }
            else {
                var chairs = [];
                $(".view-chair").each(function (i) {
                    var name = $(this).attr('namechair');
                    var loai;
                    if ($(this).hasClass('normal-chair')) {
                        loai = 1;
                    }
                    else if ($(this).hasClass('vip-chair')) {
                        loai = 2;
                    }
                    else {
                        loai = 3;
                    }
                    var obj = { ChairName: name, GenreChairID: loai, RoomID: RoomID };
                    chairs.push(obj);
                });
                console.log(chairs);
                //Sửa lại ghế
                $.ajax({
                    type: "PUT",
                    url: "/api/Chair/" + RoomID,
                    data: JSON.stringify(chairs),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        alert("Sửa thành công!");
                        location.href = "/Admin/Rooms/Index";
                    }
                })
            }
        }
    })
}
//Sửa loại phim
function BtnEditGenreFilm_Click(id) {
    var genreFilmName = $("select[name = 'GenreFilmName']").val();
    var genreFilm = { GenreFilmName: genreFilmName };
    $.ajax({
        type: "PUT",
        url: "/api/Genre_film/" + id,
        data: JSON.stringify(genreFilm),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            if (res == 0) {
                alert("Thêm thất bại");
            }
            else {
                alert("Thêm thành công!");
                location.href = "/Admin/Genre_film/Index";
            }
        }
    })
}
//Sửa Film
function BtnEditFilm_Click(id) {
    var FilmID = $("input[name = 'FilmID']").val();
    var FilmName = ($("input[name = 'FilmName']").val().length > 0) ? $("input[name = 'FilmName']").val() : "";
    var Author = ($("input[name = 'Author']").val().length > 0) ? $("input[name = 'Author']").val() : "";
    var Producer = ($("input[name = 'Producer']").val() > 0) ? $("input[name = 'Producer']").val() : "";
    var ReleaseDate = ($("input[name = 'ReleaseDate']").val().length > 0) ? $("input[name = 'ReleaseDate']").val() : "";
    var Nation = ($("input[name = 'Nation']").val().length > 0) ? $("input[name = 'Nation']").val() : "";
    var Rated = ($("input[name = 'Rated']").val().length > 0) ? $("input[name = 'Rated']").val() : 0;
    var Actor = ($("input[name = 'Actor']").val().length > 0) ? $("input[name = 'Actor']").val() : "";
    var Status = 0;
    var Images = ($("#image-film").attr('src').length > 0) ? $("#image-film").attr('src') : "";
    $("input[name = 'Status']").each(function () {
        if ($(this).is(":checked")) {
            Status = $(this).val();
        }
    })

    var Description = $("textarea[name = 'Description']").val();
    var Trailer = $("textarea[name = 'trailer']").val();
    debugger
    var film = { FilmName: FilmName, Author: Author, Producer: Producer, ReleaseDate: ReleaseDate, Nation: Nation, Rated: Rated, Actor: Actor, Status: Status, Description: Description, Images: Images, Trailer: Trailer };
    var genreFilm = [];
    $("input[name = 'GenreFilm']").each(function () {
        if ($(this).is(":checked")) {
            var obj = { FilmID: FilmID, GenreFilmID: $(this).val() };
            genreFilm.push(obj);
        }
    })
    //Sửa phim
    $.ajax({
        type: "PUT",
        url: "/api/Film/" + FilmID,
        data: JSON.stringify(film),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            if (res == 0) {
                alert("Sửa thất bại");
            }
            else {
                alert("Sửa thành công!");
                //Thêm loại phim
                $.ajax({
                    type: "PUT",
                    url: "/api/Film_GenreFilm/" + FilmID,
                    data: JSON.stringify(genreFilm),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (res) {
                    }
                });
                location.href = "/Admin/Films/Index";
            }
        }
    });
}

//Thêm phòng
function BtnAddRoom_Click() {
    var genreRoomID = $("select[name = 'GenreRoomID']").val();
    var roomName = $("input[name = 'RoomName']").val();
    var status = $("input[name = 'StatusRoom']");
    var statusRoom = 0;
    for (var i = 0; i < status.length; i++) {
        if (status[i].checked === true) {
            statusRoom = status[i].value;
        }
    }
    var numRow = $(".room-row").val();
    var numCol = $(".room-col").val();
    var room = { GenreRoomID: genreRoomID, RoomName: roomName, StatusRoom: statusRoom, NumRow: numRow, NumCol: numCol };
    //Thêm mới phòng
    $.ajax({
        type: "POST",
        url: "/api/Rooms",
        data: JSON.stringify(room),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            if (res == 0) {
                alert("Thêm thất bại");
            }
            else {
                var chairs = [];
                $(".view-chair").each(function (i) {
                    var name = $(this).attr('namechair');
                    var loai;
                    if ($(this).hasClass('normal-chair')) {
                        loai = 1;
                    }
                    else if ($(this).hasClass('vip-chair')) {
                        loai = 2;
                    }
                    else {
                        loai = 3;
                    }
                    var obj = { ChairName: name, GenreChairID: loai, RoomID: res };
                    chairs.push(obj);
                });
                console.log(chairs);
                //Thêm ghế
                $.ajax({
                    type: "POST",
                    url: "/api/Chair",
                    data: JSON.stringify(chairs),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        alert("Thêm thành công!");
                        location.href = "/Admin/Rooms/Index";
                    }
                })
            }
        }
    })
}
//THêm loại film
function BtnAddGenreFilm_Click() {
    var genreFilmName = $("input[name = 'GenreFilmName']").val();
    var genreFilm = { GenreFilmName: genreFilmName };
    //Thêm mới phòng
    $.ajax({
        type: "POST",
        url: "/api/Genre_film",
        data: JSON.stringify(genreFilm),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            if (res == 0) {
                alert("Thêm thất bại");
            }
            else {
                alert("Thêm thành công!");
                location.href = "/Admin/Genre_film/Index";
            }
        }
    })
}

//Thêm phim
function BtnAddFilm_Click() {
    var FilmName = ($("input[name = 'FilmName']").val().length > 0) ? $("input[name = 'FilmName']").val() : "";
    var Author = ($("input[name = 'Author']").val().length > 0) ? $("input[name = 'Author']").val() : "";
    var Producer = ($("input[name = 'Producer']").val() > 0) ? $("input[name = 'Producer']").val() : "";
    var ReleaseDate = ($("input[name = 'ReleaseDate']").val().length > 0) ? $("input[name = 'ReleaseDate']").val() : "";
    var Nation = ($("input[name = 'Nation']").val().length > 0) ? $("input[name = 'Nation']").val() : "";
    var Rated = ($("input[name = 'Rated']").val().length > 0) ? $("input[name = 'Rated']").val() : 0;
    var Actor = ($("input[name = 'Actor']").val().length > 0) ? $("input[name = 'Actor']").val() : "";
    var Images = ($("#image-film").attr('src').length > 0) ? $("#image-film").attr('src') : "";
    //Mặc định thêm phim là sắp chiếu.
    var Status = 0;
    var Description = ($("textarea[name = 'Description']").val().length > 0) ? $("textarea[name = 'Description']").val() : "";
    var Trailer = ($("textarea[name = 'trailer']").html() > 0) ? $("textarea[name = 'trailer']").val() : "";
    var film = { FilmName: FilmName, Author: Author, Producer: Producer, ReleaseDate: ReleaseDate, Nation: Nation, Rated: Rated, Actor: Actor, Status: Status, Description: Description, Images: Images, Trailer: Trailer };
    var genreFilm = [];
    //Thêm mới phim
    $.ajax({
        type: "POST",
        url: "/api/Film",
        data: JSON.stringify(film),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            if (res == 0) {
                alert("Thêm thất bại");
            }
            else {
                alert("Thêm thành công!");
                $("input[name = 'GenreFilm']").each(function () {
                    if ($(this).is(":checked")) {
                        var obj = { FilmID: res, GenreFilmID: $(this).val() };
                        genreFilm.push(obj);
                    }
                })
                //Thêm loại phim
                $.ajax({
                    type: "POST",
                    url: "/api/Film_GenreFilm",
                    data: JSON.stringify(genreFilm),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (res) {
                    }
                });
                location.href = "/Admin/Films/Index";
            }
        }
    });


}


//Xóa phòng
function DelRoomClick(id) {
    var ok = confirm("Bạn có chắc muốn xóa!");
    if (ok == true) {
        $.ajax({
            url: "/api/Rooms/" + id,
            type: 'DELETE',
            dataType: 'json',
            success: function (res) {
                if (res == 1) {
                    alert("Xóa thành công!");
                    LoadDataRoom();
                }
                else {
                    alert("Xóa thất bại!");
                }
            }
        });
    }
}
//Xóa loại film
function DelGenreFilmClick(id) {
    var ok = confirm("Bạn có chắc muốn xóa!");
    if (ok == true) {
        $.ajax({
            url: "/api/Genre_room/" + id,
            type: 'DELETE',
            dataType: 'json',
            success: function (res) {
                if (res == 1) {
                    alert("Xóa thành công!");
                    LoadDataGenreFilm();
                }
                else {
                    alert("Xóa thất bại!");
                }
            }
        });
    }
}
//Xóa film
function DelFilmClick(id) {
    var ok = confirm("Bạn có chắc muốn xóa!");
    if (ok == true) {
        $.ajax({
            url: "/api/Film_GenreFilm/" + id,
            type: 'DELETE',
            dataType: 'json',
            success: function (res) {
            }
        });
        $.ajax({
            url: "/api/Film/" + id,
            type: 'DELETE',
            dataType: 'json',
            success: function (res) {
                if (res == 1) {
                    alert("Xóa thành công!");
                    LoadDataFilm();
                }
                else {
                    alert("Xóa thất bại!");
                }
            }
        });
    }
}



//table phòng
function LoadDataRoom() {
    _table = "";
    $.ajax({
        url: "/api/Rooms",
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            $.each(res, function (i, item) {
                _table += "<tr>";
                _table += "<td>" + item.RoomID + "</td>";
                _table += "<td>" + item.RoomName + "</td>";
                _table += "<td>" + item.Genre_room.GenreRoomName + "</td>";
                _table += "<td>" + GetStatusRoom(item.StatusRoom) + "</td>";
                _table += "<td>";
                _table += "<div class='d-flex'><a href='Edit/" + item.RoomID + "' class='btn btn-primary'>Sửa</a><button class='btn btn-danger btn-del-room' onclick='DelRoomClick(" + item.RoomID + ")'>Xóa</button>";
                _table += "</td></tr>";
            });
            $('#tbody-room').html(_table);
        }
    });
};
//table loại phim
function LoadDataGenreFilm() {
    _table = "";
    $.ajax({
        url: "/api/Genre_film",
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            $.each(res, function (i, item) {
                _table += "<tr>";
                _table += "<td>" + item.GenreFilmID + "</td>";
                _table += "<td>" + item.GenreFilmName + "</td>";
                _table += "<td>";
                _table += "<div class='d-flex'><a href='Edit/" + item.GenreFilmID + "' class='btn btn-primary'>Sửa</a><button class='btn btn-danger btn-del-room' onclick='DelGenreFilmClick(" + item.GenreFilmID + ")'>Xóa</button>";
                _table += "</td></tr>";
            });
            $('.tbody-genre-film').html(_table);
        }
    });
};
//table Film
function LoadDataFilm() {
    _table = "";
    $.ajax({
        url: "/api/Film",
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            $.each(res, function (i, item) {
                _table += "<tr>";
                _table += "<td>" + item.FilmName + "</td>";
                _table += "<td>" + item.Author + "</td>";
                _table += "<td>" + item.Producer + "</td>";
                _table += "<td>" + formatdate(item.ReleaseDate) + "</td>";
                _table += "<td>" + item.Nation + "</td>";
                _table += "<td>" + item.Rated.toFixed(1) + "</td>";
                _table += "<td>" + item.Actor + "</td>";
                _table += "<td>" + GetStatusFilm(item.Status) + "</td>";
                _table = _table + "<td>";
                _table += "<div class='d-flex'><a href='Edit/" + item.FilmID + "' class='btn btn-primary'>Sửa</a><button class='btn btn-danger btn-del-room' onclick='DelFilmClick(" + item.FilmID + ")'>Xóa</button>";
                _table += "</td></tr>";
            });
            $('.tbody-film').html(_table);
        }
    });
};
//table ShowTime
function LoadDataShowTime(id) {
    _table = "";
    if (id > 0) {
        var tbody = $(".tbody-ShowTime-" + id);
    } else {
        var tbody = $(".tbody-ShowTime");
    }
    tbody.html("");
    $.ajax({
        url: "/api/ShowTime/?genreRoomID=" + id,
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            $.each(res, function (i, item) {
                _table += "<tr>";
                _table += "<td>" + item.Film.FilmName + "</td>";
                _table += "<td>" + item.Room.RoomName + "</td>";
                _table += "<td>" + item.Room.Genre_room.GenreRoomName + "</td>";
                _table += "<td>" + formatFullDate(item.StartTime) + "</td>";
                _table = _table + "<td>";
                _table += "<div class='d-flex'><a href='Edit/" + item.ShowTimeID + "' class='btn btn-primary'>Sửa</a><button class='btn btn-danger btn-del-room' onclick='DelShowTimeClick(" + item.ShowTimeID + ")'>Xóa</button>";
                _table += "</td></tr>";
            })
            tbody.html(_table);
        }
    });
}

function CheckBoxGenreFilm(id) {
    var html = "";
    $(".check-box-genre-film").html("");
    $.ajax({
        url: "/api/Genre_film",
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            html += "<div><label for=''>Loại phim</label></div>";
            $.each(res, function (i, item) {
                html += "<div class='col-md-4 col-sm-6 col-xs-12'><div class='row'>";
                html += "<input type = 'checkbox' name = 'GenreFilm' id = 'genreFilm" + item.GenreFilmID + "' value='" + item.GenreFilmID + "' /> <label for='genreFilm" + item.GenreFilmID + "'>" + item.GenreFilmName + "</label>";
                html += "</div></div>";
            });
            $(".check-box-genre-film").html(html);
        }
    });
    if (id > 0) {
        $.ajax({
            url: "/api/Film_GenreFilm/?FilmID=" + id,
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                $.each(res, function (i, item) {
                    $("input[name='GenreFilm'][value='" + item.GenreFilmID + "']").prop('checked', true);
                })

            }
        });
    }
}

function UploadChange(src) {
    $("input[name='images']").change(function () {
        if (window.FormData != undefined) {
            var images = $("input[name='images']").get(0);
            var files = images.files;
            var formData = new FormData();
            formData.append('file', files[0]);
            console.log(files[0]);
            console.log(formData.getAll('file'));
            //Them anh
            $.ajax({
                type: "POST",
                url: "/api/Film/UploadImage?type=images",
                contentType: false,
                processData: false,
                data: formData,
                success: function (res) {
                    (res.length > 0) ? $("#image-film").attr('src', res) : src;
                },
                error: function (err) {
                    alert("Có lỗi xảy ra: " + err);
                }
            });
        }
    });
}

function ViewTrailer() {
    var trailer = $("textarea[name='trailer']").val();
    $(".view-trailer").html(trailer);
}