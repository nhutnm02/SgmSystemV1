///_references.js
var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('#example').DataTable({
            responsive:true    
        });
    }
}
user.init();