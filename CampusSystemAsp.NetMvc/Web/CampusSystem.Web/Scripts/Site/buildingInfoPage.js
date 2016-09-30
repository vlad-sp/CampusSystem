(function () {
    $("select[data-action='building']").on("change", function () {
        $.post("/Administration/Building/LoadBuildingInfo", { id: $(this).val() },
            function (data) {
                console.log("Loading building info ...");
                $("#statistics").html(data);

                $(".consumptionStatistic").on("click", function () {
                    $.post("/Administration/Building/LoadConsumption", { id: $(this).attr("data-id") },
                        function (data) {
                            debugger;
                            console.log("Loading constumption info...");
                            console.log(data);
                            $("#consumptions").html(data);
                            $("#consumptions").show(5000);
                        }
                    )
                })

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