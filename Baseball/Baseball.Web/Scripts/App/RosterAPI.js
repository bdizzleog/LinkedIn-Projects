var uri = "/api/players/";

$(document)
    .ready(function () {
        loadPlayers();
    });

function loadPlayers() {
    $.getJSON(uri)
        .done(function (data) {
            $("#players tbody tr").remove();
            $.each(data,
                function (index, player) {
                    $(createRow(player)).appendTo($("#players tbody"));
                });
        });
};

function createRow(player) {
    return "<tr><td>" +
        player.JerseyNumber +
        "</td><td>" +
        player.Position +
        "</td><td>" +
        player.YearsPlayed +
        "</td><td>" +
        player.BattingAvg +
        "</td></tr>";
};