document.querySelector(".botao_menu").onclick = function () {
    document.querySelector(".menu_lateral").classList.toggle("colapse");
};

var url_atual = window.location.href;
url_atual.replace("https://localhost:44303/", "")

if (url_atual.includes("inscricao") || url_atual.includes("Inscricao"))
{
    document.querySelector("#NavItemInscricao").classList.add("active")
    document.querySelector("#NavItemLead").classList.remove("active")
    document.querySelector("#NavItemCurso").classList.remove("active")
}
else if (url_atual.includes("curso") || url_atual.includes("Curso"))
{
    document.querySelector("#NavItemCurso").classList.add("active")
    document.querySelector("#NavItemInscricao").classList.remove("active")
    document.querySelector("#NavItemLead").classList.remove("active")
}
else
{
    document.querySelector("#NavItemLead").classList.add("active")
    document.querySelector("#NavItemInscricao").classList.remove("active")
    document.querySelector("#NavItemCurso").classList.remove("active")
}