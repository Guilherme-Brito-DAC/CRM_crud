var senha = document.getElementById("input_senha")
var confirmar_senha = document.getElementById("input_Consenha")
var lbl_confirmar_senha = document.getElementById("lbl_confirmar_senha")
var btn_cadastrar = document.getElementById("btn_cadastrar")

function Validate() {
    if (senha.value != "" && confirmar_senha.value != "") {
        if (senha.value != confirmar_senha.value) {
            lbl_confirmar_senha.innerHTML = "As senhas não conferem"
            btn_cadastrar.disabled = true
        }
        else {
            lbl_confirmar_senha.innerHTML = ""
            btn_cadastrar.disabled = false
        }
    }
}

confirmar_senha.onchange = Validate
senha.onchange = Validate