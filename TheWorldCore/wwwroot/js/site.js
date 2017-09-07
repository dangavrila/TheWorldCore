// site.js
(function startup() {
    //var ele = $("#username");
    //ele.text("Anne Christie");

    //var main = $("#main");
    //main.mouseenter(function () {
    //    main.css("background-color", "#888");
    //});

    //main.mouseleave(function () {
    //    main.css("background-color", "#eee");
    //});

    //var menuItems = $("ul.menu li a");
    //menuItems.on("click", function () {
    //    var me = $(this);
    //    alert(me.text());
    //})


    var $sidebarAndWrapper = $("#sidebar,#wrapper"); // jQuerry wrap set
    var $icon = $("#sidebarToggle i.fa");
    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right");
        } else {
            $icon.addClass("fa-angle-left");
            $icon.removeClass("fa-angle-right");
        }
    });

}) ();