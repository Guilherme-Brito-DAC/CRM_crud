var data_inicio = document.getElementById("input_data_inicio")
var data_termino = document.getElementById("input_data_termino")
var label_data_termino = document.getElementById("label_data_termino")

function Verificar()
{
    if (data_inicio.value != "" && data_termino.value != "") {
        if (data_inicio.value > data_termino.value) {
            label_data_termino.innerHTML = "A data de termino precisa ser depois da data de inicio"
        }
        else
        {
            label_data_termino.innerHTML = ""
        }
    }
}

data_inicio.addEventListener("change", Verificar);
data_termino.addEventListener("change", Verificar);