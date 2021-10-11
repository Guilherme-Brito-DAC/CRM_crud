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

function ListarCurso(id) {
    getDados('https://localhost:44303/Curso/ListarCursos')
        .then(dados => {
            curso = dados.filter(c => c.id == id)[0]

            document.getElementById("lbl_titulo").innerHTML = curso.titulo
            document.getElementById("lbl_inicio").innerHTML = curso.data_inicio
            document.getElementById("lbl_termino").innerHTML = curso.data_termino
            document.getElementById("lbl_inscricoes").innerHTML = curso.qnt_de_inscricoes
            document.getElementById("lbl_categoria").innerHTML = curso.categoria
            document.getElementById("lbl_periodo_letivo").innerHTML = curso.periodo_letivo
        });
}

function ListarLead(id) {
    getDados('https://localhost:44303/Lead/ListarLeads')
        .then(dados => {
            lead = dados.filter(c => c.id == id)[0]

            document.getElementById("lbl_nome").innerHTML = lead.nome
            document.getElementById("lbl_email").innerHTML = lead.email
            document.getElementById("lbl_telefone").innerHTML = lead.telefone
            document.getElementById("lbl_cpf").innerHTML = lead.cpf
        });
}