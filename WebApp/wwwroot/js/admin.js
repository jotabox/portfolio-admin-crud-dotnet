document.addEventListener("DOMContentLoaded", function () {
    const btn = document.getElementById("btnToggleSidebar");
    const sidebar = document.getElementById("sidebar");
    const btnCollapse = document.getElementById("btnCollapse");

    if (btn) {
        btn.addEventListener("click", () => {
            sidebar.classList.toggle("open");
        });
    }

    if (btnCollapse) {
        btnCollapse.addEventListener("click", () => {
            document.body.classList.toggle("sidebar-collapsed");
            // live toggle css: reduce width etc. (you can extend)
            if (document.body.classList.contains("sidebar-collapsed")) {
                document.querySelector('.sidebar').style.width = '80px';
                document.querySelector('.main-wrapper').style.marginLeft = '80px';
            } else {
                document.querySelector('.sidebar').style.width = '260px';
                document.querySelector('.main-wrapper').style.marginLeft = '260px';
            }
        });
    }
});
