async function getDados(url = '') {
    const response = await fetch(url, {
        method: 'GET',
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {
            'Content-Type': 'application/json'
        },
        redirect: 'follow',
        referrerPolicy: 'no-referrer',
    });
    return response.json()
}

var cursos = []
var leads = []

getDados('https://localhost:44303/Curso/ListarCursos')
    .then(dados => {
        cursos = dados
    });

getDados('https://localhost:44303/Lead/ListarLeads')
    .then(dados => {
        leads = dados
    });

function Criar()
{
    var cursoSelect = document.getElementById("cursoSelect")
    var leadSelect = document.getElementById("leadSelect")
    var lbl_nome = document.getElementById("lbl_nome")
    var lbl_email = document.getElementById("lbl_email")
    var lbl_telefone = document.getElementById("lbl_telefone")
    var lbl_cpf = document.getElementById("lbl_cpf")
    var lbl_titulo = document.getElementById("lbl_titulo")
    var lbl_inicio = document.getElementById("lbl_inicio")
    var lbl_termino = document.getElementById("lbl_termino")
    var lbl_inscricoes = document.getElementById("lbl_inscricoes")
    var lbl_categoria = document.getElementById("lbl_categoria")
    var lbl_periodo_letivo = document.getElementById("lbl_periodo_letivo")

    leads.forEach(lead => {
        var opt = document.createElement('option');
        opt.value = lead.id;
        opt.innerHTML = lead.nome;
        leadSelect.appendChild(opt);
    });

    cursos.forEach(curso => {
        var opt = document.createElement('option');
        opt.value = curso.id;
        opt.innerHTML = curso.titulo;
        cursoSelect.appendChild(opt);
    });

    leadSelect.onchange = function (e) {
        var id = e.target.value
        var lead_selecionado = leads.find(e => e.id == id);

        if (lead_selecionado != undefined) {
            lbl_nome.innerHTML = lead_selecionado.nome
            lbl_email.innerHTML = lead_selecionado.email
            lbl_telefone.innerHTML = lead_selecionado.telefone
            lbl_cpf.innerHTML = lead_selecionado.cpf
        }
        else {
            ResetLead()
        }
    }

    cursoSelect.onchange = function (e) {
        var id = e.target.value
        var curso_selecionado = cursos.find(e => e.id == id);

        if (curso_selecionado != undefined) {
            lbl_titulo.innerHTML = curso_selecionado.titulo
            lbl_inicio.innerHTML = curso_selecionado.data_inicio
            lbl_termino.innerHTML = curso_selecionado.data_termino
            lbl_inscricoes.innerHTML = curso_selecionado.qnt_de_inscricoes
            lbl_categoria.innerHTML = curso_selecionado.categoria
            lbl_periodo_letivo.innerHTML = curso_selecionado.periodo_letivo
        }
        else {
            ResetCurso()
        }
    }

    btn_reset.onclick = function () {
        ResetCurso()
        ResetLead()
    }

    function ResetCurso() {
        lbl_titulo.innerHTML = ""
        lbl_inicio.innerHTML = ""
        lbl_termino.innerHTML = ""
        lbl_inscricoes.innerHTML = ""
        lbl_categoria.innerHTML = ""
        lbl_periodo_letivo.innerHTML = ""
    }

    function ResetLead() {
        lbl_nome.innerHTML = ""
        lbl_email.innerHTML = ""
        lbl_telefone.innerHTML = ""
        lbl_cpf.innerHTML = ""
    }
}