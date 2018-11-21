
$(document).ready(function () {
    $.ajax({
        url: "/api/Rooms",
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            $.each(res, function (i, item) {
                _table = "<tr>";
                _table = _table + "<td>" + item.RoomID + "</td>";
                _table = _table + "<td>" + item.RoomName + "</td>";
                _table = _table + "<td>" + item.Genre_room.GenreRoomName + "</td>";
                if (item.StatusRoom == 1) {
                    _table = _table + "<td>Kích hoạt</td>";
                }
                else {
                    _table = _table + "<td>Không kích hoạt</td>";
                }
                _table = _table + "<td></td></tr>"
                $('#tbody-room').append(_table);
            })
        }
    });

    $('.btn-view-room').click(function () {
        var max_row = $(".room-max-row").val();
        var max_col = $(".room-max-col").val();
        if (max_row > 26) {
            max_row = 26;
            $(".room-max-row").val(26);
        }
        if (max_row < 1) {
            max_row = 1;
            $(".room-max-row").val(1);
        }
        if (max_col > 50) {
            max_col = 50;
            $(".room-max-col").val(50);
        }
        if (max_col < 1) {
            max_col = 1;
            $(".room-max-col").val(1);
        }

        var html = "";
        for (var i = 1; i <= max_row; i++) {
            html += "<tr numrow = '" + i + "'>";
            html += "<td>";
            html += "<select name = 'genre-chair' class='select-genre-chair' numrow = '" + i + "'></select></td>";
            for (var j = 1; j <= max_row; j++) {
                html += "<td class='text-center view-chair normal-chair' namechair ='" + String.fromCharCode(i+64) + j + "'><div class='glyphicon glyphicon-user'></div><div>" + String.fromCharCode(i+64) + j + "</div></td>";
            }
            html += "</tr>";
        }
        $(".view-room").html(html);
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
    });

    $("#btn-add-genre-room").click(function () {
        $(".view-chair").each(function () {
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
            var chair = { ChairName: name, GenreChair: loai };
            console.log(chair);
        });
        $.ajax({
            url: "/api/Rooms",
            type: 'POST',
            dataType: 'json',
            data: chair,
            success: function (res) {

            }
        });
    });


}) 