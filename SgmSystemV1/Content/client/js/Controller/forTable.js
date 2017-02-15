///_references.js
var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('#example').DataTable();
    }
}
user.init();