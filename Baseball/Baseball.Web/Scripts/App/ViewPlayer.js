$(document)
    .ready(function () {
        // show the model
        $("#btnShowPlayer")
            .on("click",
                function () {
                    $("#showPlayerModal").modal("show");
                });

        // save event, send the data to the server
        //$('#btnSavePlayer')
        //    .on('click',
        //        function () {
        //            // create a player object to send to server
        //            var player = {};
        //            player.Name = $('#name').val();
        //            player.PhoneNumber = $('#phonenumber').val();

        //            $.post(uri, player)
        //                .done(function () {
        //                    loadPlayers();
        //                    $('#addPlayerModal').modal('hide');
        //                })
        //                .fail(function (jqXhr, status, err) {
        //                    alert(status + ' - ' + err);
        //                });
        //        });

        // solves issue with data staying in modal after modal is hidden
        //$("#addPlayerModal")
        //    .on("hidden.bs.modal",
        //        function () {
        //            $("#name").val("");
        //            $("#phonenumber").val("");
        //        });
    });