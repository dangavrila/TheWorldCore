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
    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $(this).text("Show Sidebar");
        } else {
            $(this).text("Hide Sidebar");
        }
    });

}) ();