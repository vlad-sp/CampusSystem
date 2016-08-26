(function () {
    $("#btnPartial").on("click", function () {
        $("#partial").show(1000);
    })

    $("#cancel").on("click", function () {
        $("#partial").hide(1000);
    })


    $("button[data-action='save']").on("click", function () {
        var id = $(this).attr("data-id");
        $.post("/Administration/News/EditNews", { model: { Id: $(this).attr("data-id"), Title: $("#Title" + $(this).attr("data-id")).val(), Content: $("#Content" + $(this).attr("data-id")).val() } }, function (data) {
            console.log("News updated");
            $("#editModal" + id).hide();
            $('.modal-backdrop').hide();
            window.location = "News"
        })
    })
})();