const sidebar = document.getElementById("sidebar");
const toggleBtn = document.getElementById("toggle-btn");
const toggleIcon = document.getElementById("toggle-icon");

toggleBtn.addEventListener("click", () => {
    sidebar.classList.toggle("closed");

    // Alterna o ícone conforme o estado
    if (sidebar.classList.contains("closed")) {
        toggleIcon.src = "Images/sidebar-open.png";
        toggleIcon.alt = "Abrir Sidebar";
        toggleBtn.style.left = "0px";
    } else {
        toggleIcon.src = "Images/sidebar-close.png";
        toggleIcon.alt = "Fechar Sidebar";
        toggleBtn.style.left = "270px";
    }
});

