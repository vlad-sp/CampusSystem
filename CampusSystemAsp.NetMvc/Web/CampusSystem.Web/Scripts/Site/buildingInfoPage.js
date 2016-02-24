(function () {
    $("select[data-action='building']").on("change", function () {
        $.post("/Administration/Building/LoadBuildingInfo", { id: $(this).val() },
            function (data) {
                console.log("Loading building info ...");
                $("#statistics").html(data);

                $("button[data-action='save']").on("click", function () {
                    var id = $(this).attr("data-id");
                    $.post("/Administration/Building/UpdateHostName", { id: $(this).attr("data-id"), name: $("#Name" + $(this).attr("data-id")).val() }, function (data) {
                        console.log("Host name updated");
                        $("#editModal" + id).hide();
                        $('.modal-backdrop').hide();
                        window.location = "Building"
                    })
                })
            });
    });
})();