(function () {
    $("select[data-action='building']").on("change", function () {
        $.post("/BookRoom/LoadFloors", { id: $(this).val() },
            function (data) {
                console.log("Loading floors ...");
                $("#floors").html(data);

                $("#floors select[data-action='floor']").on("change", function () {
                    $.post("/BookRoom/LoadRooms", { id: $(this).val() },
                        function (data) {
                            console.log("Loading rooms ...");
                            $("#rooms").html(data);
                        })
                });
            })
    });
})();