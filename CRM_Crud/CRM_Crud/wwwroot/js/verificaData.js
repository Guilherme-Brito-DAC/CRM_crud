﻿var data_inicio = document.getElementById("input_data_inicio")
var data_termino = document.getElementById("input_data_termino")
var label_data_termino = document.getElementById("label_data_termino")
var btn_submit = document.getElementById("btn_submit")
var btn_editar = document.getElementById("btn_editar")

function Verificar()
{
    if (data_inicio.value != "" && data_termino.value != "")
    {
        if (data_inicio.value > data_termino.value)
        {
            label_data_termino.innerHTML = "A data de termino precisa ser depois da data de inicio"

            if (btn_editar != undefined) {
                btn_editar.disabled = true
            }
            else{
                btn_submit.disabled = true
            }
        }
        else
        {
            label_data_termino.innerHTML = ""

            if (btn_editar != undefined) {
                btn_editar.disabled = false
            }
            else {
                btn_submit.disabled = false
            }
        }
    }
}

data_inicio.addEventListener("change", Verificar);
data_termino.addEventListener("change", Verificar);